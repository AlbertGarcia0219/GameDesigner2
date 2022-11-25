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
    public partial class ActiveForm : Form
    {
        public ActiveForm()
        {
            InitializeComponent();
        }

        private void PlayerBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Player;
            this.Close();
        }

        private void EnemyBtn_Click(object sender, EventArgs e)
        {
            Unity.DP = DesignerPointer.Enemy;
            this.Close();
        }
    }
}
