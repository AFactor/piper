using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Operations;
using Tesco.Com.Pipeline.Operations.Contract;
using Tesco.Com.Pipeline.Pipe;

namespace Tesco.Com.Pipeline.Tests.Operations
{
    [TestClass]
    public class NavigationOperationTest
    {
        //[TestMethod]
        //public void Execute_Returns_IEnumerable_Of_Navigation()
        //{
        //    // Arrange
        //    var hierarchy = new Mock<Hierarchy>();
        //    var input = new Mock<IEnumerable<Navigation>>();
        //    //var navigationOperationMock = new Mock<NavigationOperation>();
        //    var apiOperationMock = new Mock<IApiOperation>();

        //    apiOperationMock.Setup(x => x.FromApi(It.IsAny<string>(), It.IsAny<string>(), new string[] { })).Returns(hierarchy.Object);
        //    //navigationOperationMock.Setup(x => x.Execute(input.Object)).Returns(input.Object);

        //    // Act
        //    NavigationOperation oper = new NavigationOperation(apiOperationMock.Object);
        //    IEnumerable<Navigation> obj = oper.Execute(input.Object);

        //    // Assert
        //    Assert.IsNotNull(obj);
        //    apiOperationMock.VerifyAll();
        //    //navigationOperationMock.VerifyAll();
        //}
    }
}
