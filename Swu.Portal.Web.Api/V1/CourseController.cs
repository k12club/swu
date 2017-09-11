using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Net.Http;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNet.Identity;
using Swu.Portal.Data.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/Course")]
    public class CourseController : ApiController
    {
        private const string UPLOAD_DIR = "FileUpload/course/";
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository2<Course> _courseRepository;
        private readonly IRepository2<PhotoAlbum> _photoAlbumRepository;
        private readonly IRepository<CourseCategory> _courseCategoryRepository;
        private readonly ICourseService _courseService;
        private readonly ICurriculumRepository _curriculumRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IRepository<StudentScore> _studentScoreRepository;
        private readonly IConfigurationRepository _configurationRepository;
        public CourseController(
            IDateTimeRepository datetimeRepository,
            IRepository2<Course> courseRepository,
            IRepository2<PhotoAlbum> photoAlbumRepository,
            IRepository<CourseCategory> courseCategoryRepository,
            ICourseService courseService,
            ICurriculumRepository curriculumRepository,
            IStudentCourseRepository studentCourseRepository,
            IRepository<StudentScore> studentScoreRepository,
            IConfigurationRepository configurationRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._courseRepository = courseRepository;
            this._photoAlbumRepository = photoAlbumRepository;
            this._courseCategoryRepository = courseCategoryRepository;
            this._courseService = courseService;
            this._curriculumRepository = curriculumRepository;
            this._studentCourseRepository = studentCourseRepository;
            this._studentScoreRepository = studentScoreRepository;
            this._configurationRepository = configurationRepository;

        }
        [HttpGet, Route("all")]
        public List<CourseCardProxy> GetAll()
        {
            if (ModelState.IsValid)
            {
                var cards = new List<CourseCardProxy>();
                var courses = this._courseRepository.List.OrderByDescending(o => o.CreatedDate).ToList();
                foreach (var c in courses)
                {
                    cards.Add(new CourseCardProxy(c));
                }
                var result = new List<CourseCardProxy>();
                result.AddRange(cards.Where(i => i.CardType == Enum.CardType.Recently).Take(4));
                result.AddRange(cards.Where(i => i.CardType == Enum.CardType.Popular).Take(4));
                result.AddRange(cards.Where(i => i.CardType == Enum.CardType.TopRate).Take(4));
                return result;
            }
            return null;
        }
        [HttpGet, Route("allCourse")]
        public List<CourseDetailProxy> GetAllCourse()
        {
            return this._courseRepository.List.Select(c => c.ToViewModel()).ToList();
        }
        [HttpGet, Route("getCourseById")]
        public CourseDetailProxy GetCourseById(string id)
        {
            return this._courseRepository.FindById(id).ToViewModel();
        }
        [HttpGet, Route("getById")]
        public CourseAllDetailProxy GetById(string id)
        {
            var course = this._courseRepository.FindById(id);
            var allDetail = new CourseAllDetailProxy(course);
            List<Dictionary<int, StudentScoreProxy>> studentScores = new List<Dictionary<int, StudentScoreProxy>>();
            foreach (var c in allDetail.Curriculums)
            {
                var score = this._studentScoreRepository.List.Where(i => i.CurriculumId == c.Id);
                foreach (var sc in score)
                {
                    c.StudentScores.Add(new StudentScoreProxy(sc));
                }
            }
            var studentCourse = this._studentCourseRepository.FindByCourseId(id).ToList();
            allDetail.Students.AddRange(studentCourse.Select(i => new StudentProxy(i)));
            var photos = this._photoAlbumRepository.FindById(allDetail.PhotosAlbum.Id);
            if (photos != null)
            {
                foreach (var p in photos.Photos)
                {
                    allDetail.PhotosAlbum.Photos.Add(new PhotoProxy(p));
                }
            }
            return allDetail;
        }
        [HttpGet, Route("allItems")]
        public List<WebboardItemProxy> GetAllItems(string keyword)
        {
            var webboardItems = new List<WebboardItemProxy>();
            var courses = new List<Data.Models.Course>();
            if (keyword.Equals("*"))
            {
                courses = this._courseRepository.List.ToList();
            }
            else
            {
                courses = this._courseRepository.List.Where(i => i.Name_EN.ToLower().Contains(keyword.ToLower()) || i.Name_TH.ToLower().Contains(keyword.ToLower())).ToList();
            }
            foreach (var c in courses)
            {
                webboardItems.Add(new WebboardItemProxy(c,this._configurationRepository.DefaultUserImage));
            }
            return webboardItems;
        }
        [HttpGet, Route("category")]
        public List<WebboardCategoryProxy> GetCategory()
        {
            var webboardCategories = new List<WebboardCategoryProxy>();
            var catgories = this._courseCategoryRepository.List.ToList();
            foreach (var c in catgories)
            {
                webboardCategories.Add(new WebboardCategoryProxy(c));
            }
            return webboardCategories;
        }
        [HttpGet, Route("getCourseByCriteria")]
        public List<CourseBriefDetailProxy> getCourseByCriteria(string keyword)
        {
            var courseBriefDetail = new List<CourseBriefDetailProxy>();
            var courses = this._courseRepository.List.Where(i => i.Name_EN.Contains(keyword) || i.Name_TH.Contains(keyword));
            //foreach (var c in courses)
            //{
            //    courseBriefDetail.Add(new CourseBriefDetailProxy(c));
            //}
            return courses.Select(c => new CourseBriefDetailProxy(c)).ToList();
        }
        [HttpGet, Route("getSlider")]
        public List<SliderProxy> GetSlider()
        {
            return new List<SliderProxy> {
                new SliderProxy {
                    Id=1,
                    Title_EN=@"Receive a world-class <br>
education in the heart of <br>
the west.",
                    Title_TH=@"Receive a world-class <br>
education in the heart of <br>
the west.",
                    Description_EN="Top rated for combining academic quality and outdoor reacreation.",
                    Description_TH="Top rated for combining academic quality and outdoor reacreation.",
                    ImageUrl="Content/images/home/h1.jpg"
                },
                new SliderProxy {
                    Id=1,
                    Title_EN=@"Want to experience how life is <br>
on our campus?",
                    Title_TH=@"Want to experience how life is <br>
on our campus?",
                    Description_EN="Learning Resources Centre, a student social space.",
                    Description_TH="Learning Resources Centre, a student social space.",
                    ImageUrl="Content/images/home/h2.jpg"
                },
                new SliderProxy {
                    Id=1,
                    Title_EN=@" Make a bold decision today <br>
and start a new fresh tomorrow. ",
                    Title_TH=@" Make a bold decision today <br>
and start a new fresh tomorrow. ",
                    Description_EN="Top rated for combining academic quality and outdoor reacreation.",
                    Description_TH="Top rated for combining academic quality and outdoor reacreation.",
                    ImageUrl="Content/images/home/h3.jpg"
                }
            };
        }
        [HttpPost, Route("SaveAsync")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var GuID = Guid.NewGuid().ToString();
            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                CourseDetailProxy course = new CourseDetailProxy();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("course"))
                    {
                        var json = provider.FormData[key.ToString()];
                        course = JsonConvert.DeserializeObject<CourseDetailProxy>(json);
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
                    _path = string.Format("{0}{1}", UPLOAD_DIR, fileName);
                    var moveTo = Path.Combine(root, fileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    _path = string.Format("{0}{1}", UPLOAD_DIR, fileName);
                    File.Move(file.LocalFileName, moveTo);
                    course.ImageUrl = string.Format("{0}?{1}", _path, this._datetimeRepository.Now());
                }
                if (string.IsNullOrEmpty(course.Id))
                {
                    course.Id = GuID;
                    this._courseService.Add(course.ToEntity(), course.CreatedUserId);

                }
                else
                {
                    var c = this._courseRepository.FindById(course.Id);
                    c.ImageUrl = course.ImageUrl;
                    c.Language = course.Language;
                    c.Name_EN = course.Name_EN;
                    c.Name_TH = course.Name_TH;
                    c.Price = course.Price;
                    c.FullDescription = course.FullDescription;
                    c.BigImageUrl = course.BigImageUrl;
                    c.CategoryId = course.CategoryId;
                    c.UpdatedDate = this._datetimeRepository.Now();
                    c.UpdatedUser = course.CreatedUserId;
                    this._courseService.Update(c);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpPost, Route("addOrUpdateCurriculum")]
        public CurriculumProxy AddOrUpdateCurriculum(CurriculumProxy curriculum)
        {
            if (curriculum.Id == 0)
            {
                var course = this._courseRepository.FindById(curriculum.CourseId);
                course.Curriculums.Add(curriculum.ToEntity());
                this._courseRepository.Update(course);
            }
            else
            {
                var c = this._curriculumRepository.FindById(curriculum.Id);
                c.Name = curriculum.Name;
                c.Type = (CurriculumType)curriculum.Type;
                c.NumberOfTime = curriculum.NumberOfTime;
                this._curriculumRepository.Update(c);
            }
            return curriculum;
        }
        [HttpGet, Route("getCurriculumById")]
        public CurriculumProxy GetCurriculumById(int id)
        {
            var curriculum = this._curriculumRepository.FindById(id);
            return new CurriculumProxy(curriculum);
        }
        [HttpGet, Route("takeCourse")]
        public void TakeCourse(string courseId, string studentId)
        {
            this._courseService.AddStudent(courseId, studentId);
        }
        [HttpGet, Route("removeCourse")]
        public void RemoveCourse(string courseId, string studentId)
        {
            this._courseService.RemoveStudent(courseId, studentId);
        }
        [HttpGet, Route("approveTakeCourse")]
        public void ApproveTakeCourse(string courseId, string studentId)
        {
            var course = this._courseRepository.FindById(courseId);
            this._courseService.ApproveTakeCourse(course, studentId);
            this.AddApprovedStudentToCurriculum(course.Id, studentId);
        }
        private void AddApprovedStudentToCurriculum(string courseId, string studentId)
        {
            var courses = this._courseRepository.FindById(courseId);
            var registered = this._studentCourseRepository.List.Where(i => i.Course.Id == courseId && i.Student.Id == studentId);
            foreach (var c in courses.Curriculums)
            {
                if (c.Type == CurriculumType.Quize)
                {
                    foreach (var ss in registered)
                    {
                        var existing = this._studentScoreRepository.List.Where(i => i.Student.Id == ss.Student.Id && i.CurriculumId == c.Id).ToList();
                        if (existing.Count() == 0)
                        {
                            var score = new StudentScore
                            {
                                CurriculumId = c.Id,
                                Student = ss.Student,
                                Score = 0
                            };
                            this._curriculumRepository.Add(c, score);
                        }
                    }
                }
            }
        }
    }
}
