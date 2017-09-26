using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api
{
    public class DepartmentProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        public DepartmentProxy()
        {

        }
        public DepartmentProxy(Department department)
        {
            this.Id = department.Id;
            this.Name = department.Name;
        }
    }
}
