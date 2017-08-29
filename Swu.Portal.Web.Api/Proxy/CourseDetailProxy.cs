using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CourseAllDetailProxy
    {
        [JsonProperty(PropertyName = "course")]
        public CourseDetailProxy CourseInfo { get; set; }
        [JsonProperty(PropertyName = "curriculums")]
        public List<CurriculumProxy> Curriculums { get; set; }
        [JsonProperty(PropertyName = "teachers")]
        public List<TeacherProxy> Teacher { get; set; }
        [JsonProperty(PropertyName = "students")]
        public List<StudentProxy> Students { get; set; }
        [JsonProperty(PropertyName = "photosAlbum")]
        public PhotoAlbumProxy PhotosAlbum { get; set; }
        public CourseAllDetailProxy(Course c)
        {
            this.Curriculums = new List<CurriculumProxy>();
            this.Teacher = new List<TeacherProxy>();
            this.Students = new List<StudentProxy>();
            this.PhotosAlbum = new PhotoAlbumProxy();

            this.CourseInfo = new CourseDetailProxy {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Language = c.Language,
                Name_EN = c.Name_EN,
                Name_TH = c.Name_TH,
                Price = c.Price,
                FullDescription = c.FullDescription,
                BigImageUrl = c.BigImageUrl,
                NumberOfLecture = c.Curriculums.Where(i => i.Type == CurriculumType.Lecture).Count(),
                NumberOfQuizes = c.Curriculums.Where(i => i.Type == CurriculumType.Quize).Count(),
                NumberOfStudents = c.Students.Count(),
                NumberOfTeachers = c.Teachers.Count(),
                NumberOfTimes = c.Curriculums.Sum(i => i.NumberOfTime),
            };
            foreach (var cur in c.Curriculums) {
                this.Curriculums.Add(new CurriculumProxy(cur));
            }
            foreach (var t in c.Teachers) {
                this.Teacher.Add(new TeacherProxy(t));
            }
            foreach (var s in c.Students) {
                this.Students.Add(new StudentProxy(s));
            }
            this.PhotosAlbum = new PhotoAlbumProxy(c.PhotoAlbums.FirstOrDefault());
        }
    }
    public class CourseBriefDetailProxy
    {
        [JsonProperty(PropertyName = "course")]
        public CourseDetailProxy CourseInfo { get; set; }
        [JsonProperty(PropertyName = "teachers")]
        public List<TeacherProxy> Teacher { get; set; }
        public CourseBriefDetailProxy(Course c)
        {
            this.CourseInfo = new CourseDetailProxy
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Language = c.Language,
                Name_EN = c.Name_EN,
                Name_TH = c.Name_TH,
                Price = c.Price,
                FullDescription = c.FullDescription,
                BigImageUrl = c.BigImageUrl,
                NumberOfLecture = c.Curriculums.Where(i => i.Type == CurriculumType.Lecture).Count(),
                NumberOfQuizes = c.Curriculums.Where(i => i.Type == CurriculumType.Quize).Count(),
                NumberOfStudents = c.Students.Count(),
                NumberOfTeachers = c.Teachers.Count(),
                NumberOfTimes = c.Curriculums.Sum(i => i.NumberOfTime),
            };
            foreach (var t in c.Teachers)
            {
                this.Teacher.Add(new TeacherProxy(t));
            }
        }
    }
}
