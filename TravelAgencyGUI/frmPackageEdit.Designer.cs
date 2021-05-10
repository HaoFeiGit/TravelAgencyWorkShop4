
namespace TravelAgencyGUI
{
    partial class frmPackageEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPackName = new System.Windows.Forms.TextBox();
            this.txtPackDesc = new System.Windows.Forms.TextBox();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.txtAgencyCom = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.Product_Supplier = new System.Windows.Forms.GroupBox();
            this.dgvPkgContents = new System.Windows.Forms.DataGridView();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAllProducts = new System.Windows.Forms.DataGridView();
            this.Product_Supplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPkgContents)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Package Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Base Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Agency Commission";
            // 
            // txtPackName
            // 
            this.txtPackName.BackColor = System.Drawing.Color.White;
            this.txtPackName.Location = new System.Drawing.Point(225, 85);
            this.txtPackName.Name = "txtPackName";
            this.txtPackName.Size = new System.Drawing.Size(253, 25);
            this.txtPackName.TabIndex = 6;
            // 
            // txtPackDesc
            // 
            this.txtPackDesc.BackColor = System.Drawing.Color.White;
            this.txtPackDesc.Location = new System.Drawing.Point(225, 289);
            this.txtPackDesc.Name = "txtPackDesc";
            this.txtPackDesc.Size = new System.Drawing.Size(253, 25);
            this.txtPackDesc.TabIndex = 7;
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.BackColor = System.Drawing.Color.White;
            this.txtBasePrice.Location = new System.Drawing.Point(225, 359);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.Size = new System.Drawing.Size(253, 25);
            this.txtBasePrice.TabIndex = 8;
            // 
            // txtAgencyCom
            // 
            this.txtAgencyCom.BackColor = System.Drawing.Color.White;
            this.txtAgencyCom.Location = new System.Drawing.Point(225, 421);
            this.txtAgencyCom.Name = "txtAgencyCom";
            this.txtAgencyCom.Size = new System.Drawing.Size(253, 25);
            this.txtAgencyCom.TabIndex = 9;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(225, 148);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(253, 25);
            this.dtpStart.TabIndex = 10;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(225, 216);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(253, 25);
            this.dtpEnd.TabIndex = 11;
            // 
            // Product_Supplier
            // 
            this.Product_Supplier.Controls.Add(this.dgvPkgContents);
            this.Product_Supplier.Location = new System.Drawing.Point(517, 55);
            this.Product_Supplier.Name = "Product_Supplier";
            this.Product_Supplier.Size = new System.Drawing.Size(587, 212);
            this.Product_Supplier.TabIndex = 12;
            this.Product_Supplier.TabStop = false;
            this.Product_Supplier.Text = "Products in the Package";
            // 
            // dgvPkgContents
            // 
            this.dgvPkgContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPkgContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPkgContents.Location = new System.Drawing.Point(3, 21);
            this.dgvPkgContents.Name = "dgvPkgContents";
            this.dgvPkgContents.RowTemplate.Height = 25;
            this.dgvPkgContents.Size = new System.Drawing.Size(581, 188);
            this.dgvPkgContents.TabIndex = 15;
            this.dgvPkgContents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPkgContents_CellClick);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(401, 555);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 36);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(636, 555);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 36);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAllProducts);
            this.groupBox1.Location = new System.Drawing.Point(514, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 212);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Available Products";
            // 
            // dgvAllProducts
            // 
            this.dgvAllProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllProducts.Location = new System.Drawing.Point(3, 21);
            this.dgvAllProducts.Name = "dgvAllProducts";
            this.dgvAllProducts.RowTemplate.Height = 25;
            this.dgvAllProducts.Size = new System.Drawing.Size(585, 188);
            this.dgvAllProducts.TabIndex = 15;
            this.dgvAllProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllProducts_CellClick);
            // 
            // frmPackageEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.Product_Supplier);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtAgencyCom);
            this.Controls.Add(this.txtBasePrice);
            this.Controls.Add(this.txtPackDesc);
            this.Controls.Add(this.txtPackName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmPackageEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base Price";
            this.Load += new System.EventHandler(this.frmPackageEdit_Load);
            this.Product_Supplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPkgContents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPackName;
        private System.Windows.Forms.TextBox txtPackDesc;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.TextBox txtAgencyCom;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox Product_Supplier;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvPkgContents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAllProducts;
    }
}