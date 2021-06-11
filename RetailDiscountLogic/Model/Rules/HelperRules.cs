using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscountLogic.Model.Rules
{
    public static class HelperRules
    {

        /// <returns></returns>
        public static Collection<IRule> GetBeforRules()
        {
            var rules = new Collection<IRule>();
            return rules;
        }


        public static Collection<IRule> GetAfterRules()
        {
            var rules = new Collection<IRule>();
            rules.Add(new LoyalityRule());
            rules.Add(new ExpenseRule());
            return rules;
        }
    }
}
