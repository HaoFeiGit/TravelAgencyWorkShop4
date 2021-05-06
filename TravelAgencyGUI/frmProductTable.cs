using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravelAgencyData;

namespace TravelAgencyGUI
{
    public partial class frmProductTable : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext();
        private Products selectedProduct;
        public frmProductTable()
        {
            InitializeComponent();
        }

        private void frmProductTable_Load(object sender, EventArgs e)
        {
            DisplayProduct();
        }

        private void DisplayProduct()
        {
            dgvProducts.Columns.Clear(); // clears old content
            var products = context.Products // retrieve products data
                .Select(p => new { p.ProductId, p.ProdName})
                .ToList();  

            dgvProducts.DataSource = products;

            // add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvProducts.Columns.Add(modifyColumn);

            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvProducts.Columns.Add(deleteColumn);

            // format the column header
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod; // Golden background on headers
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // text on headers

            // format the odd numbered rows
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvProducts.Columns[0].HeaderText = "Product Id";

            // format the second column
            dgvProducts.Columns[1].HeaderText = "Product Name";
            dgvProducts.Columns[1].Width = 250;
        }

        private void btnToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        // e object carriers information about the click
        // like e.ColumnIndex and e.RowIndex
        {
            // store index values for Modify and Delete button columns
            const int ModifyIndex = 2; // Modify buttons are column index 3
            const int DeleteIndex = 3; // Delete buttons are column index 4

            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex) // is it a button?
            {
                // get the product code:
                // grid view has property (collection) Rows and Columns
                // product code is cell number 0 in the current row
                // need to trim white spaces from char(10) column
                int productId = Int32.Parse(dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                selectedProduct = context.Products.Find(productId); // find by PK value
            }

            if (e.ColumnIndex == ModifyIndex)
            {
                ModifyProduct();
            }
            else if (e.ColumnIndex == DeleteIndex)
            {
                DeleteProduct();
            }
        }

        private void ModifyProduct()
        {
            frmProductEdit prodEditForm = new frmProductEdit();
            prodEditForm.Show();
        }

        private void DeleteProduct()
        {
            //context.Products.Remove(selectedProduct);
            //context.SaveChanges();
            DialogResult result = MessageBox.Show($"Do you want to delete {selectedProduct.ProdName}?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            frmProductEdit prodEditForm = new frmProductEdit();
            prodEditForm.Show();
        }
    }
}
