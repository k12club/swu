using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swu.Portal.Web.Api
{
    public class UserProfile
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
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
        [JsonProperty(PropertyName = "selectedRoleId")]
        public string SelectedRoleId { get; set; }
        [JsonProperty(PropertyName = "selectedRoleName")]
        public string SelectedRoleName { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        //teacher
        [JsonProperty(PropertyName = "position_en")]
        public string Position_EN { get; set; }
        [JsonProperty(PropertyName = "tag_en")]
        public string Tag_EN { get; set; }
        [JsonProperty(PropertyName = "description_en")]
        public string Description_EN { get; set; }
        [JsonProperty(PropertyName = "position_th")]
        public string Position_TH { get; set; }
        [JsonProperty(PropertyName = "tag_th")]
        public string Tag_TH { get; set; }
        [JsonProperty(PropertyName = "description_th")]
        public string Description_TH { get; set; }


        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }
        [JsonProperty(PropertyName = "mobile")]
        public string Mobile { get; set; }
        [JsonProperty(PropertyName = "officeTel")]
        public string OfficeTel { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty(PropertyName = "updateDate")]
        public DateTime? UpdateDate { get; set; }
        [JsonProperty(PropertyName = "registrationDate")]
        public DateTime? RegistrationDate { get; set; }
        //public UserProfile()
        //{

        //}
        //public UserProfile(ApplicationUser u,string selectedRoleName)
        //{
        //    Id = u.Id;
        //    UserName = u.UserName;
        //    FirstName_EN = u.FirstName_EN;
        //    LastName_EN = u.LastName_EN;
        //    FirstName_TH = u.FirstName_TH;
        //    LastName_TH = u.LastName_TH;
        //    Email = u.Email;
        //    SelectedRoleName = selectedRoleName;
        //    ImageUrl = u.ImageUrl;
        //    Position = u.Position;
        //    Tag = u.Tag;
        //    Description = u.Description;
        //}

    }
}
