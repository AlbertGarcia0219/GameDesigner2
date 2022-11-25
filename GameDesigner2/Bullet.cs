using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesigner2.Properties;

namespace GameDesigner2
{
    enum Tag
    {
        Player,
        Enemy
    }
    internal class Bullet : Active
    {
        public Tag tag { get; set; }
        public bool IsDestroy { get; set; }
        public Bullet(int x, int y, int speed, Direction dir, Tag tag)
        {
            this.IsMoving = true;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Bmp = Properties.Resources.bullet;
            this.Dir = dir;
            this.tag = tag;

            //图片修正
            this.X -= Width / 2;
            this.Y -= Height / 2;
        }

        public override void Update()
        {
            MoveCheck();
            Move();
            base.Update();
        }
        protected override Image GetImg()
        {
            Bmp.MakeTransparent(Color.White);
            return base.GetImg();
        }
        protected void Move()
        {
            if (Unity.GameFlag != true) return;
            if (!IsMoving) return;
            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }
        protected override void MoveCheck()
        {
            #region 边界
            if (Dir == Direction.Up)
            {
                if (Y + Height / 2 + 3 < 0)
                {
                    IsDestroy = true; return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Height / 2 - 3 > 900)
                {
                    IsDestroy = true; return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X + Width / 2 - 3 < 0)
                {
                    IsDestroy = true; return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Width / 2 + 3 > 900)
                {
                    IsDestroy = true; return;
                }
            }
            #endregion
            #region 与其他的GameObject碰撞
            //子弹的实际碰撞矩形是非常小的
            Rectangle rect = GetRectangle();

            rect.X = X + Width / 2 - 3;
            rect.Y = Y + Height / 2 - 3;
            rect.Height = 3;
            rect.Width = 3;

            //爆炸的实际中心位置
            int xExplosion = this.X + Width / 2;
            int yExplosion = this.Y + Height / 2;

            Stationary stationary = null;
            Enemy enemy = null;
            if ((stationary = Unity.IsCollidedWall(rect)) != null)
            {
                SoundManager.PlayExp();
                IsDestroy = true;
                Unity.CreateExplosion(xExplosion, yExplosion);
                Unity.DestroyWall(stationary);
                return;
            }
            else if (Unity.IsCollidedWall2(rect) != null)
            {
                IsDestroy = true;
                Unity.CreateExplosion(xExplosion, yExplosion);
                return;
            }
            else if ((enemy = Unity.IsCollidedEnemy(rect)) != null)
            {
                SoundManager.PlayExp();
                IsDestroy = true;
                Unity.CreateExplosion(xExplosion, yExplosion);
                Unity.DestroyEnemy(enemy);
                return;
            }

            #endregion
        }
        //设计的小失误,难以对bitmap预处理
        //protected override Image GetImg()
        //{
        //    return this.Img;
        //}
    }
}
