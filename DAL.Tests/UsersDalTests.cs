using System.Linq;
using NUnit.Framework;
using DAL.ADO;
using DAL.Interfaces;
using System.Configuration;
namespace DAL.Tests
{
    [TestFixture]
    public class UsersDalTests
    {
        IUsersDAL dal;
        [OneTimeSetUp]
        public void InitialSetupTest()
        {
            dal = new UsersDAL(ConfigurationManager.ConnectionStrings["TradingCompany(CS)"].ConnectionString);
        }
        [Test]
        public void GetAllUsersTest()
        {
            var users = dal.GetAllUsers();
            Assert.IsTrue(users.Any(r => r.UserID == 2101));
            Assert.IsTrue(users.Any(r => r.FirstName == "Vasyl"));
            Assert.IsTrue(users.Any(r => r.LastName == "Parashchynets"));
            Assert.IsTrue(users.Any(r => r.Login == "vasyl1975"));
            Assert.IsTrue(users.Any(r => r.Password == "Volodumurovuch2021"));
            Assert.IsTrue(users.Any(r => r.RoleID == 3));
        }
    }
}