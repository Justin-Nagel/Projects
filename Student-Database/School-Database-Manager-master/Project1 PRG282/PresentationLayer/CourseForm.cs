using Project1_PRG282.DataAccess;

using Project1_PRG282.LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project1_PRG282
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
            lblCreate.MouseHover += lblCreate_MouseHover;
            lblCreate.MouseLeave += lblCreate_MouseLeave;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_MouseHover(object sender, EventArgs e)
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

            txtModuleCode.Enabled = true;
            txtModuleName.Enabled = true;
            rtbxCourseDescription.Enabled = true;
            rtbxYoutubeLinks.Enabled = true;
            txtSearch.Enabled = true;
            

            btnAction.Visible = true;
            txtModuleCode.Text = "";
            txtModuleName.Text = "";
            rtbxCourseDescription.Text = "";
            txtSearch.Text = "";
            rtbxYoutubeLinks.Text = "";
            txtModuleCode.Focus();
        }

        int updateCounter = 0;
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            if (btnAction.Text.Equals("--"))
            {
                lblUpdate.Text = "Cancel";
                lblCreate.Enabled = false;
                lblDelete.Enabled = false;
                lblCreate.Visible = false;
                lblDelete.Visible = false;
                btnAction.Visible = true;


                btnAction.Text = "Update";

                txtModuleCode.Enabled = true;
                txtModuleName.Enabled = true;
                rtbxCourseDescription.Enabled = true;
                rtbxYoutubeLinks.Enabled = true;
                txtSearch.Enabled = true;

            }
            else if (lblUpdate.Text.Equals("Cancel"))
            {
                lblUpdate.Text = "Update";
                lblCreate.Enabled = true;
                lblDelete.Enabled = true;
                lblCreate.Visible = true;
                lblDelete.Visible = true;
                btnAction.Visible = false;
                

                btnAction.Text = "--";
                txtModuleCode.Enabled = false;
                txtModuleName.Enabled = false;
                rtbxCourseDescription.Enabled = false;
                rtbxYoutubeLinks.Enabled = false;


                btnAction.Visible = false;
                txtModuleCode.Focus();

            }

            
        }

        int deleteCounter = 0;
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

        private void CourseForm_Load(object sender, EventArgs e)
        {
            
            //This is for the DataGridView
            dgvModule.DataSource = DataHandler.showModuleData();

            //This is for the list view
            foreach (DataRow row in DataHandler.showModuleData().Rows)
            {
                ListViewItem item = new ListViewItem(row["ModuleCode"].ToString());
                item.SubItems.Add(row["ModuleName"].ToString());
                item.SubItems.Add(row["ModuleDescription"].ToString());
                item.SubItems.Add(row["Links"].ToString());
                lvModule.Items.Add(item);
            }
        }

        private void CourseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        int currentRowIndex = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (dgvModule.Rows.Count > 0)
            //{
            //    dgvModule.ClearSelection();
            //    dgvModule.Rows[0].Selected = true;
            //}
            int desiredRowIndex = 0; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //if (dgvModule.Rows.Count > 0)
            //{
            //    currentRowIndex--;
            //    if (currentRowIndex < 0)
            //    {
            //        currentRowIndex = dgvModule.Rows.Count - 1;
            //    }
            //    dgvModule.ClearSelection();
            //    dgvModule.Rows[currentRowIndex].Selected = true;
            //}
            int desiredRowIndex = dgvModule.CurrentRow.Index - 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (currentRowIndex < dgvModule.Rows.Count - 1)
            //{
            //    currentRowIndex++;
            //    dgvModule.ClearSelection();
            //    dgvModule.Rows[currentRowIndex].Selected = true;
            //}
            //else
            //{
            //    currentRowIndex = 0; // Must try and alter this so when going next from last row, it goes to first row (it goes to second row if clicked twice when at last row)
            //}
            int desiredRowIndex = dgvModule.CurrentRow.Index + 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //if (dgvModule.Rows.Count > 0)
            //{
            //    dgvModule.ClearSelection();

            //    int lastIndex = dgvModule.Rows.Count - 1;
            //    dgvModule.Rows[lastIndex].Selected = true;

            //}
            int desiredRowIndex = dgvModule.RowCount-2; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void lvModule_MouseClick(object sender, MouseEventArgs e)
        {
            txtModuleCode.Text = lvModule.SelectedItems[0].SubItems[0].Text;
            txtModuleName.Text = lvModule.SelectedItems[0].SubItems[1].Text;
            rtbxCourseDescription.Text = lvModule.SelectedItems[0].SubItems[2].Text;


            int desiredRowIndex = lvModule.SelectedIndices[0]; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            Module module = new Module();//creates a new nstance of module
            module.ModuleCode = txtModuleCode.Text;
            module.ModuleName = txtModuleName.Text;
            module.ModuleDescription=rtbxCourseDescription.Text;
            module.Links=rtbxYoutubeLinks.Text;

            if (btnAction.Text == "Create")
            {
                try
                {
                    DataHandler.createModule(module);//if the button had text of Create it will call the function createModule

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"?????");//an error will show if the Module could not be created
                }
            }
            else if (btnAction.Text == "Update")
            {
                try
                {
                    DataHandler.updateModule(module);//if the button had text of Update it will call the function updateModule

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); ;// an error will show if the Module could not be Updated
                }
            }
            else if (btnAction.Text == "Delete")
            {
                string moduleCode = txtModuleCode.Text;

                DataHandler.deleteModule(moduleCode);//if the button had text of Delete it will call the function deleteModule
            }

            dgvModule.DataSource = DataHandler.showModuleData();

            // Clear any previous cell highlighting
            dgvModule.ClearSelection();

            // Clear any previous highlighting
            foreach (ListViewItem item in lvModule.Items)
            {
                item.BackColor = SystemColors.Window;
                item.ForeColor = SystemColors.WindowText;
            }
        }

        private void dgvModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

            //    txtModuleCode.Text = row.Cells["ModuleCode"].Value.ToString();
            //    txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
            //    rtbxCourseDescription.Text = row.Cells["ModuleDescription"].Value.ToString();
            //    rtbxYoutubeLinks.Text = row.Cells["Links"].Value.ToString();  
            //}
        }

        private void dgvModule_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex<dgvModule.RowCount-2)
            {

                DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

                txtModuleCode.Text = row.Cells["ModuleCode"].Value.ToString();
                txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
                rtbxCourseDescription.Text = row.Cells["ModuleDescription"].Value.ToString();
                rtbxYoutubeLinks.Text = row.Cells["Links"].Value.ToString();
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            dgvModule.DataSource = DataHandler.searchModule(txtSearch.Text);

            // Clear any previous cell highlighting
            dgvModule.ClearSelection();

            // Clear any previous highlighting
            foreach (ListViewItem item in lvModule.Items)
            {
                item.BackColor = SystemColors.Window;
                item.ForeColor = SystemColors.WindowText;
            }

            if (!txtSearch.Text.Equals(""))
            {
                // Iterate through each row in the DataGridView
                foreach (DataGridViewRow row in dgvModule.Rows)
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

                // Iterate through each ListViewItem
                foreach (ListViewItem item in lvModule.Items)
                {
                    // Iterate through each subitem in the ListViewItem
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        // Check if the subitem text contains the search term
                        if (subItem.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            // Highlight the subitem
                            subItem.BackColor = Color.Yellow;
                            subItem.ForeColor = Color.Black; // Optionally, set text color
                        }
                    }
                }
            }
       
        
        }

        private void lblCreate_MouseHover(object sender, EventArgs e)
        {
            lblCreate.ForeColor = Color.Blue;
        }

        private void lblCreate_MouseLeave(object sender, EventArgs e)
        {

            lblCreate.ForeColor = SystemColors.ControlText;
        }


        private void lblUpdate_MouseLeave(object sender, EventArgs e)
        {

            lblUpdate.ForeColor = SystemColors.ControlText;
        }

        private void lblDelete_MouseHover(object sender, EventArgs e)
        {
            lblDelete.ForeColor = Color.Blue;
        }

        private void lblDelete_MouseLeave(object sender, EventArgs e)
        {

            lblDelete.ForeColor = SystemColors.ControlText;
        }

        private void lblSearch_MouseHover(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.Blue;
        }

        private void lblSearch_MouseLeave(object sender, EventArgs e)
        {

            lblSearch.ForeColor = SystemColors.ControlText;
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            btnStart.ForeColor = Color.Blue;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {

            btnStart.ForeColor = SystemColors.ControlText;
        }

        private void btnPrevious_MouseHover(object sender, EventArgs e)
        {
            btnPrevious.ForeColor = Color.Blue;
        }

        private void btnPrevious_MouseLeave(object sender, EventArgs e)
        {

            btnPrevious.ForeColor = SystemColors.ControlText;
        }

        private void btnAction_MouseHover(object sender, EventArgs e)
        {
            btnAction.ForeColor = Color.Blue;
        }

        private void btnAction_MouseLeave(object sender, EventArgs e)
        {

            btnAction.ForeColor = SystemColors.ControlText;
        }

        private void btnNext_MouseHover(object sender, EventArgs e)
        {
            btnNext.ForeColor = Color.Blue;
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {

            btnNext.ForeColor = SystemColors.ControlText;
        }

        private void btnEnd_MouseHover(object sender, EventArgs e)
        {
            btnEnd.ForeColor = Color.Blue;
        }

        private void btnEnd_MouseLeave(object sender, EventArgs e)
        {

            btnEnd.ForeColor = SystemColors.ControlText;
        }

        private void lblUpdate_MouseHover(object sender, EventArgs e)
        {
            lblUpdate.ForeColor = Color.Blue;
        }
    }


}
