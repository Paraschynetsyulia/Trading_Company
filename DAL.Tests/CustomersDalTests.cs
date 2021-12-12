using System.Linq;
using NUnit.Framework;
using DAL.ADO;
using DAL.Interfaces;
using System.Configuration;

namespace DAL.Tests
{
    [TestFixture]
    class CustomersDalTests
    {
        ICustomersDAL dal;
        [OneTimeSetUp]
        public void InitialSetupTest()
        {
            dal = new CustomersDAL(ConfigurationManager.ConnectionStrings["TradingCompany(CS)"].ConnectionString);
        }
        [Test]
        public void GetAllCustomersTest()
        {
            var customers = dal.GetAllCustomers();
            Assert.IsTrue(customers.Any(r => r.CustomerID == 2102));
            Assert.IsTrue(customers.Any(r => r.FirstName == "Anna"));
            Assert.IsTrue(customers.Any(r => r.LastName == "Hrapchyn"));
            Assert.IsTrue(customers.Any(r => r.Discount == 10));
            Assert.IsTrue(customers.Any(r => r.OrderID == 3));
        }
    }
}
