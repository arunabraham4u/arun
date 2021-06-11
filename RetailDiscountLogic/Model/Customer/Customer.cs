using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDiscountLogic.Model.Customer
{
    public class Customer : ICustomer
    {
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsLoyal
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual decimal CalculateBill()
        {
            return 0;
        }
    }
}
