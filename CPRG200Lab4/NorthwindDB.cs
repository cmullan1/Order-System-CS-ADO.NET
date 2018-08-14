/*
 *  CPRG200 Lab 4
 *  Date:    July 17, 2018
 *  Author:  Corinne Mullan
 *  
 *  The NorthwindDB.cs file contains the NorthwindDB class used for connecting to the Northwind
 *  database.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200Lab4
{
    public static class NorthwindDB
    {
        /// <summary>
        /// The GetConnection() method is used to connect to the Northwind database.  In this
        /// lab, the database has been copied to a local file in the solutions folder.
        /// 
        /// </summary>
        /// <returns>A SqlConnection object containing the connection to the database.</returns>
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\northwnd.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
