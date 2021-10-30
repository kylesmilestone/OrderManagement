using System;
using System.Collections.Generic;
using System.Text; // Remove unused using statements

namespace Order.Management
{
    abstract class Order
    {
        public string CustomerName { get; set; }
        public string Address { get; set; } // This should be validated
        public string DueDate { get; set; } // Bad type, I understand it's for the console inputing the date, but this should be DateTime and the input date string should be validated and casted to DateTime
        public int OrderNumber { get; set; } // Ideally the OrderNumber should be more complex for future...consider using other datatype for OrderNumber, e.g. a meaningful string with numbers
        public List<Shape> OrderedBlocks { get; set; }

        // Ideally this should be extracted to another class (e.g. an implementation of IReportGenerator)
        public abstract void GenerateReport();

        // This is data model, extract this to another class
        // This should override the default ToString() Method
        public string ToString()
        {
            return "\nName: " + CustomerName + " Address: " + Address + " Due Date: " + DueDate + " Order #: " + OrderNumber;
        }
    }
}
