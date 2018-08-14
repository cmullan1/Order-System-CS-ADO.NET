namespace CPRG200Lab4
{
    partial class frmOrders
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
            this.cboOrderID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvOrderDetails = new System.Windows.Forms.ListView();
            this.OrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Discount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.dtpShippedDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateShippedDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboOrderID
            // 
            this.cboOrderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderID.FormattingEnabled = true;
            this.cboOrderID.Location = new System.Drawing.Point(210, 23);
            this.cboOrderID.Name = "cboOrderID";
            this.cboOrderID.Size = new System.Drawing.Size(115, 28);
            this.cboOrderID.TabIndex = 0;
            this.cboOrderID.SelectedIndexChanged += new System.EventHandler(this.cboOrderID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Order ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer ID:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(210, 86);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(115, 26);
            this.txtCustomerID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Order Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Required Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Shipped Date:";
            // 
            // lvOrderDetails
            // 
            this.lvOrderDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderID,
            this.ProductID,
            this.UnitPrice,
            this.Quantity,
            this.Discount});
            this.lvOrderDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOrderDetails.Location = new System.Drawing.Point(54, 231);
            this.lvOrderDetails.Name = "lvOrderDetails";
            this.lvOrderDetails.Size = new System.Drawing.Size(504, 187);
            this.lvOrderDetails.TabIndex = 10;
            this.lvOrderDetails.UseCompatibleStateImageBehavior = false;
            this.lvOrderDetails.View = System.Windows.Forms.View.Details;
            // 
            // OrderID
            // 
            this.OrderID.Text = "Order ID";
            this.OrderID.Width = 100;
            // 
            // ProductID
            // 
            this.ProductID.Text = "Product ID";
            this.ProductID.Width = 100;
            // 
            // UnitPrice
            // 
            this.UnitPrice.Text = "Unit Price";
            this.UnitPrice.Width = 100;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 100;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.Width = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(614, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Order Total:";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.Location = new System.Drawing.Point(618, 266);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(115, 40);
            this.lblOrderTotal.TabIndex = 12;
            this.lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Checked = false;
            this.dtpOrderDate.Enabled = false;
            this.dtpOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderDate.Location = new System.Drawing.Point(210, 126);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.ShowCheckBox = true;
            this.dtpOrderDate.Size = new System.Drawing.Size(192, 26);
            this.dtpOrderDate.TabIndex = 13;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Checked = false;
            this.dtpRequiredDate.Enabled = false;
            this.dtpRequiredDate.Location = new System.Drawing.Point(557, 126);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.ShowCheckBox = true;
            this.dtpRequiredDate.Size = new System.Drawing.Size(192, 26);
            this.dtpRequiredDate.TabIndex = 14;
            // 
            // dtpShippedDate
            // 
            this.dtpShippedDate.Checked = false;
            this.dtpShippedDate.Location = new System.Drawing.Point(210, 166);
            this.dtpShippedDate.Name = "dtpShippedDate";
            this.dtpShippedDate.ShowCheckBox = true;
            this.dtpShippedDate.Size = new System.Drawing.Size(192, 26);
            this.dtpShippedDate.TabIndex = 15;
            // 
            // btnUpdateShippedDate
            // 
            this.btnUpdateShippedDate.Location = new System.Drawing.Point(426, 164);
            this.btnUpdateShippedDate.Name = "btnUpdateShippedDate";
            this.btnUpdateShippedDate.Size = new System.Drawing.Size(200, 35);
            this.btnUpdateShippedDate.TabIndex = 16;
            this.btnUpdateShippedDate.Text = "Update Shipped Date";
            this.btnUpdateShippedDate.UseVisualStyleBackColor = true;
            this.btnUpdateShippedDate.Click += new System.EventHandler(this.btnUpdateShippedDate_Click);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 447);
            this.Controls.Add(this.btnUpdateShippedDate);
            this.Controls.Add(this.dtpShippedDate);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lvOrderDetails);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOrderID);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrders";
            this.Text = "Orders and Details";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvOrderDetails;
        private System.Windows.Forms.ColumnHeader OrderID;
        private System.Windows.Forms.ColumnHeader ProductID;
        private System.Windows.Forms.ColumnHeader UnitPrice;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.DateTimePicker dtpShippedDate;
        private System.Windows.Forms.Button btnUpdateShippedDate;
    }
}

