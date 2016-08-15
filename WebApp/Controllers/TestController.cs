using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Interfaces;
using WebApp.Entities;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ApiController
    {
        #region Fields
        private IRepositoryServise repository;
        private List<TestModel> mockObj = new List<TestModel>()
        {
            new TestModel {Id = 1, Title = "Title 1", Body = "Body 1" },
            new TestModel {Id = 2, Title = "Title 2", Body = "Body 2" },
            new TestModel {Id = 3, Title = "Title 3", Body = "Body 3" }
        };
        #endregion

        #region CTOR
        public TestController(IRepositoryServise repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Methods
        // GET api/<controller>
        public IEnumerable<TestModel> Get()
        {
            return mockObj;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]TestModel value)
        {
        }

        // PUT api/<controller>/5
        public void Put([FromBody]TestModel value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}