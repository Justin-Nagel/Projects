namespace Project1_PRG282
{
    partial class MainMenu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCourses = new System.Windows.Forms.Label();
            this.pbxCourses = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStudents = new System.Windows.Forms.Label();
            this.pbxStudents = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCourses)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblCourses);
            this.panel2.Controls.Add(this.pbxCourses);
            this.panel2.Location = new System.Drawing.Point(508, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 265);
            this.panel2.TabIndex = 3;
            // 
            // lblCourses
            // 
            this.lblCourses.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourses.Location = new System.Drawing.Point(0, 227);
            this.lblCourses.Name = "lblCourses";
            this.lblCourses.Size = new System.Drawing.Size(208, 38);
            this.lblCourses.TabIndex = 2;
            this.lblCourses.Text = "Courses";
            this.lblCourses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCourses.Click += new System.EventHandler(this.lblCourses_Click);
            // 
            // pbxCourses
            // 
            this.pbxCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxCourses.BackgroundImage = global::Project1_PRG282.Properties.Resources.kisspng_computer_icons_vector_graphics_education_training_5b76b9c381cbe8_5235567715345074595317;
            this.pbxCourses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxCourses.Location = new System.Drawing.Point(3, 3);
            this.pbxCourses.Name = "pbxCourses";
            this.pbxCourses.Size = new System.Drawing.Size(202, 212);
            this.pbxCourses.TabIndex = 0;
            this.pbxCourses.TabStop = false;
            this.pbxCourses.Click += new System.EventHandler(this.pbxCourses_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblStudents);
            this.panel1.Controls.Add(this.pbxStudents);
            this.panel1.Location = new System.Drawing.Point(100, 100);
            this.panel1.Margin = new System.Windows.Forms.Padding(100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 265);
            this.panel1.TabIndex = 2;
            // 
            // lblStudents
            // 
            this.lblStudents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudents.Location = new System.Drawing.Point(0, 227);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(208, 38);
            this.lblStudents.TabIndex = 1;
            this.lblStudents.Text = "Students";
            this.lblStudents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblStudents.Click += new System.EventHandler(this.lblStudents_Click);

            // 
            // pbxStudents
            // 
            this.pbxStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxStudents.BackgroundImage = global::Project1_PRG282.Properties.Resources.kisspng_computer_icons_users_group_group_icon_5b19151b76d127_1186364715283704594867;
            this.pbxStudents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxStudents.Location = new System.Drawing.Point(3, 3);
            this.pbxStudents.Name = "pbxStudents";
            this.pbxStudents.Size = new System.Drawing.Size(202, 212);
            this.pbxStudents.TabIndex = 0;
            this.pbxStudents.TabStop = false;
            this.pbxStudents.Click += new System.EventHandler(this.pbxStudents_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(816, 505);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainMenu";
            this.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.Text = "MainMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCourses)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbxCourses;
        private System.Windows.Forms.PictureBox pbxStudents;
        private System.Windows.Forms.Label lblStudents;
        private System.Windows.Forms.Label lblCourses;
    }
}