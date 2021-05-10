using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelAgencyData;

namespace TravelAgencyGUI
{
    // C# Workshop 4
    // Add or Modify Package Section
    // (c) Vasily Petrashkevich, SAIT, May 2021
    public partial class frmPackageEdit : Form
    {
        // these public properties are set by the main form
        public Packages package { get; set; } // selected Package on the main form
        public bool AddPackage { get; set; } // flag that distinguishes Add Package from Modify Package
        public int newPkgId; //id for the new package if created
        private TravelExpertsContext context = new TravelExpertsContext(); //context for working with the SQL database
        private PackagesProductsSuppliers selectedPPS; //product-package-supplier record selected for addition/removal from the current package

        public frmPackageEdit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackageEdit_Load(object sender, EventArgs e)
        {
            // displaying all available package+product combinations in a gridview
            this.DisplayAllProducts();
            if (AddPackage) // this is Add
            {
                this.Text = "Add Package";
            }
            else // this is Modify
            {
                this.Text = "Modify Package";
                // fill text inputs with the data for selected package
                txtPackName.Text = package.PkgName;
                dtpStart.Value = (DateTime)package.PkgStartDate;
                dtpEnd.Value = (DateTime)package.PkgEndDate;
                txtPackDesc.Text = package.PkgDesc;
                txtBasePrice.Text = package.PkgBasePrice.ToString("c");
                txtAgencyCom.Text = string.Format("{0:C}", package.PkgAgencyCommission);
                this.DisplayPackage();
            }
        }
        //Display Current Package Data
        private void DisplayPackage() 
        {
            // clears old content
            dgvPkgContents.Columns.Clear();
            // select all the product+supplier pairs for the given package id
            var data = (from pps in context.PackagesProductsSuppliers
                       join ps in context.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                       join p in context.Products on ps.ProductId equals p.ProductId
                       join s in context.Suppliers on ps.SupplierId equals s.SupplierId
                       where pps.PackageId == package.PackageId
                       orderby ps.ProductSupplierId
                       select new
                       { id=ps.ProductSupplierId, ProductName = p.ProdName, SupplierName = s.SupName }).ToList();
            //display the product+supplier pairs in the datagrid
            dgvPkgContents.DataSource = data;
            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Width=150,
                Text = "Remove from Package"
            };
            dgvPkgContents.Columns.Add(deleteColumn);

            // format the column header
            dgvPkgContents.EnableHeadersVisualStyles = false;
            dgvPkgContents.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvPkgContents.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod; // Golden background on headers
            dgvPkgContents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // text on headers

            // format the odd numbered rows
            dgvPkgContents.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvPkgContents.Columns[0].HeaderText = "Id";
            dgvPkgContents.Columns[0].Width = 30;

            // format the second column
            dgvPkgContents.Columns[1].HeaderText = "Product";
            dgvPkgContents.Columns[1].Width = 110;

            // format the third column
            dgvPkgContents.Columns[2].HeaderText = "Supplier";
            dgvPkgContents.Columns[2].Width = 190;
        }

        //display all available product+supplier combinations in dataview grid
        private void DisplayAllProducts()
        {
            // clears old content
            dgvAllProducts.Columns.Clear();
            // select all the product+supplier pairs from the database
            var AllProducts = (from ps in context.ProductsSuppliers
                               join p in context.Products on ps.ProductId equals p.ProductId
                               join s in context.Suppliers on ps.SupplierId equals s.SupplierId
                               orderby ps.ProductSupplierId
                               select new
                               { id = ps.ProductSupplierId, ProductName = p.ProdName, SupplierName = s.SupName }).ToList();
            dgvAllProducts.DataSource = AllProducts;
            // add column for Add button
            var addColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Width = 130,
                Text = "Add to Package"
            };
            dgvAllProducts.Columns.Add(addColumn);

            // format the column header
            dgvAllProducts.EnableHeadersVisualStyles = false;
            dgvAllProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvAllProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod; // Golden background on headers
            dgvAllProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // text on headers

            // format the odd numbered rows
            dgvAllProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvAllProducts.Columns[0].HeaderText = "Id";
            dgvAllProducts.Columns[0].Width = 30;

            // format the second column
            dgvAllProducts.Columns[1].HeaderText = "Product";
            dgvAllProducts.Columns[1].Width = 110;

            // format the third column
            dgvAllProducts.Columns[2].HeaderText = "Supplier";
            dgvAllProducts.Columns[2].Width = 190;

        }

        //Remove the product selected in dgvPkgContents 
        private void dgvPkgContents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verify that the button was clicked
            if (e.ColumnIndex == 3) //we know the button "Remove from Package" sits in Column 4
            {
                //get the ProductSupplierID of the combination selected
                int pairId = Int32.Parse(dgvPkgContents.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                //find the selected package+product+supplier combination 
                selectedPPS = context.PackagesProductsSuppliers.Find(package.PackageId, pairId); // find by PK value
            
            //remove the selected product+supplier combination from the current package
            try
                {
                    context.PackagesProductsSuppliers.Remove(selectedPPS);
                    context.SaveChanges();                 //save changes to the server
                    this.DisplayPackage();                      //reload the datagrid view for the current package to display the update
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
                //reload the package view datagrid
                this.DisplayPackage();
            }
        }

        //Add the product selected in dgvAllProducts into the current package
        private void dgvAllProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verify that the button was clicked
            if (e.ColumnIndex == 3) //we know the button "Add to Package" sits in Column 4
            {   //get the ProductSupplierID of the combination selected from All
                int pairId = Int32.Parse(dgvAllProducts.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                //add the seleced into the current package
                try
                {
                    //add the selected product+supplier pair to the current package
                    selectedPPS = new PackagesProductsSuppliers(); //creating a new ackage-product-supplier bject
                    selectedPPS.PackageId = package.PackageId;     // assign the PackageId
                    selectedPPS.ProductSupplierId = pairId;        // assign the product-supplier pair Id
                    context.PackagesProductsSuppliers.Add(selectedPPS);
                    context.SaveChanges();                 //save changes to the server
                    this.DisplayPackage();                      //reload the datagrid view for the current package to display the update
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
                //reload the package view datagrid
                this.DisplayPackage();
            }
        }
        //Accept button hit: save changes into the database and close the form
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AddPackage) //this is adding a new package
            {
                //create new package object
                package = new Packages();
                //assign new id to the package object
                package.PackageId = newPkgId;
            };
            //else modifying the existing package object
            
                //fill the entered data into the package object
                package.PkgName = txtPackName.Text;
                package.PkgStartDate = dtpStart.Value;
                package.PkgEndDate = dtpEnd.Value;
                package.PkgDesc = txtPackDesc.Text;
                package.PkgBasePrice= Convert.ToInt32(txtBasePrice.Text);
                package.PkgAgencyCommission = Convert.ToInt32(txtAgencyCom);
   
                //return Ok
                this.DialogResult = DialogResult.OK; 

        }
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            // check if product code is provided
            errorMessage += TravelAgencyGUI.ValidateHao.IsPresent(txtPackName, txtPackName.Tag.ToString());
            // check if product name is provided
            errorMessage += TravelAgencyGUI.ValidateHao.IsPresent(txtPackDesc, txtPackDesc.Tag.ToString());
            // check if product version is provided
            errorMessage += TravelAgencyGUI.ValidateHao.IsPresent(txtBasePrice, txtBasePrice.Tag.ToString());
            // check if product version is decimal
            errorMessage += TravelAgencyGUI.ValidateHao.IsNonNegDecimal(txtBasePrice, txtBasePrice.Tag.ToString());
            // check if the date is not in the past - this didn't work for some strange reason
            //errorMessage += TravelAgencyGUI.ValidateHao.IsValidDate(dtpStart.Text, txtReleaseDate.Tag.ToString());
            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }
        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedPPS).State;
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

    }
}
