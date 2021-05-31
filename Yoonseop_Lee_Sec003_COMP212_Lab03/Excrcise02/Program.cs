using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excrcise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoices = new[] {
         new Invoice(87,"Electric Saner", 7, 57.98M),
         new Invoice(24,"Power Saw", 18, 99.99M),
         new Invoice(7,"Sledge Hammer", 11, 21.50M),
         new Invoice(77,"Hammer", 76, 11.99M),
         new Invoice(39,"Lawn Mower", 3,79.50M),
         new Invoice(68,"Screw Driver", 106, 6.99M),
         new Invoice(56,"Jig saw", 21, 11.00M)};

            var Total =
            from i in invoices
            let InvoiceTotal = i.Price * i.Quantity
            orderby InvoiceTotal
            select new { i.PartDescription, InvoiceTotal };

            var highest =
                from i in invoices
                let max = invoices.Max(e => e.Quantity)
                where i.Quantity == max
                select new { i.PartDescription };



            var avg = invoices.Average(x => x.Price);


            //invoices.Average(x => x.Price);

            //output
            foreach (var item in Total)
            {
                Console.WriteLine(item);
            }

            foreach (var item in highest)
            {

                Console.WriteLine($"\nhighest in terms of quantity: {item}");
            }



            Console.WriteLine($"\naverage price: ${avg:f2}");


            /*
             a) Use LINQ to select from each Invoice the PartDescription and value of the Invoice 
             ( i.e. Quantity * Price ). Name the calculated column as InvoiceTotal.
             Order the results by invoice value in ascending order. [Hint: use let ] 
             b) Part description of the part who has highest quantity.
             c) Average price of the parts.       
             */
        }
    }
}