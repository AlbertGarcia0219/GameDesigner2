namespace GameDesigner2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClearAllBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.gameFlag = new System.Windows.Forms.Button();
            this.gameProp = new System.Windows.Forms.Button();
            this.Active = new System.Windows.Forms.Button();
            this.Wall = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::GameDesigner2.Properties.Resources.paper;
            this.panel1.Controls.Add(this.ClearAllBtn);
            this.panel1.Controls.Add(this.ClearBtn);
            this.panel1.Controls.Add(this.settings);
            this.panel1.Controls.Add(this.gameFlag);
            this.panel1.Controls.Add(this.gameProp);
            this.panel1.Controls.Add(this.Active);
            this.panel1.Controls.Add(this.Wall);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(900, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 900);
            this.panel1.TabIndex = 0;
            // 
            // ClearAllBtn
            // 
            this.ClearAllBtn.FlatAppearance.BorderSize = 0;
            this.ClearAllBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ClearAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ClearAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearAllBtn.Font = new System.Drawing.Font("清松手寫體1", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearAllBtn.Location = new System.Drawing.Point(10, 276);
            this.ClearAllBtn.Name = "ClearAllBtn";
            this.ClearAllBtn.Size = new System.Drawing.Size(80, 60);
            this.ClearAllBtn.TabIndex = 6;
            this.ClearAllBtn.Text = "一键清空";
            this.ClearAllBtn.UseVisualStyleBackColor = true;
            this.ClearAllBtn.Click += new System.EventHandler(this.ClearAllBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.FlatAppearance.BorderSize = 0;
            this.ClearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ClearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("清松手寫體1", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(10, 210);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(80, 60);
            this.ClearBtn.TabIndex = 5;
            this.ClearBtn.Text = "清除";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // settings
            // 
            this.settings.FlatAppearance.BorderSize = 0;
            this.settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Font = new System.Drawing.Font("清松手寫體1", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings.Location = new System.Drawing.Point(10, 760);
            this.settings.Name = "settings";
            this.settings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settings.Size = new System.Drawing.Size(80, 60);
            this.settings.TabIndex = 4;
            this.settings.Text = "设置";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // gameFlag
            // 
            this.gameFlag.FlatAppearance.BorderSize = 0;
            this.gameFlag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.gameFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.gameFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameFlag.Font = new System.Drawing.Font("清松手寫體1", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameFlag.Location = new System.Drawing.Point(10, 830);
            this.gameFlag.Name = "gameFlag";
            this.gameFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gameFlag.Size = new System.Drawing.Size(80, 60);
            this.gameFlag.TabIndex = 3;
            this.gameFlag.Text = "设计";
            this.gameFlag.UseVisualStyleBackColor = true;
            this.gameFlag.Click += new System.EventHandler(this.gameFlag_Click);
            // 
            // gameProp
            // 
            this.gameProp.FlatAppearance.BorderSize = 0;
            this.gameProp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.gameProp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.gameProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameProp.Font = new System.Drawing.Font("清松手寫體1", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameProp.Location = new System.Drawing.Point(10, 140);
            this.gameProp.Name = "gameProp";
            this.gameProp.Size = new System.Drawing.Size(80, 60);
            this.gameProp.TabIndex = 2;
            this.gameProp.Text = "道具";
            this.gameProp.UseVisualStyleBackColor = true;
            this.gameProp.Click += new System.EventHandler(this.gameProp_Click);
            // 
            // Active
            // 
            this.Active.FlatAppearance.BorderSize = 0;
            this.Active.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Active.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Active.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Active.Font = new System.Drawing.Font("清松手寫體1", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active.Location = new System.Drawing.Point(10, 70);
            this.Active.Name = "Active";
            this.Active.Size = new System.Drawing.Size(80, 60);
            this.Active.TabIndex = 1;
            this.Active.Text = "动物";
            this.Active.UseVisualStyleBackColor = true;
            this.Active.Click += new System.EventHandler(this.Active_Click);
            // 
            // Wall
            // 
            this.Wall.BackColor = System.Drawing.Color.Transparent;
            this.Wall.FlatAppearance.BorderSize = 0;
            this.Wall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Wall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Wall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Wall.Font = new System.Drawing.Font("清松手寫體1", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wall.ForeColor = System.Drawing.Color.Black;
            this.Wall.Location = new System.Drawing.Point(10, 10);
            this.Wall.Name = "Wall";
            this.Wall.Size = new System.Drawing.Size(80, 60);
            this.Wall.TabIndex = 0;
            this.Wall.Text = "地形";
            this.Wall.UseVisualStyleBackColor = false;
            this.Wall.Click += new System.EventHandler(this.Wall_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 900);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("清松手寫體1", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Wall;
        private System.Windows.Forms.Button Active;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button gameFlag;
        private System.Windows.Forms.Button gameProp;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button ClearAllBtn;
    }
}

