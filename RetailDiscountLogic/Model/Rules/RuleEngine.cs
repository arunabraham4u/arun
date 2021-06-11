

using System.Collections.Concurrent;
using RetailDiscountLogic.Model.Customer;
using RetailDiscountLogic.Model.Billing;

namespace RetailDiscountLogic.Model.Rules
{
    public class RuleEngine
    {

        public ConcurrentDictionary<RuleType, int> RulesExecuted = new ConcurrentDictionary<RuleType, int>();

        
        public IRule GetRule(ICustomer customer)
        {
            if (customer is Employee)
                return new EmployeeRule();
            else if (customer is Affliate)
                return new AffiliateRule();

            return null;
        }

        
        public Invoice CalculateBill(Invoice invoice)
        {
            var beforeRules = HelperRules.GetBeforRules();
            invoice = ApplyRules(invoice, beforeRules);

            var rule = GetRule(invoice.Customer);
            if (rule != null)
            {
                invoice = rule.CalculateDiscountAmount(invoice);
            }

            var afterRules = HelperRules.GetAfterRules();
            invoice = ApplyRules(invoice, afterRules);
            return invoice;
        }

        
        private Invoice ApplyRules(Invoice invoice, System.Collections.ObjectModel.Collection<IRule> rules)
        {
            foreach (var rule in rules)
            {
                invoice = rule.CalculateDiscountAmount(invoice);
            }

            return invoice;
        }
    }
}
