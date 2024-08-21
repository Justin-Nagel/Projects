using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_PRG282
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pbxStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm studentForm = new StudentForm();
            studentForm.FormClosed += MainMenu_FormClosed;
            studentForm.ShowDialog();
        }
   
        private void pbxCourses_Click(object sender, EventArgs e)
        {
            this.Hide();
            CourseForm courseForm = new CourseForm();
            courseForm.FormClosed += MainMenu_FormClosed;
            courseForm.ShowDialog();
        }

        private void lblStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm studentForm = new StudentForm();
            studentForm.FormClosed += MainMenu_FormClosed;
            studentForm.ShowDialog();
        }

        private void lblCourses_Click(object sender, EventArgs e)
        {
            this.Hide();
            CourseForm courseForm = new CourseForm();
            courseForm.FormClosed += MainMenu_FormClosed;
            courseForm.ShowDialog();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();

            Application.Exit();

        }
    }
}
