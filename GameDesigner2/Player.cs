using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesigner2
{
    internal class Player : Active
    {
        //出生点
        public int bornX;
        public int bornY;
        public Player(int x, int y, int speed)
        {
            this.id = 3;
            this.IsMoving = false;
            bornX = x;
            bornY = y;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Bmp = Properties.Resources.player;
        }
        public override void Update()
        {
            MoveCheck();
            Move();
            base.Update();
        }
        //重写
        protected override void MoveCheck()
        {
            #region 边界
            if (Dir == Direction.Up)
            {
                if (this.Y - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (this.Y + Speed + Height > 900)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (this.X - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (this.X + Speed + Width > 900)
                {
                    IsMoving = false;
                    return;
                }
            }
            #endregion
            #region 墙
            //防止卡死
            Rectangle rect = GetRectangle();
            switch (Dir)
            {
                case Direction.Up:
                    rect.Y -= Speed;
                    break;
                case Direction.Down:
                    rect.Y += Speed;
                    break;
                case Direction.Left:
                    rect.X -= Speed;
                    break;
                case Direction.Right:
                    rect.X += Speed;
                    break;
            }
            if (Unity.IsCollidedWall(rect) != null)
            {
                IsMoving = false;
                return;
            }
            if (Unity.IsCollidedWall2(rect) != null)
            {
                IsMoving = false;
                return;
            }
            if (Unity.IsCollidedEnemy(rect) != null)
            {
                SoundManager.PlayHit();
                Unity.GameDate[this.X / 30, this.Y / 30] = 0;
                this.X = bornX;
                this.Y = bornY;
                Unity.GameDate[this.X / 30, this.Y / 30] = 3;
            }
            Stationary st;
            if ((st = Unity.IsCollidedFullSpeed(rect)) != null)
            {
                this.Speed *= 2;
                Unity.DestroyFullSpeed(st);
            }
            #endregion
        }
        protected override Image GetImg()
        {
            Bmp.MakeTransparent(Color.White);
            return base.GetImg();
        }
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Dir = Direction.Up;
                    this.IsMoving = true;
                    break;
                case Keys.S:
                    Dir = Direction.Down;
                    this.IsMoving = true;
                    break;
                case Keys.A:
                    Dir = Direction.Left;
                    this.IsMoving = true;
                    break;
                case Keys.D:
                    Dir = Direction.Right;
                    this.IsMoving = true;
                    break;
                case Keys.E:
                    Attack();
                    break;
            }
        }
        private void Attack()
        {
            //发射子弹
            int x = this.X;
            int y = this.Y;

            switch (Dir)
            {
                case Direction.Up:
                    x = x + Width / 2;
                    break;
                case Direction.Down:
                    x = x + Width / 2;
                    y += Height;
                    break;
                case Direction.Left:
                    y = y + Height / 2;
                    break;
                case Direction.Right:
                    x += Width;
                    y = y + Height / 2;
                    break;
            }

            if (Unity.GameFlag == true)
            {
                SoundManager.PlayFire();
                Unity.CreateBullet(x, y, Dir, Tag.Player);
            }
        }
        public void KeyUp(KeyEventArgs e)
        {
            this.IsMoving = false;
        }
    }
}
