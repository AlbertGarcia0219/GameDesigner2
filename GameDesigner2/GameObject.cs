using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesigner2
{
    internal abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        protected abstract Image GetImg();
        public virtual void DrawSelf()
        {
            Unity.UnityGraphic.DrawImage(GetImg(), X, Y, Width, Height);
        }
        public virtual void Update()
        {
            DrawSelf();
        }
        //每个单位都有的碰撞判断方块
        public Rectangle GetRectangle()
        {
            Rectangle rect = new Rectangle(X, Y, Width, Height);
            return rect;
        }
    }
}
