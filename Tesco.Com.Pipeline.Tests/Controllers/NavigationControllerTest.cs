using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tesco.Com.Pipeline;
using Tesco.Com.Pipeline.Controllers;
using Tesco.Com.Pipeline.Provider.Contract;
using Moq;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Utilities;
using Tesco.Com.Pipeline.Pipe;
using Tesco.Com.Pipeline.Operations;

namespace Tesco.Com.Pipeline.Tests.Controllers
{
    [TestClass]
    public class NavigationControllerTest
    {
        [TestMethod]
        public void Get_NavigationWithStoreIdPassed_ReturnsHierarchy()
        {
            var navigationMock = new Mock<IEnumerable<Navigation>>();
            IEnumerable<Navigation> nav = new List<Navigation>() {new Navigation(){ShopGroceries = new Hierarchy()}};

            var navigationPipelineMock = new Mock<IPipeline<Navigation>>();
            navigationPipelineMock.Setup(x => x.Register(new string[] { "all", "", "Grocery", "2104" }))
                .Returns(navigationPipelineMock.Object);

            navigationPipelineMock.Setup(x => x.Execute()).Returns(nav);

            // Arrange
            NavigationController controller = new NavigationController(navigationPipelineMock.Object);

            // Act
            Navigation navigation = controller.Get("all", "", "Grocery", "2104");

            // Assert
            Assert.IsNotNull(navigation);
            navigationPipelineMock.VerifyAll();
        }

        [TestMethod]
        public void Get_NavigationStoreIdAsNull_ReturnsNavigation()
        {
            var navigationMock = new Mock<IEnumerable<Navigation>>();
            IEnumerable<Navigation> nav = new List<Navigation>() { new Navigation() { ShopGroceries = new Hierarchy() } };

            var navigationPipelineMock = new Mock<IPipeline<Navigation>>();
            navigationPipelineMock.Setup(x => x.Register(new string[] { "all", "", "Grocery"}))
                .Returns(navigationPipelineMock.Object);

            navigationPipelineMock.Setup(x => x.Execute()).Returns(nav);

            // Arrange
            NavigationController controller = new NavigationController(navigationPipelineMock.Object);

            // Act
            Navigation navigation = controller.Get("all", "", "Grocery", "");

            // Assert
            Assert.IsNotNull(navigation);
            navigationPipelineMock.VerifyAll();
        }

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void Get_Navigation_With_Null_ThrowsException()
        //{
        //    var navigationMock = new Mock<IEnumerable<Navigation>>();
        //    //IEnumerable<Navigation> nav = new List<Navigation>() { new Navigation() { ShopGroceries = new Hierarchy() } };

        //    var navigationPipelineMock = new Mock<IPipeline<Navigation>>();
        //    navigationPipelineMock.Setup(x => x.Register(new string[] { "all", "", "Grocery" }))
        //        .Returns(navigationPipelineMock.Object);

        //    navigationPipelineMock.Setup(x => x.Execute()).Returns(navigationMock.Object);

        //    // Arrange
        //    NavigationController controller = new NavigationController(navigationPipelineMock.Object);

        //    // Act
        //    Navigation navigation = controller.Get("all", "", "Grocery", "");
        //}
    }
}
