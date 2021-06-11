using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Customer;

namespace RetailDiscountLogic.Model.Rules
{
    public class EmployeeRule : BaseRule
    {

        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            return amount * 3 / 10;
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
                return "If the user is an employee of the store, he gets a 30% discount  ";
            }
        }
    }
    }
