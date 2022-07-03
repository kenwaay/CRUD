using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudApp.data
{
    public class Product // create product class variables
    {
        public int ID { get; set; }
        public string Model { get; set; } 
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }


    }
}
