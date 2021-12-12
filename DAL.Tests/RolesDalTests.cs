using System.Linq;
using NUnit.Framework;
using DAL.ADO;
using DAL.Interfaces;
using System.Configuration;

namespace DAL.Tests
{
    [TestFixture]
    public class RolesDalTests
    {
        IRolesDAL dal;
        [OneTimeSetUp]
        public void InitialSetupTest()
        {
            dal = new RolesDAL(ConfigurationManager.ConnectionStrings["TradingCompany(CS)"].ConnectionString);
        }
        [Test]
        public void GetAllRolesTest()
        {
            var roles = dal.GetAllRoles();
            Assert.IsTrue(roles.Any(r => r.RoleName == "Yuliia"));
        }
    }
}
