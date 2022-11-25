using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesigner2
{
    enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    internal class Active : GameObject
    {
        //private Object _lock = new object();
        public Direction Dir;
        public bool IsMoving { get; set; }
        public int Speed;
        private Bitmap bmp;
        public int id;
        public Bitmap Bmp
        {
            get { return bmp; }
            set
            {
                bmp = value;
                this.Width = bmp.Width;
                this.Height = bmp.Height;
            }
        }
        protected override Image GetImg()
        {
            return bmp;
        }
        #region 移动相关
        //移动
        protected void Move()
        {
            if (Unity.GameFlag != true) return;
            if (!IsMoving) return;
            switch (Dir)
            {
                case Direction.Up:
                    Unity.GameDate[this.X / 30, this.Y / 30] = 0;
                    Y -= Speed;
                    Unity.GameDate[this.X / 30, this.Y / 30] = this.id;
                    break;
                case Direction.Down:
                    Unity.GameDate[this.X / 30, this.Y / 30] = 0;
                    Y += Speed;
                    Unity.GameDate[this.X / 30, this.Y / 30] = this.id;
                    break;
                case Direction.Left:
                    Unity.GameDate[this.X / 30, this.Y / 30] = 0;
                    X -= Speed;
                    Unity.GameDate[this.X / 30, this.Y / 30] = this.id;
                    break;
                case Direction.Right:
                    Unity.GameDate[this.X / 30, this.Y / 30] = 0;
                    X += Speed;
                    Unity.GameDate[this.X / 30, this.Y / 30] = this.id;
                    break;
            }
        }
        //碰撞检测
        protected virtual void MoveCheck()
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
            #endregion
        }
        #endregion

    }
}
