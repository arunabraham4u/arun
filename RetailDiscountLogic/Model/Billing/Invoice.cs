using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Customer;
using RetailDiscountLogic.Model.Rules;

namespace RetailDiscountLogic.Model.Billing
{
   public class Invoice
    {

        public ICustomer Customer;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public Collection<Item> Items { get; set; }

        
        public Decimal TotalAmount { get; set; }

        
        public ConcurrentDictionary<RuleType, int> RulesExecuted = new ConcurrentDictionary<RuleType, int>();


        
        public bool IsTotalAmountSet { get; set; }
    }
}
