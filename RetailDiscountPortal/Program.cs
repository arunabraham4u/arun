using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailDiscountLogic.Model;
using RetailDiscountLogic.Model.Customer;
using RetailDiscountLogic.Model.Rules;
using RetailDiscountLogic.Model.Billing;
using System.Collections.ObjectModel;

namespace RetailDiscountPortal
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customer = GetCustomer();
            if (customer == null)
            {
                customer = GetCustomer();
            }
            else if (customer != null)
            {
                var items = GetItems();

                var invoice = new Invoice()
                {
                    Customer = customer,
                    Items = items
                };
                var engine = new RuleEngine();
                var result = engine.CalculateBill(invoice);

                if (result != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(string.Format("final Bill is {0}", result.TotalAmount));
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            Console.ReadLine();
        }

        private static Collection<Item> GetItems()
        {
            Console.WriteLine("Enter Items  as Name <space> Amount , If its Grocery  <space> 1 for 'Yes' else 0 for 'Default'");
            Console.WriteLine("Example");
            Console.WriteLine();
            Console.WriteLine("Name  Amount Type( 0 for default/1 for grocery)");
            Console.WriteLine("Chocolate 100 0");
            Console.WriteLine("Wheat Flour 25 1");
            Console.WriteLine("Onion 15 1");
            Console.WriteLine("0");
            Console.WriteLine();
            Console.WriteLine("When items are entered, Enter '0' to calculate the bill");
            var stuffs = new Collection<Item>();
            while (true)
            {
                try
                {

                    var input = Console.ReadLine();

                    if (input == "0")
                        break;
                    var items = input.Split(' ');
                    var item = new Item()
                    {
                        Name = items[0],
                        Amount = Convert.ToDecimal(items[1]),
                        ItemType = items[2] == "0" ? ItemType.Default : ItemType.Groceries
                    };
                    stuffs.Add(item);
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
            return stuffs;
        }

        private static ICustomer GetCustomer()
        {
            try
            {
                Console.WriteLine(string.Format("Enter Customer type =>\n'Enter '0' For Customer' \n'Enter '1' for Employee'  \n'Enter '2' for Affiliate'  "));
                var customerType = Console.ReadLine();

                ICustomer customer = null;
                if (customerType == "0")
                {
                    customer = new Customer();
                }
                else if (customerType == "1")
                {
                    customer = new Employee();
                }
                else if (customerType == "2")
                {
                    customer = new Affliate();
                }
                else
                {
                    Console.WriteLine("Invalid input , please try again");
                    return null;
                }
                Console.WriteLine("Has the user has been a customer for over 2 years? \n Enter 0 for 'No' or 1  for 'Yes'");
                string oldCustomer = Console.ReadLine();
                if (oldCustomer == "1")
                    customer.IsLoyal = true;
                else if (oldCustomer == "0")
                    customer.IsLoyal = false;
                else
                {
                    Console.WriteLine("Invalid input , please try again");
                    return null;
                }

                return customer;
            }
            catch
            {
                Console.WriteLine("Invalid input , please try again");
                return null;
            }
        }
    }
}
