/*
 *  CPRG200 Lab 4
 *  Date:    July 17, 2018
 *  Author:  Corinne Mullan
 *  
 *  The Order.cs file contains the definition of the Order entity class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200Lab4
{
    public class Order
    {
        // Public accessor properties
        // The accessor names correspond to the column names in the Orders table in the
        // database.  Accessor properties have only been defined for those database fields
        // used in this lab.
        public int OrderID { get; set; }
        public string CustomerID { get; set; }

        // The OrderDate, RequiredDate, and ShippedDate columns may all contain NULL values, 
        // so nullable datatypes have been used for these.
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
