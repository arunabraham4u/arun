using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscountLogic.Model.Customer
{
   public class Employee :Customer
    {

        public override decimal CalculateBill()
        {
            return base.CalculateBill();
        }
    }
}
