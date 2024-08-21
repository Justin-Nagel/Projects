namespace Project1_PRG282
{
    partial class LogInForm
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
            this.pnlLogInContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLogInInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.pnlLogInContainer.SuspendLayout();
            this.pnlLogInInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogInContainer
            // 
            this.pnlLogInContainer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlLogInContainer.Controls.Add(this.pnlLogInInfo);
            this.pnlLogInContainer.Controls.Add(this.btnLogIn);
            this.pnlLogInContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogInContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLogInContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLogInContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlLogInContainer.Name = "pnlLogInContainer";
            this.pnlLogInContainer.Padding = new System.Windows.Forms.Padding(42, 52, 0, 0);
            this.pnlLogInContainer.Size = new System.Drawing.Size(284, 361);
            this.pnlLogInContainer.TabIndex = 0;
            this.pnlLogInContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogInContainer_Paint);
            // 
            // pnlLogInInfo
            // 
            this.pnlLogInInfo.Controls.Add(this.lblUsername);
            this.pnlLogInInfo.Controls.Add(this.txtUsername);
            this.pnlLogInInfo.Controls.Add(this.lblPassword);
            this.pnlLogInInfo.Controls.Add(this.txtPassword);
            this.pnlLogInInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLogInInfo.Location = new System.Drawing.Point(45, 55);
            this.pnlLogInInfo.Name = "pnlLogInInfo";
            this.pnlLogInInfo.Size = new System.Drawing.Size(200, 160);
            this.pnlLogInInfo.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(5, 5);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(5);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Padding = new System.Windows.Forms.Padding(5);
            this.lblUsername.Size = new System.Drawing.Size(190, 32);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUsername.Location = new System.Drawing.Point(5, 47);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(190, 26);
            this.txtUsername.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(5, 83);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Padding = new System.Windows.Forms.Padding(5);
            this.lblPassword.Size = new System.Drawing.Size(190, 32);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(5, 125);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(190, 26);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogIn.Location = new System.Drawing.Point(47, 248);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(5, 30, 5, 5);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(196, 32);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.pnlLogInContainer);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 400);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "LogInForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Log In";
            this.pnlLogInContainer.ResumeLayout(false);
            this.pnlLogInInfo.ResumeLayout(false);
            this.pnlLogInInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlLogInContainer;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.FlowLayoutPanel pnlLogInInfo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
    }
}

