namespace GameDesigner2
{
    partial class WallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Wall2Btn = new System.Windows.Forms.Button();
            this.WallBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Wall2Btn
            // 
            this.Wall2Btn.BackgroundImage = global::GameDesigner2.Properties.Resources.wall2;
            this.Wall2Btn.Location = new System.Drawing.Point(89, 17);
            this.Wall2Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Wall2Btn.Name = "Wall2Btn";
            this.Wall2Btn.Size = new System.Drawing.Size(50, 50);
            this.Wall2Btn.TabIndex = 1;
            this.Wall2Btn.UseVisualStyleBackColor = true;
            this.Wall2Btn.Click += new System.EventHandler(this.Wall2Btn_Click);
            // 
            // WallBtn
            // 
            this.WallBtn.BackgroundImage = global::GameDesigner2.Properties.Resources.wall;
            this.WallBtn.Location = new System.Drawing.Point(18, 17);
            this.WallBtn.Name = "WallBtn";
            this.WallBtn.Size = new System.Drawing.Size(50, 50);
            this.WallBtn.TabIndex = 0;
            this.WallBtn.UseVisualStyleBackColor = true;
            this.WallBtn.Click += new System.EventHandler(this.WallBtn_Click);
            // 
            // WallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 191);
            this.Controls.Add(this.Wall2Btn);
            this.Controls.Add(this.WallBtn);
            this.Name = "WallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择墙";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WallBtn;
        private System.Windows.Forms.Button Wall2Btn;
    }
}