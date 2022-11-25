using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesigner2
{
    public partial class Form1 : Form
    {
        public static bool flag = false;
        public static Graphics windowGraphic;
        public static Bitmap temporaryBitmap;
        private Thread t;
        public Form1()
        {
            InitializeComponent();
            windowGraphic = this.CreateGraphics();
            temporaryBitmap = new Bitmap(900, 900);
            Unity.UnityGraphic = Graphics.FromImage(temporaryBitmap);

            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        }
        private static void GameMainThread()
        {
            Unity.Start();
            while (true)
            {
                Unity.Update();
                windowGraphic.DrawImage(temporaryBitmap, 0, 0);
                //企图180FPS
                //在没有线程休眠的情况下，极限是每秒58帧
                //Thread.Sleep(1000 / 180);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Wall_Click(object sender, EventArgs e)
        {
            WallForm wallForm = new WallForm();
            wallForm.ShowDialog();
        }

        private void gameFlag_Click(object sender, EventArgs e)
        {
            if (Unity.GameFlag == true)
            {
                gameFlag.Text = "设计";
            }
            else
            {
                gameFlag.Text = "游戏";
            }
            Unity.GameFlag = !Unity.GameFlag;
        }

        #region 传递事件
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Unity.KeyDown(e);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Unity.KeyUp(e);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Unity.MouseDown(e);
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Unity.MouseUp(e);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Unity.MouseMove(e);
        }
        #endregion

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Destroy;
        }

        private void Active_Click(object sender, EventArgs e)
        {
            ActiveForm activeForm = new ActiveForm();
            activeForm.ShowDialog();
        }

        private void ClearAllBtn_Click(object sender, EventArgs e)
        {
            Unity.ClearAll();
        }

        private void gameProp_Click(object sender, EventArgs e)
        {
            PropForm propForm = new PropForm();
            propForm.ShowDialog();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
        }
    }
}
