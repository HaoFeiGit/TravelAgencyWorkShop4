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
    public partial class frmSupplierTable : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext();
        private Suppliers selectedSupplier;
        public frmSupplierTable()
        {
            InitializeComponent();
        }



        private void frmSupplierTable_Load(object sender, EventArgs e)
        {
            DisplaySupplier();
        }

        private void DisplaySupplier()
        {
            dgvSuppliers.Columns.Clear(); // clears old content
            var suppliers = context.Suppliers // retrieve products data
                .Select(s => new { s.SupplierId, s.SupName })
                .ToList();

            dgvSuppliers.DataSource = suppliers;

            // add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvSuppliers.Columns.Add(modifyColumn);

            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvSuppliers.Columns.Add(deleteColumn);

            // format the column header
            dgvSuppliers.EnableHeadersVisualStyles = false;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod; // Golden background on headers
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // text on headers

            // format the odd numbered rows
            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvSuppliers.Columns[0].HeaderText = "Supplier Id";

            // format the second column
            dgvSuppliers.Columns[1].HeaderText = "Supplier Name";
            dgvSuppliers.Columns[1].Width = 250;
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
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
                int supplierId = Int32.Parse(dgvSuppliers.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                selectedSupplier = context.Suppliers.Find(supplierId); // find by PK value
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
            frmSupplierEdit supEditForm = new frmSupplierEdit();
            supEditForm.Show();
        }

        private void DeleteProduct()
        {
            DialogResult result = MessageBox.Show($"Do you want to delete {selectedSupplier.SupName}?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplierEdit supEditForm = new frmSupplierEdit();
            supEditForm.Show();
        }

        private void btnToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
