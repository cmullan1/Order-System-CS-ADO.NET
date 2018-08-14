/*
 *  CPRG200 Lab 4
 *  Date:    July 17, 2018
 *  Author:  Corinne Mullan
 *  
 *  The OrderDetails.cs file contains the definition of the OrderDetails entity class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200Lab4
{
    public class OrderDetails
    {
        // Public accessor properties
        // The accessor names correspond to the column names in the Order Details table in the
        // database.  All fields from the Order Details table are required in this lab.
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
