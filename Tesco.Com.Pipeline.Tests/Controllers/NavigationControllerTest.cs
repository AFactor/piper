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

namespace Tesco.Com.Pipeline.Tests.Controllers
{
    [TestClass]
    public class NavigationControllerTest
    {
        private Hierarchy _hierarchy;

        //[TestMethod]
        //public void Get_NavigationWithStoreIdPassed_ReturnsHierarchy()
        //{
        //    _hierarchy = new Hierarchy();

        //    var navigationProviderMock = new Mock<INavigationProvider>();
        //    navigationProviderMock.Setup(x => x.GetNavigation(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
        //        .Returns(_hierarchy);

        //    // Arrange
        //    NavigationController controller = new NavigationController(navigationProviderMock.Object);

        //    // Act
        //    Hierarchy hierarchy = controller.Get("all", "", "Grocery", "2103");

        //    // Assert
        //    Assert.IsNotNull(hierarchy);
        //    navigationProviderMock.VerifyAll();
        //}

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
