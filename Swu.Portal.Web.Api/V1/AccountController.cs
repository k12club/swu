using Swu.Portal.Core.Dependencies;
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
        private readonly IDateTimeRepository _datetimeRepository;
        public AccountController(IApplicationUserServices applicationUserServices, IDateTimeRepository datetimeRepository)
        {
            this._applicationUserServices = applicationUserServices;
            this._datetimeRepository = datetimeRepository;
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
        [HttpPost, Route("addNewOrUpdate")]
        public bool AddNewOrUpdate(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName_EN = model.FirstName_EN,
                    LastName_EN = model.LastName_EN,
                    FirstName_TH = model.FirstName_TH,
                    LastName_TH = model.LastName_TH,
                    Email = model.Email,
                };
                var result = false;
                if (string.IsNullOrWhiteSpace(model.Id)) {
                    user.CreatedDate = this._datetimeRepository.Now();
                    user.UpdatedDate = this._datetimeRepository.Now();
                    result = this._applicationUserServices.AddNewUser(user, model.Password, model.SelectedRoleName);
                } else {
                    user.UpdatedDate = this._datetimeRepository.Now();
                    result = this._applicationUserServices.Update(user, model.SelectedRoleName);
                }
                return result;
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
                    SelectedRoleName = selectedRoleName,
                    CreatedDate = u.CreatedDate,
                    UpdateDate = u.UpdatedDate,
                    RegistrationDate = u.RegistrationDate
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
