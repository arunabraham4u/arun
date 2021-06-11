using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Customer;

namespace RetailDiscountLogic.Model.Rules
{
    public class ExpenseRule : BaseRule
    {
      
        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            int discountCount = Convert.ToInt32(amount / 100);
            return discountCount * 5;
        }

        public override string Description
        {
            get
            {
                return "For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). ";
            }
        }
    }
}
