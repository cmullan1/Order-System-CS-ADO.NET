/*
 *  CPRG200 Lab 4
 *  Date:    July 17, 2018
 *  Author:  Corinne Mullan
 *  
 *  The OrderDetailsDB.cs file contains the static method for retrieving data from the 
 *  Order Details table.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200Lab4
{
    public static class OrderDetailsDB
    {
        /// <summary>
        /// The GetOrderDetails() method returns all rows from the Order Details table
        /// having the OrderID specified by the orderID parameter.
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns>A list object containing all of the required order details</returns>
        public static List<OrderDetails> GetOrderDetails(int orderID)
        {
            // Local variables
            List<OrderDetails> ordDetailsList = new List<OrderDetails>();   // An empty list for storing
                                                                            // all the order details
            OrderDetails ordDetails;    // Object for storing a single row of data from the Order Details table

            // Open a connection to the database
            SqlConnection con = NorthwindDB.GetConnection();
            // Define the SQL statement for retrieving the records
            string selectStatement = "SELECT OrderID, ProductID, " +
                                     "UnitPrice, Quantity, Discount " + 
                                     "FROM [Order Details] " +
                                     "WHERE OrderID = @OrderID";

            // Create the SqlCommand object and add the required parameters
            SqlCommand cmd = new SqlCommand(selectStatement, con);
            cmd.Parameters.AddWithValue("@OrderID", orderID); 

            // Try executing the query.  If successful, loop through the results and populate
            // the list of order details.
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())      // Found an order
                {
                    ordDetails = new OrderDetails();
                    ordDetails.OrderID = Convert.ToInt32(reader["OrderID"]);
                    ordDetails.ProductID = Convert.ToInt32(reader["ProductID"]);
                    ordDetails.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    ordDetails.Quantity = Convert.ToInt32(reader["Quantity"]);
                    ordDetails.Discount = Convert.ToDecimal(reader["Discount"]);

                    ordDetailsList.Add(ordDetails);
                }
            }
            // If unsuccessful, throw the exception
            catch (SqlException ex)     // This is the only type of exception that can result
            {
                throw ex;
            }
            // In either case, close the connection
            finally
            {
                con.Close();
            }

            return ordDetailsList;
        }
    }
}
