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
            //var baselinePipeMock = new Mock<BasePipeline<Navigation>>();
            //var baselinePipeMock = new Mock<IPipeline<Navigation>>();

            navigationMock.Setup(x => x.FirstOrDefault<Navigation>()).Returns(new Navigation());

            var navigationPipelineMock = new Mock<IPipeline<Navigation>>();
            navigationPipelineMock.Setup(x => x.Register(new string[] { "all", "", "Grocery", "2104" }))
                .Returns(navigationPipelineMock.Object);

            navigationPipelineMock.Setup(x => x.Execute()).Returns(navigationMock.Object);

            // Arrange
            NavigationController controller = new NavigationController(navigationPipelineMock.Object);

            // Act
            Navigation navigation = controller.Get("all", "", "Grocery", "2104");

            // Assert
            //Assert.IsNotNull(navigation);
            navigationPipelineMock.VerifyAll();
        }

        //[TestMethod]
        //public void Get_NavigationStoreIdAsNull_ReturnsHierarchy()
        //{
        //    _hierarchy = new Hierarchy();

        //    var navigationProviderMock = new Mock<INavigationProvider>();
        //    navigationProviderMock.Setup(x => x.GetNavigation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
        //        .Returns(_hierarchy);

        //    // Arrange
        //    NavigationController controller = new NavigationController(navigationProviderMock.Object);

        //    // Act
        //    Hierarchy hierarchy = controller.Get("all", "", "Grocery", "");

        //    // Assert
        //    Assert.IsNotNull(hierarchy);
        //    navigationProviderMock.VerifyAll();
        //}

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void Get_AnonymousNavigationWithStoreIdPassed_ThrowsException()
        //{
        //    _hierarchy = new Hierarchy(); 

        //    var navigationProviderMock = new Mock<INavigationProvider>();
        //    navigationProviderMock.Setup(x => x.GetNavigation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
        //        .Throws<Exception>();

        //    // Arrange
        //    NavigationController controller = new NavigationController(navigationProviderMock.Object);

        //    // Act
        //    Hierarchy hierarchy = controller.Get("all", "", "Grocery", "1111");
        //}
    }
}
