using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Pipeline.Entities.ResponseEntities;
using Tesco.Com.Pipeline.Operations.Contract;
using Tesco.Com.Pipeline.Pipe;

namespace Tesco.Com.Pipeline.Tests.Pipeline
{
    [TestClass]
    public class NavigationPipelineTest
    {
        [TestMethod]
        public void NavigationPipeline_Constructor()
        {
            var navigationOperatioinMock = new Mock<INavigationOperation>();
           
            NavigationPipeline navigationPipeline = new NavigationPipeline(navigationOperatioinMock.Object);

            // Assert
            Assert.IsNotNull(navigationPipeline);
            navigationOperatioinMock.VerifyAll();
        }

        [TestMethod]
        public void Register_Calls_BaseClass_Register()
        {
            var navigationOperatioinMock = new Mock<INavigationOperation>();

            var basePipelineObj = new Mock<BasePipeline<Navigation>>();
            var navigationPipelineMock = new Mock<BasePipeline<Navigation>>();
            navigationPipelineMock.Setup(x => x.Register(navigationOperatioinMock.Object, new string[]{})).Returns(basePipelineObj.Object);

            // Arrange
            NavigationPipeline navigationPipeline = new NavigationPipeline(navigationOperatioinMock.Object);

            // Act
            var obj = navigationPipeline.Register(new string[] { });

            // Assert
            Assert.IsNotNull(navigationPipeline);
            navigationOperatioinMock.VerifyAll();
        }
    }
}
