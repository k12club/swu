using Newtonsoft.Json;
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
        private const string UPLOAD_DIR = "FileUpload/users/";
        private readonly IApplicationUserServices _applicationUserServices;
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IConfigurationRepository _configurationRepository;
        public AccountController(
            IApplicationUserServices applicationUserServices,
            IDateTimeRepository datetimeRepository,
            IConfigurationRepository configurationRepository)
        {
            this._applicationUserServices = applicationUserServices;
            this._datetimeRepository = datetimeRepository;
            this._configurationRepository = configurationRepository;
        }
        [HttpPost, Route("login")]
        public UserProfile Login(UserLoginProxy model)
        {
            if (ModelState.IsValid)
            {
                var u = this._applicationUserServices.VerifyAndGetUser(model.UserName, model.Password);
                var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
                return u.ToUserProfileViewModel(selectedRoleName, this._configurationRepository.DefaultUserImage);
            }
            return null;
        }
        [HttpPost, Route("login2")]
        public UserProfile Login(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                var u = this._applicationUserServices.VerifyWithCurrentUser(model.ToEntity());
                var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
                return u.ToUserProfileViewModel(selectedRoleName, this._configurationRepository.DefaultUserImage);
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
                    Position_EN = model.Position_EN,
                    Tag_EN = model.Tag_EN,
                    Description_EN = model.Description_EN,
                    Position_TH = model.Position_TH,
                    Tag_TH = model.Tag_TH,
                    Description_TH = model.Description_TH,
                    LineId = model.LineId,
                    Mobile = model.Mobile,
                    OfficeTel = model.OfficeTel,
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
                result.Add(u.ToUserProfileViewModel(selectedRoleName, this._configurationRepository.DefaultUserImage));
            }
            return result;
        }
        [HttpGet, Route("getById")]
        public UserProfile GetById(string id)
        {
            var u = this._applicationUserServices.getById(id);
            var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
            return u.ToUserProfileViewModel(selectedRoleName, this._configurationRepository.DefaultUserImage);
        }
        [HttpPost, Route("uploadAsync")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                UserProfile user = new UserProfile();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("user"))
                    {
                        var json = provider.FormData[key.ToString()];
                        user = JsonConvert.DeserializeObject<UserProfile>(json);
                    }
                }
                string _newFileName = string.Empty;
                string _path = string.Empty;
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
                    _newFileName = string.Format("{0}{1}", user.Id, Path.GetExtension(fileName));
                    _path = string.Format("{0}{1}", UPLOAD_DIR, _newFileName);
                    var moveTo = Path.Combine(root, _newFileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    _path = string.Format("{0}{1}", UPLOAD_DIR, _newFileName);
                    File.Move(file.LocalFileName, moveTo);
                    user.ImageUrl = string.Format("{0}?{1}", _path, this._datetimeRepository.Now());
                }
                this._applicationUserServices.Update(user.ToEntity(), user.SelectedRoleName);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpGet, Route("teachers")]
        public List<UserProfile> GetAllTeachers()
        {
            var teachers = new List<UserProfile>();
            var users = this._applicationUserServices.GetAllUsers();
            foreach (var user in users)
            {
                var roles = this._applicationUserServices.GetRolesByUserName(user.UserName);
                if (roles.Count() > 0)
                {
                    if (roles.FirstOrDefault().Equals("Teacher"))
                    {
                        teachers.Add(new UserProfile()
                        {
                            Id = user.Id,
                            ImageUrl = user.ImageUrl,
                            FirstName_EN = user.FirstName_EN,
                            LastName_EN = user.LastName_EN,
                            FirstName_TH = user.FirstName_TH,
                            LastName_TH = user.LastName_TH,
                            Description_EN = user.Description_EN,
                            Description_TH = user.Description_TH,
                            Email = user.Email,
                            Position_EN = user.Position_EN,
                            Position_TH = user.Position_TH,
                            Tag_EN = user.Tag_EN,
                            Tag_TH = user.Tag_TH,
                            LineId = user.LineId,
                            Mobile = user.Mobile,
                            OfficeTel = user.OfficeTel,
                            CreatedDate = user.CreatedDate
                        });
                    }
                }
            }
            return teachers;
        }
    }
}
