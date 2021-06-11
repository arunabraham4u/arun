using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Customer;

namespace RetailDiscountLogic.Model.Rules
{
    public class LoyalityRule : BaseRule
    {

      
        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            if (customer != null && customer.IsLoyal)
                return amount * 5 / 100;
            return 0;
        }

       
        public override RuleType RuleType
        {
            get
            {
                return RuleType.PercentageRule;
            }
        }

        public override string Description
        {
            get
            {
                return "If the user has been a customer for over 2 years, he gets a 5% discount. ";
            }
        }
    }
}
