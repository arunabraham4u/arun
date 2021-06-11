using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Customer;
using RetailDiscountLogic.Model.Billing;

namespace RetailDiscountLogic.Model.Rules
{
    public interface IRule
    {
     
        decimal CalculateDiscount(decimal amount, ICustomer customer);

      
        Invoice CalculateDiscountAmount(Invoice invoice);

      
        RuleType RuleType { get; }

        string Description { get; }
    }
}
