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
        public static UserProfile ToUserProfileViewModel(this ApplicationUser u, string selectedRoleName, string defaultImageUrl)
        {
            var user = new UserProfile
            {
                Id = u.Id,
                UserName = u.UserName,

                FirstName_EN = u.FirstName_EN,
                LastName_EN = u.LastName_EN,
                Position_EN = u.Position_EN,
                Tag_EN = u.Tag_EN,
                Description_EN = u.Description_EN,

                FirstName_TH = u.FirstName_TH,
                LastName_TH = u.LastName_TH,
                Position_TH = u.Position_TH,
                Tag_TH = u.Tag_TH,
                Description_TH = u.Description_TH,

                Email = u.Email,
                SelectedRoleName = selectedRoleName,
                ImageUrl = string.IsNullOrEmpty(u.ImageUrl) ? defaultImageUrl : u.ImageUrl,
                LineId = u.LineId,
                Mobile = u.Mobile,
                OfficeTel = u.OfficeTel,
                CreatedDate = u.CreatedDate,
                UpdateDate = u.UpdatedDate,

                StudentId = u.StudentId,
                PassportId = u.PassportId,
            };
            user.Department = (u.Department != null) ? new DepartmentProxy(u.Department) : new DepartmentProxy();
            user.DepartmentId = (u.Department != null) ? u.Department.Id : 0;

            user.University = (u.University != null) ? new UniversityProxy(u.University) : new UniversityProxy();
            user.UniversityId = (u.University != null) ? u.University.Id : 0;

            //user.ReferenceUser = (u.ReferenceUser != null) ? new UserProfile(u.ReferenceUser) : new UserProfile();
            //user.ReferenceUserId = (u.ReferenceUser != null) ? u.ReferenceUser.Id : "";

            user.PersonalFiles = (u.PersonalFile != null)? u.PersonalFile.Select(f=>new AttachFilesProxy(f)).ToList() : new List<AttachFilesProxy>();
            return user;
        }
        public static ApplicationUser ToEntity(this UserProfile u)
        {
            return new ApplicationUser
            {
                UserName = u.UserName,
                FirstName_EN = u.FirstName_EN,
                LastName_EN = u.LastName_EN,
                Position_EN = u.Position_EN,
                Description_EN = u.Description_EN,
                Tag_EN = u.Tag_EN,

                FirstName_TH = u.FirstName_TH,
                LastName_TH = u.LastName_TH,
                Position_TH = u.Position_TH,
                Description_TH = u.Description_TH,
                Tag_TH = u.Tag_TH,

                Email = u.Email,
                ImageUrl = u.ImageUrl,

                LineId = u.LineId,
                Mobile = u.Mobile,
                OfficeTel = u.OfficeTel
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
