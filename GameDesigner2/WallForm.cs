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
    public partial class WallForm : Form
    {
        public WallForm()
        {
            InitializeComponent();
        }
        private void WallBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Wall;
            this.Close();
        }

        private void Wall2Btn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Wall2;
            this.Close();
        }
    }
}
