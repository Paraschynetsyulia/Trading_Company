using System.Linq;
using NUnit.Framework;
using DAL.ADO;
using DAL.Interfaces;
using System.Configuration;
namespace DAL.Tests
{
     [TestFixture]
        public class OrdersDalTests
        {
            IOrdersDAL dal;
            [OneTimeSetUp]
            public void InitialSetupTest()
            {
                dal = new OrdersDAL(ConfigurationManager.ConnectionStrings["TradingCompany(CS)"].ConnectionString);
            }
         [Test]
            public void GetAllRolesTest()
            {
            var orders = dal.GetAllOrders();
            Assert.IsTrue(orders.Any(r => r.OrderID == 10));
            Assert.IsTrue(orders.Any(r => r.OrderName == "Nisan"));
            Assert.IsTrue(orders.Any(r => r.Price == 100002));
             }
        }
        
}
