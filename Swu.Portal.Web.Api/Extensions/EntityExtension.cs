using AutoMapper;
using Swu.Portal.Data.Models;
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

        public static UserProfile ToUserProfileViewModel(this ApplicationUser data)
        {
            return Mapper.Map<UserProfile>(data);
        }
        public static ApplicationUser ToEntity(this UserProfile data)
        {
            return Mapper.Map<ApplicationUser>(data);
        }

    }
}
