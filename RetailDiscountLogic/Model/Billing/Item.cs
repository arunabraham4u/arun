using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscountLogic.Model.Billing
{
   public class Item
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

      
        public ItemType ItemType { get; set; }

        public decimal Amount { get; set; }
    }
}
