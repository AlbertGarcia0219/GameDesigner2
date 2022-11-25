namespace GameDesigner2
{
    partial class ActiveForm
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
            this.PlayerBtn = new System.Windows.Forms.Button();
            this.EnemyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerBtn
            // 
            this.PlayerBtn.BackgroundImage = global::GameDesigner2.Properties.Resources.player;
            this.PlayerBtn.Location = new System.Drawing.Point(20, 10);
            this.PlayerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerBtn.Name = "PlayerBtn";
            this.PlayerBtn.Size = new System.Drawing.Size(50, 50);
            this.PlayerBtn.TabIndex = 0;
            this.PlayerBtn.UseVisualStyleBackColor = true;
            this.PlayerBtn.Click += new System.EventHandler(this.PlayerBtn_Click);
            // 
            // EnemyBtn
            // 
            this.EnemyBtn.BackgroundImage = global::GameDesigner2.Properties.Resources.enemy;
            this.EnemyBtn.Location = new System.Drawing.Point(80, 10);
            this.EnemyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyBtn.Name = "EnemyBtn";
            this.EnemyBtn.Size = new System.Drawing.Size(50, 50);
            this.EnemyBtn.TabIndex = 1;
            this.EnemyBtn.UseVisualStyleBackColor = true;
            this.EnemyBtn.Click += new System.EventHandler(this.EnemyBtn_Click);
            // 
            // ActiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 191);
            this.Controls.Add(this.EnemyBtn);
            this.Controls.Add(this.PlayerBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ActiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择动物";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayerBtn;
        private System.Windows.Forms.Button EnemyBtn;
    }
}