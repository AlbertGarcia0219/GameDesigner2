using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesigner2
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            if (checkBox1.Checked != Settings.mute)
            {
                checkBox1.Checked = Settings.mute;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.playerSpeed = Convert.ToInt32(numericUpDown1.Value);
        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Settings.enemySpeed = Convert.ToInt32(numericUpDown2.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Settings.mute = true;
                SoundManager.bgm.Stop();
            }
            else
            {
                Settings.mute = false;
                SoundManager.bgm.Play();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Settings.enemyBornSpeed = Convert.ToInt32(numericUpDown3.Value);
            Unity.enemyBornSpeed = Settings.enemyBornSpeed;//雪怪刷新频率
        }
    }
}
