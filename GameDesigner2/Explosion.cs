using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDesigner2.Properties;

namespace GameDesigner2
{
    internal class Explosion : GameObject
    {
        private Bitmap[] bmps = new Bitmap[]
        {
            Resources.EXP1, Resources.EXP2,Resources.EXP3,Resources.EXP4,Resources.EXP5
        };
        public bool IsDestroy { get; set; }
        private int playSpeed = 2;//6帧一次
        private int playCount = -1;
        private int playIndex = 0;

        public Explosion(int x, int y)
        {
            foreach (Bitmap bmp in bmps)
            {
                bmp.MakeTransparent(Color.Black);
            }
            IsDestroy = false;
            this.Width = 32;
            this.Height = 32;
            //位置修正
            this.X = x - this.Width / 2;
            this.Y = y - this.Height / 2;
        }
        public override void Update()
        {
            if (playCount < 9)
            {
                playCount++;
            }
            else
            {
                IsDestroy = true;
            }
            base.Update();
        }
        protected override Image GetImg()
        {
            playIndex = playCount / playSpeed;
            return bmps[playIndex];
        }
    }
}
