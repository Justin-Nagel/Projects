using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project1_PRG282.LogicLayer;
using Project1_PRG282.DataAccess;

namespace Project1_PRG282
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void pnlLogInContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!txtUsername.Text.Equals("") && !txtPassword.Text.Equals(""))
            {

                User user = new User(txtUsername.Text, txtPassword.Text);

                if (DataHandler.userExist(user))
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User does not exist");
                }
            }
            else
            {
                MessageBox.Show("Please enter username and password");
            }
          
        }

    }
}
