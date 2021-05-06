
namespace TravelAgencyGUI
{
    partial class frmPackageTable
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPackages = new System.Windows.Forms.DataGridView();
            this.btnAddPack = new System.Windows.Forms.Button();
            this.btnManageProduct = new System.Windows.Forms.Button();
            this.btnManageSuppliers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPackages
            // 
            this.dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackages.Location = new System.Drawing.Point(6, 24);
            this.dgvPackages.Name = "dgvPackages";
            this.dgvPackages.RowTemplate.Height = 25;
            this.dgvPackages.Size = new System.Drawing.Size(1193, 492);
            this.dgvPackages.TabIndex = 0;
            this.dgvPackages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackages_CellClick);
            // 
            // btnAddPack
            // 
            this.btnAddPack.Location = new System.Drawing.Point(53, 542);
            this.btnAddPack.Name = "btnAddPack";
            this.btnAddPack.Size = new System.Drawing.Size(143, 41);
            this.btnAddPack.TabIndex = 1;
            this.btnAddPack.Text = "&Add Package";
            this.btnAddPack.UseVisualStyleBackColor = true;
            this.btnAddPack.Click += new System.EventHandler(this.btnAddPack_Click);
            // 
            // btnManageProduct
            // 
            this.btnManageProduct.Location = new System.Drawing.Point(242, 542);
            this.btnManageProduct.Name = "btnManageProduct";
            this.btnManageProduct.Size = new System.Drawing.Size(143, 41);
            this.btnManageProduct.TabIndex = 2;
            this.btnManageProduct.Text = "Manage Product";
            this.btnManageProduct.UseVisualStyleBackColor = true;
            this.btnManageProduct.Click += new System.EventHandler(this.btnManageProduct_Click);
            // 
            // btnManageSuppliers
            // 
            this.btnManageSuppliers.Location = new System.Drawing.Point(431, 542);
            this.btnManageSuppliers.Name = "btnManageSuppliers";
            this.btnManageSuppliers.Size = new System.Drawing.Size(143, 41);
            this.btnManageSuppliers.TabIndex = 3;
            this.btnManageSuppliers.Text = "Manage Suppliers";
            this.btnManageSuppliers.UseVisualStyleBackColor = true;
            this.btnManageSuppliers.Click += new System.EventHandler(this.btnManageSuppliers_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(634, 542);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 41);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmPackageTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 624);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnManageSuppliers);
            this.Controls.Add(this.btnManageProduct);
            this.Controls.Add(this.btnAddPack);
            this.Controls.Add(this.dgvPackages);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmPackageTable";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPackageTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPackages;
        private System.Windows.Forms.Button btnAddPack;
        private System.Windows.Forms.Button btnManageProduct;
        private System.Windows.Forms.Button btnManageSuppliers;
        private System.Windows.Forms.Button btnExit;
    }
}

