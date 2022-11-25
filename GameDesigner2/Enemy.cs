using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameDesigner2
{
    internal class Enemy : Active
    {
        private int ChangeSpeed = 180;
        private int ChangeCount = 0;
        private Random random = new Random();
        public Enemy(int x, int y, int speed)
        {
            this.id = 4;
            this.IsMoving = true;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Bmp = Properties.Resources.enemy;
            Dir = Direction.Down;
        }
        protected override Image GetImg()
        {
            Bmp.MakeTransparent(Color.White);
            return base.GetImg();
        }
        //更改移动方向
        private void ChangeDirection()
        {
            //只有方向不一样才会改变
            while (true)
            {
                Direction dir = (Direction)random.Next(0, 4);
                if (dir == Dir)
                {
                    continue;
                }
                {
                    Dir = dir;
                    break;
                }
            }

        }
        //碰撞检测
        protected override void MoveCheck()
        {
            #region 边界
            if (Dir == Direction.Up)
            {
                if (this.Y - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (this.Y + Speed + Height > 900)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (this.X - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (this.X + Speed + Width > 900)
                {
                    ChangeDirection();
                    return;
                }
            }
            #endregion
            #region 物体
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
                ChangeDirection();
                return;
            }
            if (Unity.IsCollidedWall2(rect) != null)
            {
                ChangeDirection();
                return;
            }
            Stationary st;
            if ((st = Unity.IsCollidedFullSpeed(rect)) != null)
            {
                lock (Unity._fullSpeedLock)
                {
                    Unity.DestroyFullSpeed(st);
                }
            }
            //吃掉饼干
            if (Unity.Cookie != null)
            {
                if (Unity.IsCollidedCookie(rect) != null)
                {
                    Unity.GameDate[Unity.Cookie.X / 30, Unity.Cookie.Y / 30] = 0;
                    Unity.Cookie = null;
                    Unity.GameOver();
                }
            }
            #endregion
        }
        //重写Update
        public override void Update()
        {
            ChangeCount++;
            if (ChangeCount > ChangeSpeed)
            {
                ChangeDirection();
                ChangeCount = 0;
            }
            MoveCheck();
            Move();
            base.Update();
        }
    }
}
