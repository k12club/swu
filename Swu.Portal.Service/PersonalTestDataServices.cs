using Swu.Portal.Data.Repository;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IPersonalTestDataServices
    {
        IEnumerable<PersonalTestData> GetAllData();
    }
    public class PersonalTestDataServices : IPersonalTestDataServices
    {
        private readonly IRepository<PersonalTestData> _repo;
        public PersonalTestDataServices(IRepository<PersonalTestData> repo)
        {
            this._repo = repo;
        }
        public IEnumerable<PersonalTestData> GetAllData()
        {
            var data = this._repo.List.ToList();
            return data;
        }
    }
}
