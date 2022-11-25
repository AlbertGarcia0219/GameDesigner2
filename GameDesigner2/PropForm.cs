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
    public partial class PropForm : Form
    {
        public PropForm()
        {
            InitializeComponent();
        }

        private void BornBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Born;
            this.Close();
        }

        private void CookieBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Cookie;
            this.Close();
        }

        private void FullSpeedBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.FullSpeed;
            this.Close();
        }
    }
}
