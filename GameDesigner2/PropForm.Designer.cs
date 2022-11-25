namespace GameDesigner2
{
    partial class PropForm
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
            this.BornBtn = new System.Windows.Forms.Button();
            this.CookieBtn = new System.Windows.Forms.Button();
            this.FullSpeedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BornBtn
            // 
            this.BornBtn.BackgroundImage = global::GameDesigner2.Properties.Resources.born;
            this.BornBtn.Location = new System.Drawing.Point(12, 12);
            this.BornBtn.Name = "BornBtn";
            this.BornBtn.Size = new System.Drawing.Size(50, 50);
            this.BornBtn.TabIndex = 1;
            this.BornBtn.UseVisualStyleBackColor = true;
            this.BornBtn.Click += new System.EventHandler(this.BornBtn_Click);
            // 
            // CookieBtn
            // 
            this.CookieBtn.BackgroundImage = global::GameDesigner2.Properties.Resources.cookie;
            this.CookieBtn.Location = new System.Drawing.Point(68, 12);
            this.CookieBtn.Name = "CookieBtn";
            this.CookieBtn.Size = new System.Drawing.Size(50, 50);
            this.CookieBtn.TabIndex = 2;
            this.CookieBtn.UseVisualStyleBackColor = true;
            this.CookieBtn.Click += new System.EventHandler(this.CookieBtn_Click);
            // 
            // FullSpeedBtn
            // 
            this.FullSpeedBtn.BackgroundImage = global::GameDesigner2.Properties.Resources.speed;
            this.FullSpeedBtn.Location = new System.Drawing.Point(124, 12);
            this.FullSpeedBtn.Name = "FullSpeedBtn";
            this.FullSpeedBtn.Size = new System.Drawing.Size(50, 50);
            this.FullSpeedBtn.TabIndex = 3;
            this.FullSpeedBtn.UseVisualStyleBackColor = true;
            this.FullSpeedBtn.Click += new System.EventHandler(this.FullSpeedBtn_Click);
            // 
            // PropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 191);
            this.Controls.Add(this.FullSpeedBtn);
            this.Controls.Add(this.CookieBtn);
            this.Controls.Add(this.BornBtn);
            this.Name = "PropForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PropForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BornBtn;
        private System.Windows.Forms.Button CookieBtn;
        private System.Windows.Forms.Button FullSpeedBtn;
    }
}