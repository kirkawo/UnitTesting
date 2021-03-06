﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Controllers
{
    public class AController : ApiController
    {
        #region Fields
        private IRepositoryServise _repository;
        private List<TestModel> mockObj = new List<TestModel>()
        {
            new TestModel {Id = 1, Title = "Title 1", Body = "Body 1" },
            new TestModel {Id = 2, Title = "Title 2", Body = "Body 2" },
            new TestModel {Id = 3, Title = "Title 3", Body = "Body 3" }
        };
        #endregion

        #region CTOR
        public AController(IRepositoryServise repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        // GET api/<controller>
        public IEnumerable<TestModel> Get()
        {
            return _repository.GetAllTestModels();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.GetTestModelById(id));
        }

        public async Task<IHttpActionResult> GetAsync(int id)
        {
            return await Task.FromResult(Get(id));
        }

        // POST api/<controller>
        public void Post([FromBody]TestModel value)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertTestModel(value);
            }
        }

        // PUT api/<controller>/5
        public void Put([FromBody]TestModel value)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateTestModel(value);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(TestModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.DeleteTestModel(model);
            }
        }
        #endregion
    }
}
