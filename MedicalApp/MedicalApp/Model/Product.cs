using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public int Stock { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
