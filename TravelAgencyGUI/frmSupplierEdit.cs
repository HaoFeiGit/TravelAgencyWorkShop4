using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TravelAgencyData;

namespace TravelAgencyGUI
{
    public partial class frmSupplierEdit : Form
    {
        public Suppliers supplier;
        public SupplierContacts supplierContacts;
        public bool isAdd;
        public int newSupplierID;
        public frmSupplierEdit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierEdit_Load(object sender, EventArgs e)
        {
            if (this.isAdd) // isadd = true means
            {
                this.Text = "Add Supplier"; //form title            
            }
            else // Modify button clicked
            {
                //load object data from main form
                this.Text = "Modify Supplier"; //form title
                txtSupName.Text = supplier.SupName;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //if (Validator.IsPresent(txtSupName, "Supplier Name")
            //{
                if (isAdd) 
                {
                        //make new product object
                    supplier = new Suppliers();
                    supplier.SupplierId = newSupplierID; //assign new id to new supplier

                };
                // else do nothing and use current object

                // prepare data to be sent back to main form
                supplier.SupName = txtSupName.Text;
                    
                this.DialogResult = DialogResult.OK; //returns ok
            //}
        }
    }
}
