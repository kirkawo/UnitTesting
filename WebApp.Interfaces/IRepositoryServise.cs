using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Interfaces
{
    public interface IRepositoryServise
    {
        IEnumerable<TestModel> GetAllTestModels();

        void DeleteTestModel(TestModel testModel);

        void DeleteTestModel(IEnumerable<TestModel> testModels);

        void InsertTestModel(TestModel testModel);

        void InsertTestModel(IEnumerable<TestModel> testModels);

        void UpdateTestModel(TestModel testModel);

        void UpdateTestModel(IEnumerable<TestModel> testModels);
    }
}
