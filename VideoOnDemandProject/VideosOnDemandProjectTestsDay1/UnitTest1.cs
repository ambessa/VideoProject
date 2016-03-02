using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoOnDemandProjectDay1;

namespace VideosOnDemandProjectTestsDay1
{
    [TestClass]
    public class UnitTest1
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
        public void Test_CheckCustomer_HasAUsernameWithVideoOnDemandWithoutFullSubscription_WhenCalled()
        {
            //Arrange
            Username username = new Username();
            string user = "abel";
            bool access = false;
            //Act
            bool userAccess = username.CheckUser(user, access);

            //Assert
            Assert.AreEqual(true, userAccess);

        }

        [TestMethod]
        public void Test_CustomerWithUsername_HasSubscribedToFullSubscriptionService_WhenCalled()
        {
            //Arrange
            Username username = new Username();
            string user = "abel";
            bool access = true;

            //Act
            bool userAccess = username.CheckUser(user, access);

            //Arrange
            Assert.AreEqual(true, userAccess);
        }
    }
}
