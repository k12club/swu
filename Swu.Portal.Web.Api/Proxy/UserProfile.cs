using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api
{
    public class UserProfile
    {
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "firstName_en")]
        public string FirstName_EN { get; set; }
        [JsonProperty(PropertyName = "lastName_en")]
        public string LastName_EN { get; set; }
        [JsonProperty(PropertyName = "firstName_th")]
        public string FirstName_TH { get; set; }
        [JsonProperty(PropertyName = "lastName_th")]
        public string LastName_TH { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "selectedRoleName")]
        public string SelectedRoleName { get; set; }
    }
}
