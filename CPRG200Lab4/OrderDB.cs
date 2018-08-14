/*
 *  CPRG200 Lab 4
 *  Date:    July 17, 2018
 *  Author:  Corinne Mullan
 *  
 *  The OrderDB.cs file contains static methods for retrieving data from the Orders
 *  table, and updating the ShippingDate in the Orders table.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200Lab4
{
    public static class OrderDB
    {
        /// <summary>
        /// The GetOrderIDs() method retrieves all the OrderID values from the Orders table.
        /// </summary>
        /// <returns>A list of all the OrderIDs</returns>
        public static List<int> GetOrderIDs()
        {
            // Local variables
            List<int> ordIDs = new List<int>();     // Empty list for storing the order ID values

            // Open a connection to the database
            SqlConnection con = NorthwindDB.GetConnection();

            // Define the SQL statement for retrieving the OrderIDs
            string selectStatement = "SELECT OrderID " +
                                     "FROM Orders " +
                                     "ORDER BY OrderID";

            // Create the SqlCommand object 
            SqlCommand cmd = new SqlCommand(selectStatement, con);

            // Try executing the query.  If successful, loop through the results and populate
            // the list orderIDs.
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())      // Loop through all the results
                {
                    ordIDs.Add((int)reader["OrderID"]);
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

            return ordIDs;
        }

        /// <summary>
        /// The GetOrder() method retrieves the relevant data from the Orders table,
        /// for the order specified by the orderID parameter.
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns>An Order object containing the data</returns>
        public static Order GetOrder(int orderID)
        {
            // Local variables
            Order ord = null;       // Empty Order object for storing the results

            // Open a connection to the database
            SqlConnection con = NorthwindDB.GetConnection();

            // Define the SQL statement for retrieving the Order information
            string selectStatement = "SELECT OrderID, CustomerID, " +
                                     "OrderDate, RequiredDate, ShippedDate " +
                                     "FROM Orders " +
                                     "WHERE OrderID = @OrderID";

            // Create the SqlCommand object 
            SqlCommand cmd = new SqlCommand(selectStatement, con);
            cmd.Parameters.AddWithValue("@OrderID", orderID); // Value comes from the method's argument

            // Try executing the query.  If successful, loop through the results and populate
            // the Order object.
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())      // Found an order
                {
                    ord = new Order();
                    ord.OrderID = (int)reader["OrderID"];
                    ord.CustomerID = reader["CustomerID"].ToString();
                    // The date fields may be NULL in the database.  Using "as DateTime?" 
                    // will read these as nullable DateTime values, and set the object properties 
                    // to null as required.
                    ord.OrderDate = reader["OrderDate"] as DateTime?;
                    ord.RequiredDate = reader["RequiredDate"] as DateTime?;
                    ord.ShippedDate = reader["ShippedDate"] as DateTime?;
                }
            }
            // If unsuccessful, throw the exception
            catch (SqlException ex)     // This is the only type of exception that can result
            {
                throw ex;
            }
            // In either case, close the database connection
            finally
            {
                con.Close();
            }

            return ord;
        }

        /// <summary>
        /// The UpdateShippedDate() method updates the ShippedDate in the Orders table,
        /// for the order specified by the ord parameter.
        /// </summary>
        /// <param name="ord">The order to be updated</param>
        /// <param name="newShippedDate">The new ShippedDate for the order</param>
        /// <returns>true if successful, otherwise false</returns>
        public static bool UpdateShippedDate(Order ord, DateTime? newShippedDate)
        {
            // The new ShippedDate will always be either a valid date or null, as it is obtained from
            // a DateTimePicker on the main form, so invalid dates cannot be entered.

            if (newShippedDate.HasValue)
            {
                // If the new ShippedDate is not null, it must be on or after the OrderDate,
                // and on or before the RequiredDate, if these dates are non-null.

                // Only the date portion of the DateTime value needs to be considered, and not
                // the time.  "DateTime?" values must be typecase to "DateTime" before using .Date.
                if ((!ord.OrderDate.HasValue || (((DateTime)newShippedDate).Date >= ((DateTime)ord.OrderDate).Date)) &&
                    (!ord.RequiredDate.HasValue || (((DateTime)newShippedDate).Date <= ((DateTime)ord.RequiredDate).Date)))
                {
                    // Open the database connection
                    SqlConnection con = NorthwindDB.GetConnection();

                    // Create the SQL update statement and SqlCommand object.
                    //
                    // Concurrency:  use "last-in" concurrency here; i.e., this application is
                    // allowed to update the ShippedDate even if the record has been updated by
                    // another user since the data was read.  It is very unlikely that different 
                    // users would try to update the ShippedDate to different values simultaneously. 
                    string updateStatement = "UPDATE Orders " +
                                             "SET ShippedDate = @NewShippedDate " +
                                             "WHERE OrderID = @OrderID"; 

                    SqlCommand cmd = new SqlCommand(updateStatement, con);
                    cmd.Parameters.AddWithValue("@NewShippedDate", ((DateTime)newShippedDate).ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@OrderID", ord.OrderID);

                    // Try executing the query.
                    try
                    {
                        con.Open();
                        int count = cmd.ExecuteNonQuery(); // Returns the number of rows updated (will be either 0 or 1 here)
                        if (count > 0)
                            return true;
                        else
                            return false;
                    }
                    // If unsuccessful, throw the exception
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    // In either case, close the database connection
                    finally
                    {
                        con.Close();
                    }

                }
                else
                {
                    // The new ShippedDate is invalid.  Throw an exception to indicate this.
                    throw new Exception("The Shipped Date must be no earlier than the Order Date, and " + 
                                        "no later than the Required Date.");
                }
                
            }
            else
            {
                // The new ShippedDate is null, and will be updated to NULL in the database.
                // This could happen if the ShippedDate was entered incorrectly and nees to 
                // be reset.

                // Open a connection to the database 
                SqlConnection con = NorthwindDB.GetConnection();

                // Create the SQL update statement and SqlCommand object.
                // As above, use "last-in" concurrency.
                string updateStatement = "UPDATE Orders " +
                                         "SET ShippedDate = NULL " +
                                         "WHERE OrderID = @OrderID"; 

                // Create the SqlCommand object
                SqlCommand cmd = new SqlCommand(updateStatement, con);
                cmd.Parameters.AddWithValue("@OrderID", ord.OrderID);

                // Try executing the query.
                try
                {
                    con.Open();
                    int count = cmd.ExecuteNonQuery(); // Returns the number of rows updated (will be either 0 or 1 here)
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                // If unsuccessful, throw the exception
                catch (SqlException ex)
                {
                    throw ex;
                }
                // In either case, close the database connection
                finally
                {
                    con.Close();
                }

            }
        }
    }
}
