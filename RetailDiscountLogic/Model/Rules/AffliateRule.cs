using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Customer;

namespace RetailDiscountLogic.Model.Rules
{
    public class AffiliateRule : BaseRule
    {
        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            return amount * 1 / 10;
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
                return "If the user is an affiliate of the store, he gets a 10% discount ";
            }
        }
    }
}
