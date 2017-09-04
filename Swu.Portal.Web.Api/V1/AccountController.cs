using Swu.Portal.Data.Models;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/Account")]
    public class AccountController : ApiController
    {
        private readonly IApplicationUserServices _applicationUserServices;
        public AccountController(IApplicationUserServices applicationUserServices)
        {
            this._applicationUserServices = applicationUserServices;
        }
        [HttpPost, Route("login")]
        public UserProfile Login(UserLoginProxy model)
        {

            //mockup data:
            //username:chansak
            //password:password
            if (ModelState.IsValid)
            {
                var u = this._applicationUserServices.VerifyAndGetUser(model.UserName, model.Password);
                var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
                return new UserProfile
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName_EN = u.FirstName_EN,
                    LastName_EN = u.LastName_EN,
                    FirstName_TH = u.FirstName_TH,
                    LastName_TH = u.LastName_TH,
                    Email = u.Email,
                    SelectedRoleName = selectedRoleName
                };
            }
            return null;
        }
        [HttpPost, Route("addNew")]
        public bool AddNew(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName_EN = model.FirstName_EN,
                    LastName_EN = model.LastName_EN,
                    Email = model.Email,
                };
                return this._applicationUserServices.AddNewUser(user, model.Password, model.SelectedRoleName);
            }
            return false;
        }
        [HttpGet, Route("all")]
        public List<UserProfile> GetAll()
        {
            var result = new List<UserProfile>();
            var users = this._applicationUserServices.GetAllUsers().ToList();
            foreach (var u in users)
            {
                var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
                result.Add(new UserProfile
                {
                    Id =u.Id,
                    UserName = u.UserName,
                    FirstName_EN = u.FirstName_EN,
                    LastName_EN = u.LastName_EN,
                    FirstName_TH = u.FirstName_TH,
                    LastName_TH = u.LastName_TH,
                    Email = u.Email,
                    SelectedRoleName = selectedRoleName
                });
            }
            return result;
        }
        [HttpGet, Route("getById")]
        public UserProfile GetById(string id)
        {
            var u = this._applicationUserServices.getById(id);
            var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
            return new UserProfile
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName_EN = u.FirstName_EN,
                LastName_EN = u.LastName_EN,
                FirstName_TH = u.FirstName_TH,
                LastName_TH = u.LastName_TH,
                Email = u.Email,
                SelectedRoleName = selectedRoleName
            };
        }
    }
}
