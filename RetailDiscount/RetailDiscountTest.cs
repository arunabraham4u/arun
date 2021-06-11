using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetailDiscountLogic.Model;
using RetailDiscountLogic.Model.Billing;
using RetailDiscountLogic.Model.Customer;
using RetailDiscountLogic.Model.Rules;
namespace RetailDiscount
{
    [TestClass]
    public class RetailDiscountTest
    {
        [TestMethod]
        public void NoItemsTest()
        {

            var invoice = new Invoice()
            {

            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 0);
        }

        [TestMethod]
        public void InvoiceTest()
        {
            var item = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Chocolate"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            var invoice = new Invoice()
            {
                Items = items
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InvoiceSimpleTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Chocolate"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Employee()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 100);
        }

        [TestMethod]
        public void InvoiceSimpleGroceriesTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Chocolate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Bread"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Employee()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 195);
        }

        [TestMethod]
        public void InvoiceSimpleGroceriesAffiliateTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Chocolate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Bread"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Affliate()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 225);
        }

        [TestMethod]
        public void InvoiceSimpleGroceriesAffiliateTwoPlusYearsOldTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Chocolate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Bread"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Affliate()
                {
                    IsLoyal = true
                }
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 225);
        }
    }
}
