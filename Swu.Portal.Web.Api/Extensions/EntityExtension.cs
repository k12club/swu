using AutoMapper;
using Swu.Portal.Data.Models;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api
{
    public static class EntityExtension
    {
        private const string DEFAULT_IMG = "Content/images/default.jpg";

        public static UserLoginProxy ToUserLoginViewModel(this ApplicationUser data)
        {
            return Mapper.Map<UserLoginProxy>(data);
        }
        public static ApplicationUser ToEntity(this UserLoginProxy data)
        {
            return Mapper.Map<ApplicationUser>(data);
        }

        public static UserProfile ToUserProfileViewModel(this ApplicationUser u, string selectedRoleName)
        {
            return new UserProfile
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName_EN = u.FirstName_EN,
                LastName_EN = u.LastName_EN,
                FirstName_TH = u.FirstName_TH,
                LastName_TH = u.LastName_TH,
                Email = u.Email,
                SelectedRoleName = selectedRoleName,
                ImageUrl = string.IsNullOrEmpty(u.ImageUrl) ? DEFAULT_IMG : u.ImageUrl,
                Position = u.Position,
                Tag = u.Tag,
                Description = u.Description,
                CreatedDate = u.CreatedDate,
                UpdateDate = u.UpdatedDate,
                RegistrationDate = u.RegistrationDate
            };
        }
        public static ApplicationUser ToEntity(this UserProfile u)
        {
            return new ApplicationUser
            {
                UserName = u.UserName,
                FirstName_EN = u.FirstName_EN,
                LastName_EN = u.LastName_EN,
                FirstName_TH = u.FirstName_TH,
                LastName_TH = u.LastName_TH,
                Email = u.Email,
                ImageUrl = u.ImageUrl,
                Position = u.Position,
                Tag = u.Tag,
                Description = u.Description
            };
        }

        public static CourseDetailProxy ToViewModel(this Data.Models.Course c)
        {
            return new CourseDetailProxy(c);
        }
        public static Course ToEntity(this CourseDetailProxy c, ApplicationUser user)
        {
            return new Data.Models.Course
            {
                //Id = c.Id,
                ImageUrl = c.ImageUrl,
                Language = c.Language,
                Name_EN = c.Name_EN,
                Name_TH = c.Name_TH,
                Price = c.Price,
                FullDescription = c.FullDescription,
                BigImageUrl = c.BigImageUrl,
                CategoryId = c.CategoryId,
                CreatedDate = c.CreatedDate,
                CreatedUser = user.Id,
                UpdatedDate = c.UpdateDate
            };
        }
    }
}
