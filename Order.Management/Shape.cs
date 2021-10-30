using System;
using System.Collections.Generic;
using System.Text;
// remove unused using statements

// this class should only caontain minimal needs for the derived classes
namespace Order.Management
{
    abstract class Shape
    {
        // Enum is better option
        public string Name { get; set; }
        public int Price { get; set; } // Price is better in decimal type for accuracy and 
        public int AdditionalCharge { get; set; } // Price is better in decimal type for accuracy and 
        public int NumberOfRedShape { get; set; }
        public int NumberOfBlueShape { get; set; }
        public int NumberOfYellowShape { get; set; }

        // No need to use a method here
        // Make it a property and being assigned by the Calculator class
        // If a method is a must, name it something like GetTotalQuantityOfShape() or CalCulateTotalQuantityOfShape()
        public int TotalQuantityOfShape() 
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        // Not need to use a method here
        // Make it a property and being assigned by the Calculator class
        // If a method is a must, name it something like GetAdditionalChargeTotal() or CalCulateAdditionalChargeTotal()
        public int AdditionalChargeTotal()
        {
            return NumberOfRedShape * AdditionalCharge;
        }
        
        // Make it a property and being assigned by the Calculator class
        public abstract int Total();

    }
}
