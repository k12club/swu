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
        private readonly IReferenceUserService _referenceUserService;
        public AccountController(
            IApplicationUserServices applicationUserServices,
            IDateTimeRepository datetimeRepository,
            IConfigurationRepository configurationRepository,
            IReferenceUserService referenceUserService)
        {
            this._applicationUserServices = applicationUserServices;
            this._datetimeRepository = datetimeRepository;
            this._configurationRepository = configurationRepository;
            this._referenceUserService = referenceUserService;
        }
        [HttpPost, Route("login")]
        public async Task<UserProfile> Login(UserLoginProxy model)
        {
            if (ModelState.IsValid)
            {
                var u = await this._applicationUserServices.VerifyAndGetUser(model.UserName, model.Password);
                var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
                var data = u.ToUserProfileViewModel(selectedRoleName, this._configurationRepository.DefaultUserImage);
                if (data.SelectedRoleName == "Parent")
                {
                    var c = this._referenceUserService.GetReferenceUserByParentId(data.Id);
                    if (c != null)
                    {
                        var child = this._applicationUserServices.FindById(c.ChildId);
                        data.Child = child.ToUserProfileViewModel("Student", null);
                        data.Child.Approve = c.Approved;
                        if (model.Language.Equals("en"))
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", child.FirstName_EN, child.LastName_EN);
                        }
                        else
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", child.FirstName_TH, child.LastName_TH);
                        }
                    }
                }
                else if (data.SelectedRoleName == "Student")
                {
                    var p = this._referenceUserService.GetReferenceUserByChildId(data.Id);
                    if (p != null)
                    {
                        var parent = this._applicationUserServices.FindById(p.ParentId);
                        data.Parent = parent.ToUserProfileViewModel("Parent", null);
                        data.Parent.Approve = p.Approved;
                        if (model.Language.Equals("en"))
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", parent.FirstName_EN, parent.LastName_EN);
                        }
                        else
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", parent.FirstName_TH, parent.LastName_TH);
                        }
                    }
                }
                return data;
            }
            return null;
        }
        [HttpPost, Route("login2")]
        public async Task<UserProfile> Login(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                var u = await this._applicationUserServices.VerifyWithCurrentUser(model.ToEntity());
                var selectedRoleName = this._applicationUserServices.GetRolesByUserName(u.UserName).FirstOrDefault();
                var data = u.ToUserProfileViewModel(selectedRoleName, this._configurationRepository.DefaultUserImage);
                if (data.SelectedRoleName == "Parent")
                {
                    var c = this._referenceUserService.GetReferenceUserByParentId(data.Id);
                    if (c != null)
                    {
                        var child = this._applicationUserServices.FindById(c.ChildId);
                        data.Child = child.ToUserProfileViewModel("Student", null);
                        data.Child.Approve = c.Approved;
                        if (model.Language.Equals("en"))
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", child.FirstName_EN, child.LastName_EN);
                        }
                        else
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", child.FirstName_TH, child.LastName_TH);
                        }
                    }
                }
                else if (data.SelectedRoleName == "Student")
                {
                    var p = this._referenceUserService.GetReferenceUserByChildId(data.Id);
                    if (p != null)
                    {
                        var parent = this._applicationUserServices.FindById(p.ParentId);
                        data.Parent = parent.ToUserProfileViewModel("Parent", null);
                        data.Parent.Approve = p.Approved;
                        if (model.Language.Equals("en"))
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", parent.FirstName_EN, parent.LastName_EN);
                        }
                        else
                        {
                            data.ReferenceUserName = string.Format("{0} {1}", parent.FirstName_TH, parent.LastName_TH);
                        }
                    }
                }
                return data;
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
                string lang = "";
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("user"))
                    {
                        var json = provider.FormData[key.ToString()];
                        user = JsonConvert.DeserializeObject<UserProfile>(json);
                    }
                    else if (key.Equals("lang"))
                    {
                        var json = provider.FormData[key.ToString()];
                        lang = JsonConvert.DeserializeObject<string>(json);
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

                if (user.SelectedRoleName == "Parent")
                {
                    var fullname = user.ReferenceUserName.Split(' ');
                    ApplicationUser referenceUser = null;
                    if (lang.Equals("en"))
                    {
                        referenceUser = await this._applicationUserServices.FindByFirstNameAndLastNameEN(fullname[0], fullname[1]);
                    }
                    else
                    {
                        referenceUser = await this._applicationUserServices.FindByFirstNameAndLastNameTH(fullname[0], fullname[1]);
                    }
                    this.AddReferenceUser(user.Id, referenceUser);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        private void AddReferenceUser(string parentId, ApplicationUser child)
        {
            if (child != null)
            {
                this._referenceUserService.AddOrUpdateUserReference(child, parentId);
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
        [HttpGet, Route("getUsersByName")]
        public List<string> GetUsersByName(string name, string lang)
        {
            var returnResult = new List<string>();
            if (name != null)
            {
                if (lang.Equals("en"))
                {
                    var users = this._applicationUserServices.GetAllUsers()
                                        .Where(
                                            i =>
                                                (i.FirstName_EN.ToLower().Contains(name.ToLower()) || i.LastName_EN.ToLower().Contains(name.ToLower()))
                                            )
                                        .ToList();
                    foreach (var user in users)
                    {
                        var role = this._applicationUserServices.GetRolesByUserName(user.UserName).FirstOrDefault();
                        if (role != null)
                        {
                            if (role.Equals("Student"))
                            {
                                returnResult.Add(user.FirstName_EN + " " + user.LastName_EN);
                            }
                        }
                    }
                }
                else
                {
                    var users = this._applicationUserServices.GetAllUsers()
                    .Where(
                        i =>
                            (i.FirstName_TH.ToLower().Contains(name.ToLower()) || i.LastName_TH.ToLower().Contains(name.ToLower()))
                        )
                    .ToList();
                    foreach (var user in users)
                    {
                        var role = this._applicationUserServices.GetRolesByUserName(user.UserName).FirstOrDefault();
                        if (role != null)
                        {
                            if (role.Equals("Student"))
                            {
                                returnResult.Add(user.FirstName_TH + " " + user.LastName_TH);
                            }
                        }
                    }
                }
            }
            return returnResult;
        }
        [HttpGet, Route("approveRequest")]
        public HttpResponseMessage ApproveRequest(string childId, string parentId)
        {
            try
            {
                this._referenceUserService.ApproveRequest(childId, parentId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpGet, Route("rejectRequest")]
        public HttpResponseMessage RejectRequest(string childId, string parentId)
        {
            try
            {
                this._referenceUserService.RejectRequest(childId, parentId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
