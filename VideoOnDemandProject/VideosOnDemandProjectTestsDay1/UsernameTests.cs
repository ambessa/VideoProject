using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoOnDemandProjectDay1;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class UsernameTests
    {
        [TestMethod]
        public void Test_CheckCustomer_HasNoUsernameWithVideoOnDemand_WhenCalled()
        {
            //Arrange
            Username username = new Username();
            string user = "";
            bool access = false;
            //Act
            bool userAccess = username.CheckUser(user, access);

            //Assert
            Assert.AreEqual(false, userAccess);
            
        }

        [TestMethod]
        public void Test_CheckCustomer_HasAUsernameWithoutFullSubscriptionService_WhenCalled()
        {
            //Arrange
            Username username = new Username();
            string user = "abel";
            bool fullService = false;
            //Act
            bool userAccess = username.CheckUser(user, fullService);

            //Assert
            Assert.AreEqual(true, userAccess);

        }

        [TestMethod]
        public void Test_CheckCustomerWithUsername_HasSubscribedToFullSubscriptionService_WhenCalled()
        {
            //Arrange
            Username username = new Username();
            string user = "abel";
            bool fullService = true;

            //Act
            bool userAccess = username.CheckUser(user, fullService);

            //Arrange
            Assert.AreEqual(true, userAccess);
        }
    }
}
