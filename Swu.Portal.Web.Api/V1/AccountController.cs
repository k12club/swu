using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/Account")]
    public class AccountController : ApiController
    {
        private const string UPLOAD_DIR = "uploads";

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
                return Mapping(u, selectedRoleName);
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
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    user.CreatedDate = this._datetimeRepository.Now();
                    user.UpdatedDate = this._datetimeRepository.Now();
                    result = this._applicationUserServices.AddNewUser(user, model.Password, model.SelectedRoleName);
                }
                else
                {
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
                result.Add(Mapping(u, selectedRoleName));
            }
            return result;
        }
        [HttpGet, Route("getById")]
        public UserProfile GetById(string id)
        {
            var u = this._applicationUserServices.getById(id);
            var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
            return Mapping(u, selectedRoleName);
        }
        [HttpPost, Route("uploadAsync")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/FileUpload/users/");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    string fileName = file.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    var moveTo = Path.Combine(root, fileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    File.Move(file.LocalFileName, moveTo);
                }
                foreach (var key in provider.FormData)
                {
                    var val = provider.FormData[key.ToString()];
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        private UserProfile Mapping(ApplicationUser u, string selectedRoleName)
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
                ImageUrl = u.ImageUrl,
                Position = u.Position,
                Tag = u.Tag,
                Description = u.Description
            };
        }
    }
}
