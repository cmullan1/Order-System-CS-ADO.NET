/*
 *  CPRG200 Lab 4
 *  Date:    July 17, 2018
 *  Author:  Corinne Mullan
 *  
 *  The frmOrders.cs file contains properties and methods for the main Orders form.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRG200Lab4
{
    public partial class frmOrders : Form
    {
        // Form variables
        Order order = new Order();          // The Order object for the order being displayed
        List<OrderDetails> orderDetailsList = new List<OrderDetails>(); // The order details for the same order

        public frmOrders()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            List<int> orderIDs;     // Empty list for the order ID values

            // Retrieve all of the order IDs from the database and populate the combo box.
            try
            {
                orderIDs = OrderDB.GetOrderIDs();
                foreach (int id in orderIDs)
                    cboOrderID.Items.Add(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        /// <summary>
        /// Reset all of the controls (other than the order ID combo box) on the form.
        /// </summary>
        private void ClearControls()
        {
            txtCustomerID.Text = "";
            dtpOrderDate.Checked = false;
            dtpRequiredDate.Checked = false;
            dtpShippedDate.Checked = false;
            lvOrderDetails.Items.Clear();
            lblOrderTotal.Text = "";
        }

        /// <summary>
        /// Display the main data for the order
        /// </summary>
        private void DisplayOrder()
        {
            txtCustomerID.Text = order.CustomerID;

            // Check for null values for the dates.  If the value is null, check the 
            // checkbox in the DateTimePicker; otherwise, uncheck the box and display 
            // the date value.
            // ^^ Post-submission correction:  checked = date set
            //                                 unchecked = date is null
            if (order.OrderDate.HasValue)
            {
                dtpOrderDate.Checked = true;
                dtpOrderDate.Value = (DateTime)order.OrderDate;
            }
            else
                dtpOrderDate.Checked = false;

            if (order.RequiredDate.HasValue)
            {
                dtpRequiredDate.Checked = true;
                dtpRequiredDate.Value = (DateTime)order.RequiredDate;
            }
            else
                dtpRequiredDate.Checked = false;

            if (order.ShippedDate.HasValue)
            {
                dtpShippedDate.Checked = true;
                dtpShippedDate.Value = (DateTime)order.ShippedDate;
            }
            else
                dtpShippedDate.Checked = false;
        }

        /// <summary>
        /// Display the details for the order in the list view control
        /// </summary>
        private void DisplayOrderDetails()
        {
            // Local variable
            decimal orderTotal = 0;     // The total value of the order

            lvOrderDetails.Items.Clear();   // Clear the list view

            foreach (OrderDetails od in orderDetailsList)
            {
                // Add each of the order details records to the list view
                ListViewItem lvi = new ListViewItem();
                lvi.Text = od.OrderID.ToString();
                lvi.SubItems.Add(od.ProductID.ToString());
                lvi.SubItems.Add(od.UnitPrice.ToString("c"));
                lvi.SubItems.Add(od.Quantity.ToString());
                lvi.SubItems.Add(od.Discount.ToString("#.00"));

                lvOrderDetails.Items.Add(lvi);
             
                // Add the value of this line item to the total value of the order
                orderTotal += od.UnitPrice * od.Quantity * (1 - od.Discount);
            }

            // Display the total value of the current order
            lblOrderTotal.Text = orderTotal.ToString("c");
        }

        /// <summary>
        /// When the selected Order ID is changed in the combo box, retrieve the Order and
        /// Order Details information from the database and display it.
        /// </summary>
        private void cboOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // There is no need to check for invalid orderID here, since it can only be 
            // selected from the drop-down list and not manually entered.

            int orderID = Convert.ToInt32(cboOrderID.SelectedItem);

            try
            {
                order = OrderDB.GetOrder(orderID);
                this.DisplayOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.ClearControls();
            }

            try
            {
                orderDetailsList = OrderDetailsDB.GetOrderDetails(orderID);
                this.DisplayOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.ClearControls();
            }
        }

        /// <summary>
        /// When the "Update Shipped Date" button is clicked, the Orders table in the database
        /// is updated accordingly.  A message indicating success or failure of the update is
        /// displayed.
        /// </summary>
        private void btnUpdateShippedDate_Click(object sender, EventArgs e)
        {
            // Local variable
            DateTime? newShippedDate;           // The new ShippedDate entered in the DateTimePicker
                                                // (may be null)

            // If the DateTimePicker is unchecked, the ShippedDate will be set to null.
            if (dtpShippedDate.Checked)
                newShippedDate = dtpShippedDate.Value;
            else
                newShippedDate = null;

            try
            {
                bool result = OrderDB.UpdateShippedDate(order, newShippedDate);

                if (result)
                    MessageBox.Show("The shipping date has been updated in the database.", "Success");
                else
                    MessageBox.Show("No rows updated.  Please try again.", "Retry");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
