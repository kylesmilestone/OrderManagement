using System;
using System.Collections.Generic;
using System.Text;// Remove

// This should be grouped into a namespace with other Reports classes e.g. Order.Management.Reports
namespace Order.Management
{
    // Report should not be an Order...
    // And Report doesn't need some of the properties from Order e.g. OrderNumber
    // However Report and Order can be derived from the same base class e.g. OrderInformation
    // Many inline hard-coded strings are being used.
    // Other reports types are having similar issues mentioned in this one
    class InvoiceReport : Order
    {
        // Should not hardcode this here, this is a printing related inforation, should not be in the Report Class
        public int tableWidth = 73;
        // Can pass in an object such as OrderInformation
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }

        // Extract this (e.g. an implementation of IReportGenerator)
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        // Extract this (e.g. an implementation of IDisplayStringGenerator)
        // Bad naming, better with verb e.g. GetRedPaintSurchargeString() and then call Console.WriteLine() print it, making the logic more testable
        // GetRedPaintSurchargeString() should take parameters
        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + base.OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        // Extract this (e.g. an implementation of ICalculator)
        public int TotalAmountOfRedShapes()
        {
            return base.OrderedBlocks[0].NumberOfRedShape + base.OrderedBlocks[1].NumberOfRedShape +
                   base.OrderedBlocks[2].NumberOfRedShape;
        }

        // Extract this (e.g. an implementation of ICalculator)
        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * base.OrderedBlocks[0].AdditionalCharge;
        }
        // Extract this (e.g. an implementation of IReportGenerator)
        // Can be internal and expose this to unit tests
        // This is being used by all 3 reports
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", base.OrderedBlocks[0].NumberOfRedShape.ToString(), base.OrderedBlocks[0].NumberOfBlueShape.ToString(), base.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].NumberOfRedShape.ToString(), base.OrderedBlocks[1].NumberOfBlueShape.ToString(), base.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", base.OrderedBlocks[2].NumberOfRedShape.ToString(), base.OrderedBlocks[2].NumberOfBlueShape.ToString(), base.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        // Extract this (e.g. an implementation of IDisplayStringGenerator)
        // Extract the logic to another method, make it more testable (decoupling with Console.WriteLine())
        // Bad naiming, e.g. GetOrderSquareDetailsString
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + base.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[0].Price + " ppi = $" + base.OrderedBlocks[0].Total());
        }
        // Extract this (e.g. an implementation of IDisplayStringGenerator)
        // Extract the logic to another method, make it more testable (decoupling with Console.WriteLine())
        // Bad naiming, e.g. GetOrderSquareDetailsString
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + base.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[1].Price + " ppi = $" + base.OrderedBlocks[1].Total());
        }
        // Extract this (e.g. an implementation of IDisplayStringGenerator)
        // Extract the logic to another method, make it more testable (decoupling with Console.WriteLine())
        // Bad naiming, e.g. GetOrderSquareDetailsString
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + base.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[2].Price + " ppi = $" + base.OrderedBlocks[2].Total());
        }
        // Extract this (e.g. an implementation of IStringPrinter)
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        // Extract this (e.g. an implementation of IStringPrinter)
        // This also has a few duplicates
        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        // Extract this (e.g. an implementation of IStringPrinter)
        // This also has a few duplicates
        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
