using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using WebApp.Controllers;
using WebApp.Interfaces;
using WebApp.Services;
using WebApp.Entities;

namespace WebApp.Test
{
    public class AlexeyTestController
    {
        private AlexController _controller;
        private Mock<IRepositoryServise> _obj;
        private List<TestModel> mockObj = new List<TestModel>()
        {
            new TestModel {Id = 1, Title = "Title 1", Body = "Body 1" },
            new TestModel {Id = 2, Title = "Title 2", Body = "Body 2" },
            new TestModel {Id = 3, Title = "Title 3", Body = "Body 3" }
        };

        //public void Test_For_Method_GetAll ()
        //{
        //    _obj = new Mock<IRepositoryServise>();
        //    _obj.Setup(o => o.GetAllTestModels()).Returns();
        //    _controller = new AlexController();

        //}

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
