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
    
        [Fact]
        public void Test_For_Method_GetAll()
        {
            var _mockObj = GetCollection();
            _obj = new Mock<IRepositoryServise>();
            _obj.Setup(o => o.GetAllTestModels()).Returns(_mockObj);
            _controller = new AlexController(_obj.Object);
            var result = _controller.Get();
            Assert.Equal(_mockObj, result);

        }
        [Fact]
        public void Test_For_Method_GetById()
        {
            int Id = 2;
            var _mockObj = GetCollection();
            _obj = new Mock<IRepositoryServise>();
            _obj.Setup(o => o.GetTestModelById(Id)).Returns(_mockObj.Find(obj => obj.Id == Id)
            );
            _controller = new AlexController(_obj.Object);
            var result = _controller.Get(Id);

            var objCompare = _mockObj.Find(o => o.Id == Id);
            Assert.Equal(objCompare, result);
        }

        #region Static collection for mock objects
        private static List<TestModel> GetCollection ()
        {
            return new List<TestModel>()
        {
            new TestModel {Id = 1, Title = "Title 1", Body = "Body 1" },
            new TestModel {Id = 2, Title = "Title 2", Body = "Body 2" },
            new TestModel {Id = 3, Title = "Title 3", Body = "Body 3" }
        };
        }
        #endregion
    }
}
