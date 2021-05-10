using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelAgencyData;

namespace TravelAgencyGUI
{
    public partial class frmPackageTable : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext();
        private Packages selectedPackage;
        public int newPackageId;
        public frmPackageTable()
        {
            InitializeComponent();
        }

        // upon loading the main window, load the dgv
        private void frmPackageTable_Load(object sender, EventArgs e)
        {
            DisplayPackage(); // load the dgv
        }

        private void DisplayPackage()
        {
            dgvPackages.Columns.Clear(); // clears old content
            var packages = context.Packages  // retrieve products data
                .OrderBy(p => p.PkgName) // ordered by description alphabetically
                .Select(p => new { p.PackageId, p.PkgName, p.PkgStartDate, p.PkgEndDate, p.PkgDesc, 
                                   p.PkgBasePrice, p.PkgAgencyCommission})
                .ToList();
            dgvPackages.DataSource = packages;

            // add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvPackages.Columns.Add(modifyColumn);

            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvPackages.Columns.Add(deleteColumn);

            // format the column header
            dgvPackages.EnableHeadersVisualStyles = false;
            dgvPackages.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod; // Golden background on headers
            dgvPackages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // text on headers

            // format the odd numbered rows
            dgvPackages.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvPackages.Columns[0].HeaderText = "Package Id";
            dgvPackages.Columns[0].Width = 80;


            // format the second column
            dgvPackages.Columns[1].HeaderText = "Package Name";
            dgvPackages.Columns[1].Width = 150;

            // format the third column
            dgvPackages.Columns[2].HeaderText = "Start Date";

            // format the fourth column
            dgvPackages.Columns[3].HeaderText = "End Date";

            // format the fifth column
            dgvPackages.Columns[4].HeaderText = "Description";
            dgvPackages.Columns[4].Width = 300;

            // format the sixth column
            dgvPackages.Columns[5].HeaderText = "Base Price";
            dgvPackages.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPackages.Columns[5].DefaultCellStyle.Format = "c";
            dgvPackages.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // format the seven column
            dgvPackages.Columns[6].HeaderText = "Commission";
            dgvPackages.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPackages.Columns[6].DefaultCellStyle.Format = "c";
            dgvPackages.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dgvPackages_CellClick(object sender, DataGridViewCellEventArgs e)
            // e object carriers information about the click
            // like e.ColumnIndex and e.RowIndex
        {
            // store index values for Modify and Delete button columns
            const int ModifyIndex = 7; // Modify buttons are column index 3
            const int DeleteIndex = 8; // Delete buttons are column index 4

            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex) // is it a button?
            {
                // get the product code:
                // grid view has property (collection) Rows and Columns
                // product code is cell number 0 in the current row
                // need to trim white spaces from char(10) column
                int packageId = Int32.Parse(dgvPackages.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                selectedPackage = context.Packages.Find(packageId); // find by PK value
            }

            if (e.ColumnIndex == ModifyIndex)
            {
                ModifyPackage();
            }
            else if (e.ColumnIndex == DeleteIndex)
            {
                DeletePackage();
            }
        }
        // procedure to modify the package
        private void ModifyPackage()
        {
            //Open AddModify Package form
            var packEditForm = new frmPackageEdit()
            {
                AddPackage = false, // this is Modify
                package = selectedPackage // pass selected package object into child form
            };
            //packEditForm.Show();
            DialogResult result = packEditForm.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    selectedPackage = packEditForm.package; // modify data
                    context.SaveChanges();                  // save changes to the server
                    DisplayPackage();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void DeletePackage()
        {
            DialogResult result = MessageBox.Show($"Do you want to delete {selectedPackage.PkgName}?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)// user confirmed the deletion
            {
                try
                {
                    context.Packages.Remove(selectedPackage); //remove the package from the table Packages
                    //remove the package from the table PackagesSuppliersProducts

                    context.SaveChanges(true);
                    DisplayPackage();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }

        }
        // Add a new package button clicked
        private void btnAddPack_Click(object sender, EventArgs e)
        {
            //Open AddModify Package form
            var packEditForm = new frmPackageEdit()
            {
                AddPackage = true, // this is Add
                package = null,  //do not pass in
                //generate new id +1 from the last row value
                newPkgId = Int32.Parse(dgvPackages.Rows[dgvPackages.RowCount - 1].Cells[0].Value.ToString().Trim()) + 1
            };
            //packEditForm.Show();
            DialogResult result = packEditForm.ShowDialog();
            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    selectedPackage = packEditForm.package;// record package received back from the AddModify form
                    context.Packages.Add(selectedPackage); //add the new package to database
                    context.SaveChanges();                 //save changes to the server
                    DisplayPackage();
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }
        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedPackage).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that package.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that package.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayPackage();
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE:  " + error.Number + " " +
                                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            frmProductTable prodTableForm = new frmProductTable();
            prodTableForm.Show();
        }

        private void btnManageSuppliers_Click(object sender, EventArgs e)
        {
            frmSupplierTable supTableForm = new frmSupplierTable();
            supTableForm.Show();
        }


        private bool ValidCommission(TextBox basePrice, TextBox commission)
        {
            bool isValid = true;
            if (Decimal.Parse(commission.Text) > Decimal.Parse(basePrice.Text))
            {
                MessageBox.Show("Commission cannot be greater than base price");
                return false;
            }
            else
                return isValid;
        }


    }
}
