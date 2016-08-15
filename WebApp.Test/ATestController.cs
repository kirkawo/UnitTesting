using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using WebApp.Interfaces;
using WebApp.Entities;
using WebApp.Controllers;

namespace WebApp.Test
{
    public class ATestController
    {
        private Mock<IRepositoryServise> _mocRepository;

        public ATestController()
        {
            this._mocRepository = new Mock<IRepositoryServise>();
        }

        [Fact]
        public void Test()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void Can_return_all()
        {
            List<TestModel> mockObj = new List<TestModel>()
            {
                new TestModel {Id = 1, Title = "Title 1", Body = "Body 1" },
                new TestModel {Id = 2, Title = "Title 2", Body = "Body 2" },
                new TestModel {Id = 3, Title = "Title 3", Body = "Body 3" }
            };

            _mocRepository.Setup(r => r.GetAllTestModels()).Returns(mockObj);

            var controller = new AController(_mocRepository.Object);

            var result = controller.Get();

            Assert.Equal(3, result.Count());
        }
    }
}
