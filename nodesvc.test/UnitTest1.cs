using NUnit.Framework;
using Microsoft.AspNetCore.NodeServices;
using nodesvc.Controllers;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void HomeReturnsMyAction()
        {
            var mockNodeServices = new Moq.Mock<INodeServices>();
            mockNodeServices.Setup(s => s.InvokeAsync<int>(It.IsAny<string>()))
                .Returns(Task.FromResult<int>(0));
            var controller = new HomeController();
            var cr = controller.MyAction(mockNodeServices.Object).Result as ContentResult;
            Assert.AreEqual("1 + 2 = 0", cr.Content);
        }

        [Test]
        public void HomeErrorReturnsActivityId()
        {
            var controller = new HomeController();
            var a = new System.Diagnostics.Activity("dummy activity");
            a.Start();
            var result = controller.Error() as ViewResult;
            a.Stop();
            Assert.AreEqual(a.Id,result.ViewData["requestId"]);
        }

        [Test]
        public void HomeErrorReturnsHttpContextTraceId()
        {
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext();
            var mockContext = new Moq.Mock<HttpContext>();
            mockContext.SetupProperty<string>(p => p.TraceIdentifier, "124");
            controller.ControllerContext.HttpContext = mockContext.Object;
            var result = controller.Error() as ViewResult;
            Assert.AreEqual("124",result.ViewData["requestId"]);
        }

    }
}