using Project1_PRG282.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Project1_PRG282.LogicLayer;
using System.Reflection;
using System.IO;
using System.Collections;

namespace Project1_PRG282
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            lblCreate.MouseHover += lblCreate_MouseHover;
            lblCreate.MouseLeave += lblCreate_MouseLeave;
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }


        private void lblCreate_Click(object sender, EventArgs e)
        {

            lblUpdate.Text = "Cancel";
            lblCreate.Enabled = false;
            lblDelete.Enabled = false;
            lblCreate.Visible = false;
            lblDelete.Visible = false;

            btnAction.Text = "Create";

            txtAdress.Enabled = true;
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtSearch.Enabled = true;
            txtSurname.Enabled = true;
            Date.Enabled = true;
            gbGender.Enabled = true;
            pbxStudent.Enabled = true;

            btnAction.Visible = true;
            txtAdress.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
            txtSurname.Text = "";
            lblStudentNr.Text = "-";
            rtbxCourseCodes.Text = "Module Codes:";
            rbMale.Checked = true;
            cbxCourseCodes.Visible = true;
            btnAddCourseCodes.Visible = true;
            btnDeleteCourseCodes.Visible = true;
            txtName.Focus();

            
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            //This is for the DataGridView
            dgvStudent.DataSource = DataHandler.showStudentData();

            //This is for the List View
            foreach (DataRow row in DataHandler.showStudentData().Rows)
            {
                ListViewItem item = new ListViewItem(row["StudentNumber"].ToString());
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["Surname"].ToString());
                item.SubItems.Add(row["DOB"].ToString());
                item.SubItems.Add(row["Gender"].ToString());
                item.SubItems.Add(row["Phone"].ToString());
                item.SubItems.Add(row["Address"].ToString());
                lvStudent.Items.Add(item);
            }

            // Inside the form or wherever you want to populate the ComboBox
            cbxCourseCodes.Items.Clear(); // Clear existing items, if any

            // Call the showModuleData method to get the DataTable
            DataTable moduleData = DataHandler.showModuleData();

            // Iterate through the rows and add module codes to the ComboBox
            foreach (DataRow row in moduleData.Rows)
            {
                cbxCourseCodes.Items.Add(row["ModuleCode"].ToString());
            }



        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {

            if (btnAction.Text.Equals("--"))
            {
                lblUpdate.Text = "Cancel";
                lblCreate.Enabled = false;
                lblDelete.Enabled = false;
                lblCreate.Visible = false;
                lblDelete.Visible = false;

                btnAction.Text = "Update";
                btnAction.Visible = true;

                txtAdress.Enabled = true;
                txtName.Enabled = true;
                txtPhone.Enabled = true;
                txtSearch.Enabled = true;
                txtSurname.Enabled = true;
                Date.Enabled = true;
                gbGender.Enabled = true;
                pbxStudent.Enabled = true;
                cbxCourseCodes.Visible = true;
                btnAddCourseCodes.Visible = true;
                btnDeleteCourseCodes.Visible = true;

            }
            else if (lblUpdate.Text.Equals("Cancel"))
            {
                lblUpdate.Text = "Update";
                lblCreate.Enabled = true;
                lblDelete.Enabled = true;
                lblCreate.Visible = true;
                lblDelete.Visible = true;
                btnAction.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAddCourseCodes.Visible = false;
                btnDeleteCourseCodes.Visible = false;
                btnAction.Text = "--";

                txtAdress.Enabled = false;
                txtName.Enabled = false;
                txtPhone.Enabled = false;
                txtSurname.Enabled = false;
                Date.Enabled = false;
                gbGender.Enabled = false;
                pbxStudent.Enabled = false;
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {

            lblUpdate.Text = "Cancel";
            lblCreate.Enabled = false;
            lblDelete.Enabled = false;
            lblCreate.Visible = false;
            lblDelete.Visible = false;

            btnAction.Visible = true;
            btnAction.Text = "Delete";

        }

        private void pbxHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (dgvStudent.Rows.Count > 0)
            //{
            //    dgvStudent.ClearSelection();
            //    dgvStudent.Rows[0].Selected = true;

            //}
            int desiredRowIndex = 0; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //if (dgvStudent.Rows.Count > 0)
            //{
            //    currentRowIndex--;
            //    if (currentRowIndex < 0)
            //    {
            //        currentRowIndex = dgvStudent.Rows.Count - 1;
            //    }
            //    dgvStudent.ClearSelection();
            //    dgvStudent.Rows[currentRowIndex].Selected = true;
            //}
            int desiredRowIndex = dgvStudent.CurrentRow.Index - 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (currentRowIndex < dgvStudent.Rows.Count - 1)
            //{
            //    currentRowIndex++;
            //    dgvStudent.ClearSelection();
            //    dgvStudent.Rows[currentRowIndex].Selected = true;
            //}
            //else
            //{
            //    currentRowIndex = 0; // Must try and alter this so when going next from last row, it goes to first row (it goes to second row if clicked twice when at last row)
            //}

            int desiredRowIndex = dgvStudent.CurrentRow.Index + 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count - 1)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //if (dgvStudent.Rows.Count > 0)
            //{
            //    dgvStudent.ClearSelection();

            //    int lastIndex = dgvStudent.Rows.Count - 1;
            //    dgvStudent.Rows[lastIndex].Selected = true;

            //}
            int desiredRowIndex = dgvStudent.RowCount - 2; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void lvStudent_MouseClick(object sender, MouseEventArgs e)
        {
            //txtName.Text = lvStudent.SelectedItems[0].SubItems[1].Text;
            //txtSurname.Text = lvStudent.SelectedItems[0].SubItems[2].Text;
            //txtPhone.Text = lvStudent.SelectedItems[0].SubItems[6].Text;
            //txtAdress.Text = lvStudent.SelectedItems[0].SubItems[7].Text;
            //if (lvStudent.SelectedItems[0].SubItems[5].Text == "Male")
            //{
            //    rbMale.Checked = true;
            //}
            //else
            //{
            //    rbFemale.Checked = true;
            //}

            int desiredRowIndex = lvStudent.SelectedIndices[0]; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {


            Student student = new Student();//creates a new instance of Student

            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            student.Phone = txtPhone.Text;
            student.Address = txtAdress.Text;
            student.DOB1 = Date.Value;
            //sets the values of the inputed data to the propertis of student

            if (rbFemale.Checked)
            {
                student.Gender = "Female"; //checks if female was chosen
            }
            else
            {
                student.Gender = "Male"; //checks if male was chosen
            }

            student.StudentImage = pbxStudent.Image;

            //string filePath = DataHandler.createPermanentFilePath("StudentImages");


            //// Optionally, you can check if the file exists
            //if (!File.Exists(filePath))
            //{
            //    File.Create(filePath).Close();
            //}
            //else
            //{
            //    // Get the image from pbxStudent
            //    Image image = pbxStudent.Image as Image;

            //    // Save the image to the file path
            //    if (image != null)
            //    {
            //        image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        Console.WriteLine("Image saved successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("pbxStudent.Image is not an Image object.");
            //    }
            //}





            if (btnAction.Text == "Create")
            {
                try
                {
                    DataHandler.createStudent(student);//if the button had text of Create it will call the function createStudent
                    List<string> modules = new List<string>();

                    string[] lines = rtbxCourseCodes.Text.Split('\n');

                    foreach (string line in lines)
                    {
                        string trimmedLine = line.Trim(); // Trim to remove leading or trailing spaces
                        if (!string.IsNullOrEmpty(trimmedLine) && trimmedLine != "Module Codes:")
                        {
                            modules.Add(trimmedLine);
                        }
                    }
                    DataHandler.deleteStudentModules(DataHandler.GetLastStudentNumber());
                    DataHandler.addStudentModules(modules, DataHandler.GetLastStudentNumber());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//an error will show if the student could not be created
                }
            }
            else if (btnAction.Text == "Update")
            {
                try
                {
                    student.Studentnumber=int.Parse(lblStudentNr.Text);

                    DataHandler.updateStudent(student);//if the button had text of Update it will call the function updateStudent
                    List<string> modules = new List<string>();

                    string[] lines = rtbxCourseCodes.Text.Split('\n');

                    foreach (string line in lines)
                    {
                        string trimmedLine = line.Trim(); // Trim to remove leading or trailing spaces
                        if (!string.IsNullOrEmpty(trimmedLine) && trimmedLine != "Module Codes:")
                        {
                            modules.Add(trimmedLine);
                        }
                    }
                    DataHandler.deleteStudentModules(DataHandler.GetLastStudentNumber());
                    DataHandler.addStudentModules(modules, DataHandler.GetLastStudentNumber());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);// an error will show if the student could not be Updated
                }
            }
            else if (btnAction.Text == "Delete")
            {
                int studentNumber = int.Parse(lblStudentNr.Text);

                DataHandler.DeleteStudent(studentNumber);//if the button had text of Delete it will call the function deleteStudent
            }

            dgvStudent.DataSource = null;
            dgvStudent.DataBindings.Clear();
            dgvStudent.DataSource = DataHandler.showStudentData();//fills the datagridview with the new updated table

            // Clear any previous cell highlighting
            dgvStudent.ClearSelection();

            // Clear any previous highlighting
            foreach (ListViewItem item in lvStudent.Items)
            {
                item.BackColor = SystemColors.Window;
                item.ForeColor = SystemColors.WindowText;
            }

        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow row = this.dgvStudent.Rows[e.RowIndex];

            //    txtName.Text = row.Cells["Name"].Value.ToString();
            //    txtSurname.Text = row.Cells["Surname"].Value.ToString();
            //    txtPhone.Text = row.Cells["Phone"].Value.ToString();
            //    txtAdress.Text = row.Cells["Address"].Value.ToString();
            //    rtbxCourseCodes.Text = row.Cells["ModuleCode"].Value.ToString();
            //}
        }

        private void dgvStudent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < lvStudent.Items.Count)
            {

                DataGridViewRow row = this.dgvStudent.Rows[e.RowIndex];

                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAdress.Text = row.Cells["Address"].Value.ToString();
                //rtbxCourseCodes.Text = row.Cells["ModuleCode"].Value.ToString();
                Date.Value = DateTime.Parse(row.Cells["DOB"].Value.ToString());
                lblStudentNr.Text = row.Cells["StudentNumber"].Value.ToString();

                if (row.Cells["Gender"].Value.ToString().Equals("Female"))
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;
                }

                int studentNumber = int.Parse(lblStudentNr.Text);
                Image studentImage = DataHandler.GetStudentImage(studentNumber);

                if (studentImage != null)
                {
                    pbxStudent.Image = studentImage;
                }
                else
                {
                    pbxStudent.Image = Project1_PRG282.Properties.Resources.kisspng_logo_person_user_person_icon_5b4d2bd25185e8_0544055615317841463339;
                }


                rtbxCourseCodes.Clear();
                List<string> moduleCodes = DataHandler.GetModuleCodesForStudent(int.Parse(lblStudentNr.Text));
                rtbxCourseCodes.AppendText("Module Codes:" + Environment.NewLine);
                foreach (string moduleCode in moduleCodes)
                {
                    rtbxCourseCodes.AppendText(moduleCode + Environment.NewLine);
                }
            }
        }

        private void pbxStudent_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select an Image File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image into the PictureBox
                        pbxStudent.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lvStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            dgvStudent.DataSource = DataHandler.searchStudent(txtSearch.Text);

            lvStudent.Items.Clear();

            foreach (DataRow row in DataHandler.searchStudent(txtSearch.Text).Rows)
            {
                ListViewItem item = new ListViewItem(row["StudentNumber"].ToString());
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["Surname"].ToString());
                item.SubItems.Add(row["DOB"].ToString());
                item.SubItems.Add(row["Gender"].ToString());
                item.SubItems.Add(row["Phone"].ToString());
                item.SubItems.Add(row["Address"].ToString());
                lvStudent.Items.Add(item);
            }

            // Clear any previous cell highlighting
            dgvStudent.ClearSelection();

            // Clear any previous highlighting
            foreach (ListViewItem item in lvStudent.Items)
            {
                item.BackColor = SystemColors.Window;
                item.ForeColor = SystemColors.WindowText;
            }

            if (!txtSearch.Text.Equals(""))
            {
                // Iterate through each row in the DataGridView
                foreach (DataGridViewRow row in dgvStudent.Rows)
                {
                    // Iterate through each cell in the row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Check if the cell value contains the search term
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            // Highlight the cell
                            cell.Style.BackColor = Color.Yellow;
                            cell.Style.ForeColor = Color.Black; // Optionally, set text color
                        }
                    }
                }

                foreach (ListViewItem item in lvStudent.Items)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (subItem.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            subItem.BackColor = Color.Yellow;
                            subItem.ForeColor = Color.Black;
                        }
                        else
                        {
                            // Reset the background and text color for non-matching subitems
                            subItem.BackColor = lvStudent.BackColor;
                            subItem.ForeColor = lvStudent.ForeColor;
                        }
                    }
                }
            }




        }

        private void btnAddCourseCodes_Click(object sender, EventArgs e)
        {

            List<string> linesList = rtbxCourseCodes.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
            linesList.Add(cbxCourseCodes.Text);
            rtbxCourseCodes.Lines = linesList.ToArray(); ;
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {
            //int lastLineIndex = rtbxCourseCodes.Lines.Length - 1;

            //if (lastLineIndex >= 0)
            //{
            //    int lastLineStartPosition = rtbxCourseCodes.GetFirstCharIndexFromLine(lastLineIndex);
            //    int lastLineEndPosition = rtbxCourseCodes.GetFirstCharIndexFromLine(lastLineIndex + 1) - 1;

            //    rtbxCourseCodes.Select(lastLineStartPosition, lastLineEndPosition - lastLineStartPosition + 1);
            //    rtbxCourseCodes.SelectedText = string.Empty;
            //}
        }

        private void btnDeleteCourseCodes_Click(object sender, EventArgs e)
        {
            List<string> linesList = new List<string>(rtbxCourseCodes.Lines);
            if (linesList.Count > 0)
            {
                // Remove the last item (assuming you know the value)
                linesList.Remove(linesList.Last());
            }
            rtbxCourseCodes.Lines = linesList.ToArray();
        }

        private void lblCreate_MouseHover(object sender, EventArgs e)
        {
            lblCreate.ForeColor = Color.Blue;    
        }

        private void lblCreate_MouseLeave(object sender, EventArgs e)
        {
            lblCreate.ForeColor = SystemColors.ControlText;
        }

        private void lblUpdate_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void lblUpdate_MouseHover(object sender, EventArgs e)
        {
            lblUpdate.ForeColor = Color.Blue;
        }

        private void lblDelete_MouseHover(object sender, EventArgs e)
        {
            lblDelete.ForeColor = Color.Blue;
        }

        private void lblDelete_MouseLeave(object sender, EventArgs e)
        {
            lblDelete.ForeColor = SystemColors.ControlText;
        }

        private void lblCreate_ForeColorChanged(object sender, EventArgs e)
        {
            
        }

        private void lblCreate_BackColorChanged(object sender, EventArgs e)
        {
            lblCreate.BackColor = Color.Red;
        }

        private void lblUpdate_BackColorChanged(object sender, EventArgs e)
        {
            lblUpdate.BackColor = Color.Red;
        }

        private void lblDelete_BackColorChanged(object sender, EventArgs e)
        {
            lblDelete.BackColor = Color.Red;
        }

        private void lblSearch_MouseHover(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.Blue;
        }

        private void lblSearch_MouseLeave(object sender, EventArgs e)
        {
            lblSearch.ForeColor = SystemColors.ControlText;
        }

        private void lblUpdate_MouseLeave(object sender, EventArgs e)
        {
            lblUpdate.ForeColor = SystemColors.ControlText;
        }

        private void flowLayoutPanel2_BackColorChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.BackColor = Color.LightBlue;
        }

        private void flowLayoutPanel1_BackColorChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.LightBlue;
        }

        private void tableLayoutPanel8_BackColorChanged(object sender, EventArgs e)
        {
            tableLayoutPanel8.BackColor = Color.LightBlue;
        }

        private void btnAddCourseCodes_MouseHover(object sender, EventArgs e)
        {
            btnAddCourseCodes.ForeColor = Color.Blue;
        }

        private void btnAddCourseCodes_MouseLeave(object sender, EventArgs e)
        {
            btnAddCourseCodes.ForeColor = SystemColors.ControlText;
        }

        private void btnDeleteCourseCodes_MouseHover(object sender, EventArgs e)
        {
            btnDeleteCourseCodes.ForeColor = Color.Blue;
        }

        private void btnDeleteCourseCodes_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteCourseCodes.ForeColor = SystemColors.ControlText;
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            btnStart.ForeColor = Color.Blue;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.ForeColor = SystemColors.ControlText;
        }

        private void btnStart_BackColorChanged(object sender, EventArgs e)
        {
            lblDelete.BackColor = Color.Yellow;
        }

        private void btnPrevious_MouseHover(object sender, EventArgs e)
        {
            btnPrevious.ForeColor = Color.Blue;
        }

        private void btnPrevious_MouseLeave(object sender, EventArgs e)
        {
            btnPrevious.ForeColor = SystemColors.ControlText;
        }

        private void btnPrevious_BackColorChanged(object sender, EventArgs e)
        {
            btnPrevious.BackColor = Color.Yellow;
        }

        private void btnAction_MouseHover(object sender, EventArgs e)
        {
            btnAction.ForeColor = Color.Blue;
        }

        private void btnAction_MouseLeave(object sender, EventArgs e)
        {
            btnAction.ForeColor = SystemColors.ControlText;
        }

        private void btnAction_BackColorChanged(object sender, EventArgs e)
        {
            btnAction.BackColor = Color.Yellow;
        }

        private void btnNext_MouseHover(object sender, EventArgs e)
        {
            btnNext.ForeColor = Color.Blue;
        }
    

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
        btnNext.ForeColor = SystemColors.ControlText;
        }

        private void btnNext_BackColorChanged(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.Yellow;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Blue;    
        }
    

        private void button2_MouseLeave(object sender, EventArgs e)
        {
        button2.ForeColor = SystemColors.ControlText;
        }

        private void button2_BackColorChanged(object sender, EventArgs e)
        {
        button2.BackColor = Color.Yellow;
        }
    }
}
