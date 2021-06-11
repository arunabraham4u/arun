using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model.Billing;
using RetailDiscountLogic.Model.Customer;

namespace RetailDiscountLogic.Model.Rules
{
    public abstract class BaseRule : IRule
    {
        public virtual string Description {
            get
            {
                return string.Empty;
            }
        }
        public virtual RuleType RuleType
        {
            get
            {
                return Rules.RuleType.Default;
            }
        }

        public abstract decimal CalculateDiscount(decimal amount, ICustomer customer);
        public  Invoice CalculateDiscountAmount(Invoice invoice)
        {
            if (invoice != null && invoice.Items != null && invoice.Items.Count > 0)
            {
                decimal groceryAmount = 0;
                decimal nonGroceryAmount = 0;
                invoice.TotalAmount = invoice.IsTotalAmountSet ? invoice.TotalAmount : invoice.Items.Sum(c => c.Amount);

                if (!invoice.IsTotalAmountSet)
                {
                    Console.WriteLine("******************");
                    Console.WriteLine(string.Format("Total amount before applying discount {0} ", invoice.TotalAmount.ToString()));
                }

                if (this.RuleType == Rules.RuleType.PercentageRule)
                {
                    var nonGroceryItems = invoice.Items.Where(c => c.ItemType == Billing.ItemType.Groceries);
                    groceryAmount = nonGroceryItems.Sum(c => c.Amount);
                    nonGroceryAmount = invoice.TotalAmount - groceryAmount;
                }
                else
                {
                    nonGroceryAmount = invoice.TotalAmount;
                }
                //discount rule can be applied only once
                if (IsDiscountApplicable(invoice))
                {

                    var discount = CalculateDiscount(nonGroceryAmount, invoice.Customer);
                    if (discount > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(string.Format("Applied discount for {0} and the discount is {1}", this.Description, discount.ToString()));
                    }
                    invoice.TotalAmount = invoice.TotalAmount - discount;
                }

                //set count of rules executed of each rule type
                SetRuleTypeCount(invoice);
                invoice.IsTotalAmountSet = true;
            }

            return invoice;
        }
        private bool IsDiscountApplicable(Invoice invoice)
        {
            if (this.RuleType == Rules.RuleType.PercentageRule && invoice.RulesExecuted.ContainsKey(this.RuleType) && invoice.RulesExecuted[this.RuleType] > 0)
                return false;

            return true;
        }


        private void SetRuleTypeCount(Invoice invoice)
        {
            if (invoice.RulesExecuted.ContainsKey(this.RuleType))
            {
                var count = invoice.RulesExecuted[this.RuleType];
                invoice.RulesExecuted[this.RuleType] = ++count;
            }
            else
            {
                invoice.RulesExecuted[this.RuleType] = 1;
            }
        }

    }
}
