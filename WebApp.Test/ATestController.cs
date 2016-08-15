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
using System.Web.Http.Results;
using System.Web.Http;

namespace WebApp.Test
{
    public class ATestController
    {
        private Mock<IRepositoryServise> _mocRepository;
        List<TestModel> mockObj = new List<TestModel>()
            {
                new TestModel {Id = 1, Title = "Title 1", Body = "Body 1" },
                new TestModel {Id = 2, Title = "Title 2", Body = "Body 2" },
                new TestModel {Id = 3, Title = "Title 3", Body = "Body 3" }
            };

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
            _mocRepository.Setup(r => r.GetAllTestModels()).Returns(mockObj);

            var controller = new AController(_mocRepository.Object);

            var result = controller.Get();

            Assert.Equal(3, result.Count());
        }
        [Fact]
        public void Can_return_by_id()
        {
            _mocRepository.Setup(r => r.GetTestModelById(1)).Returns(mockObj[0]);

            var controller = new AController(_mocRepository.Object);

            var result = controller.Get(1);

            Assert.IsType<OkNegotiatedContentResult<TestModel>>(result);
        }

        [Fact]
        public async Task Can_get_by_id_asyns()
        {
            _mocRepository.Setup(r => r.GetTestModelById(1)).Returns(mockObj[0]);
            var controller = new AController(_mocRepository.Object);

            var result = await controller.GetAsync(1) as OkNegotiatedContentResult<TestModel>;
            Assert.NotNull(result);
            Assert.Equal(mockObj[0].Body, result.Content.Body);
        }
    }
}
