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
        public static UserLoginProxy ToUserLoginViewModel(this ApplicationUser data)
        {
            return Mapper.Map<UserLoginProxy>(data);
        }
        public static ApplicationUser ToEntity(this UserLoginProxy data)
        {
            return Mapper.Map<ApplicationUser>(data);
        }
        public static UserProfile ToUserProfileViewModel(this ApplicationUser u, string selectedRoleName,string defaultImageUrl)
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
                ImageUrl = string.IsNullOrEmpty(u.ImageUrl) ? defaultImageUrl : u.ImageUrl,
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
        public static Course ToEntity(this CourseDetailProxy course)
        {
            return new Data.Models.Course
            {
                Id = course.Id,
                ImageUrl = course.ImageUrl,
                Language = course.Language,
                Name_EN = course.Name_EN,
                Name_TH = course.Name_TH,
                Price = course.Price,
                FullDescription = course.FullDescription,
                BigImageUrl = course.BigImageUrl,
                CategoryId = course.CategoryId,
                CreatedDate = course.CreatedDate,
                CreatedUser = course.CreatedUserId,
                UpdatedDate = course.UpdateDate
            };
        }
        public static Curriculum ToEntity(this CurriculumProxy curriculum)
        {
            return new Data.Models.Curriculum
            {
                Name = curriculum.Name,
                CourseId = curriculum.CourseId,
                Type = (CurriculumType)curriculum.Type,
                NumberOfTime = curriculum.NumberOfTime
            };
        }
        public static Photo ToEntity(this PhotoProxy photo)
        {
            return new Data.Models.Photo
            {
                Name = photo.Name,
                ImageUrl = photo.ImageUrl,
                PublishedDate = photo.PublishedDate
            };
        }
    }
}
