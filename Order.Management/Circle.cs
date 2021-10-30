using System;
using System.Collections.Generic;
using System.Text;
// Above should be removed as they are not used

// Should group all the data model class to a name space nammed "Models" (folder)
// Namespace Order.Management.Models
// Based on single responsibility principle, the calculation methods should be in another class (e.g. implementations of IPriceCalculator), this should only be the data
namespace Order.Management
{
    class Circle : Shape
    {
        // This should not be hard-coded, otherwise if the price changes, code has to be changed, this is ideally being fetched from other data source e.g. a database table, at least from an object from the container (e.g. Program.cs) in this case
        // Should pass this in from the construtor, or we don't really need this in the Circle class, just pass it to the calculator
        // If we really need the unit price in the class, we can named it PrivePerUnit and put it in the base class
        public int circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            // Use base constructor
            // Should use enum, if a stirng is a must, use a constant or readonly string for "Cricle"
            Name = "Circle";
            base.Price = circlePrice;// consistent issue, should use base.Property for all or better not use for any of them
            AdditionalCharge = 1;
            base.NumberOfRedShape = red;
            base.NumberOfBlueShape = blue;
            base.NumberOfYellowShape = yellow;
        } // New line
        // These method can be extracted to another class(e.g. an implementation of IPriceCalculator)
        // Naming should be generic and be more clear, use verb e.g. CalculateTotal(), CalculateRedItemTotal()
        // These methods are ideally taking the mumbers needed to calculate as paramaters, so they are more testable
        public override int Total() 
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }
        public int RedCirclesTotal() // This doesn't need to be public, it can just be internal and expose this to the test project
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueCirclesTotal() // This doesn't need to be public, it can just be internal and expose this to the test project
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal() // This doesn't need to be public, it can just be internal and expose this to the test project
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
// Similar commets for Square and Triangle