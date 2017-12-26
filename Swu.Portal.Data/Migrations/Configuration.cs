using System.Data.Entity.Migrations;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Security;

namespace Swu.Portal.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Swu.Portal.Data.Context.SwuDBContext>
    {
        private const string CID1 = "2e172c30-ba70-4036-b609-91ecabbad3b7";
        private const string CID2 = "518263c4-888d-48bc-b924-d2ccf9eb9937";
        private const string CID3 = "6a7040c9-ac77-4c5b-bb51-4e830eced91f";
        private const string CID4 = "a6533489-8ebe-45eb-ac86-b9c2a12840a5";
        private const string CID5 = "ce4bcf32-41af-49bb-9183-a815780eebfd";
        private const string CID6 = "d5429b19-de51-48f9-bd43-2b2060789a4d";
        private const string CID7 = "e1b8d39e-333b-4af8-9c92-f744427bf3b5";
        private const string CID8 = "f0e86e6e-a1f7-45ee-961b-6addae78a5fe";
        private const string CID9 = "f8d9a209-fe7c-49c0-9c2b-4993d37bdf35";
        private const string PID1 = "a8d9a209-fe7c-49c0-9c2b-4993d37bdf35";

        private const string FID1 = "2e172c30-ba70-4036-b609-91ecabbad3b7";
        private const string FID2 = "518263c4-888d-48bc-b924-d2ccf9eb9937";
        private const string FID3 = "6a7040c9-ac77-4c5b-bb51-4e830eced91f";
        private const string FID4 = "a6533489-8ebe-45eb-ac86-b9c2a12840a5";

        private const string RID3 = "6a7040c9-ac77-4c5b-bb51-4e830eced91f";

        private const string DUMMY_COURSE = "66d77ba7-a6c6-43c7-b023-fe502ce3ddaa";
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(SwuDBContext context)
        {
            this.InitialDatabase(context);
            base.Seed(context);
        }
        private void InitialDatabase(SwuDBContext context)
        {
            var categories = new List<CourseCategory>();
            var courses = new List<Course>();
            var curriculums = new List<Curriculum>();
            var teachers = new List<ApplicationUser>();
            var students = new List<ApplicationUser>();
            var photos = new List<Photo>();
            var fcategories = new List<ForumCategory>();
            var forums = new List<Forum>();
            var comments = new List<Comment>();
            var rcategories = new List<ResearchCategory>();
            var researchs = new List<Research>();
            var studentScores = new List<StudentScore>();
            var events = new List<Event>();
            var university = new List<University>();
            var department = new List<Department>();

            #region University
            var u1 = new University
            {
                Name = "Srinakharinwirot"
            };
            //context.University.Add(u1);
            //context.SaveChanges();
            #endregion
            #region Department
            var d1 = new Department
            {
                Name = "IT"
            };
            //context.Department.Add(d1);
            //context.SaveChanges();
            #endregion
            #region User
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SwuDBContext()));
            var roleNames = new List<string> { "Teacher", "Student", "Parent", "Admin", "Officer" };
            var userRole = new IdentityRole { Name = "Admin", Id = Guid.NewGuid().ToString() };
            var defaultUser = new ApplicationUser
            {
                UserName = "default",
                FirstName_EN = "Emma",
                LastName_EN = "Stone",
                FirstName_TH = "Emma",
                LastName_TH = "Stone",
                Email = "test.test@test.com",
                ImageUrl = "Content/images/courses/s4.png"

            };
            var admin = new ApplicationUser
            {
                UserName = "admin",
                FirstName_EN = "chansak",
                LastName_EN = "kochasen",
                FirstName_TH = "ชาญศักดิ์",
                LastName_TH = "คชเสน",
                Email = "chansakcsc@gmail.com.com",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ImageUrl = "FileUpload/users/chansak.jpg",
                Position_EN = "Professor of Art",
                Tag_EN = "Architectural Studies / History of Art / European Studies",
                Description_EN = "Edward joined Edu Hub in the Crean College of Health and Behavioral Sciences as an Assistant Professor.",
                Position_TH = "Professor of Art",
                Tag_TH = "Architectural Studies / History of Art / European Studies",
                Description_TH = "Edward joined Edu Hub in the Crean College of Health and Behavioral Sciences as an Assistant Professor.",
                LineId = "chansakcsc",
                Mobile = "082-7898386",
                OfficeTel = "(02)-234567",
                Department = d1,
                University = u1
            };
            userManager.Create(admin, "password");
            foreach (var roleName in roleNames)
            {
                roleManager.Create(new IdentityRole { Name = roleName });
            }
            var user = userManager.FindByName(admin.UserName);
            userManager.AddToRole(user.Id, "Admin");
            #endregion
            #region Course Category
            var cat1 = new CourseCategory
            {
                Title = "ชั้นปี 1",
                ApplicationUser = defaultUser
            };
            var cat2 = new CourseCategory
            {
                Title = "ชั้นปี 2",
                ApplicationUser = defaultUser
            };
            var cat3 = new CourseCategory
            {
                Title = "ชั้นปี 3",
                ApplicationUser = defaultUser
            };
            var cat4 = new CourseCategory
            {
                Title = "ชั้นปี 4",
                ApplicationUser = defaultUser
            };
            var cat5 = new CourseCategory
            {
                Title = "ชั้นปี 5",
                ApplicationUser = defaultUser
            };
            categories.Add(cat1);
            categories.Add(cat2);
            categories.Add(cat3);
            categories.Add(cat4);
            categories.Add(cat5);
            #endregion
            #region Course
            var c1 = new Course
            {
                Id = DUMMY_COURSE,
                Name_TH = "DUMMY",
                Name_EN = "DUMMY",
                Category = cat1,
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            courses.Add(c1);
            context.CourseCategory.AddRange(categories);
            context.SaveChanges();

            context.Courses.AddRange(courses);
            context.SaveChanges();
            #endregion
            #region Event
            var e1 = new Event
            {
                Title_EN = "War and Medicine- Lunchtime Talks Series",
                Description_EN = "On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                Place_EN = "Venue: Hall B",
                Title_TH = "รับสมัครสอบตรง",
                Description_TH = "",
                Place_TH = "http://admission.swu.acth",
                ImageUrl = "images/event/1.jpg",
                StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime()
            };
            var e2 = new Event
            {
                Title_EN = "War and Medicine- Lunchtime Talks Series",
                Description_EN = "On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                Place_EN = "Venue: Hall B",
                Title_TH = "ประกาศรายชื่อผู้มีสิทธิ์สอบ",
                Description_TH = "",
                Place_TH = "http://admission.swu.acth",
                ImageUrl = "images/event/1.jpg",
                StartDate = new DateTime(2017, 8, 24, 9, 30, 0).ToUniversalTime()
            };
            var e3 = new Event
            {
                Title_EN = "War and Medicine- Lunchtime Talks Series",
                Description_EN = "On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                Place_EN = "Venue: Hall B",
                Title_TH = "สอบคัดเลือก 1",
                Description_TH = @"09.00-12.00 วิทยาศาสตร์พื้นฐาน
                13.00-15.00 ความถนัดทางการเรียน
                คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                Place_TH = "คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                ImageUrl = "images/event/1.jpg",
                StartDate = new DateTime(2018, 1, 10, 9, 0, 0).ToUniversalTime()
            };
            var e4 = new Event
            {
                Title_EN = "War and Medicine- Lunchtime Talks Series",
                Description_EN = "On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                Place_EN = "Venue: Hall B",
                Title_TH = "ประกาศการสอบขั้นที่ 1",
                Description_TH = "",
                Place_TH = "คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                ImageUrl = "images/event/1.jpg",
                StartDate = new DateTime(2018, 1, 21, 9, 0, 0).ToUniversalTime()
            };
            var e5 = new Event
            {
                Title_EN = "War and Medicine- Lunchtime Talks Series",
                Description_EN = "On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                Place_EN = "Venue: Hall B",
                Title_TH = "ประกาศการสอบขั้นที่ 1",
                Description_TH = "",
                Place_TH = "คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                ImageUrl = "images/event/1.jpg",
                StartDate = new DateTime(2018, 1, 21, 9, 0, 0).ToUniversalTime()
            };
            events.AddRange(new List<Event> { e1, e2, e3, e4, e5 });
            context.Events.AddRange(events);
            context.SaveChanges();
            #endregion

            //#region Video
            //var videos = new List<Video> {
            //        new Video {
            //            ImageUrl="Content/images/campus/ss1.png",
            //            VideoUrl="https://www.youtube.com/watch?v=uUp5O2i-dl8",
            //            Title_EN="Introduction – Srinakharinwirot University",
            //            Title_TH="Introduction – Srinakharinwirot University"
            //        },
            //        new Video {
            //            ImageUrl="Content/images/campus/ss2.png",
            //            VideoUrl="https://www.youtube.com/watch?v=mn_kMVuLsAU",
            //            Title_EN="Srinakharinwirot University from the sky ( มศว.ประสานมิตร)",
            //            Title_TH="Srinakharinwirot University from the sky ( มศว.ประสานมิตร)"
            //        },
            //        new Video {
            //            ImageUrl="Content/images/campus/ss3.png",
            //            VideoUrl="https://www.youtube.com/watch?v=8rZ7DMhEX7I",
            //            Title_EN="Srinakharinwirot University",
            //            Title_TH="Srinakharinwirot University"
            //        },
            //        new Video {
            //            ImageUrl="Content/images/campus/ss4.png",
            //            VideoUrl="https://www.youtube.com/watch?v=GDkfFt7mBFU",
            //            Title_EN="Srinakharinwirot University",
            //            Title_TH="Srinakharinwirot University"
            //        },
            //    };
            //context.Videos.AddRange(videos);
            //#endregion

            #region News
            var news = new List<News>
                {
                    new News {
                        Title_EN="ประกาศรายชื่อผู้มีสิทธิ์สอบคัดเลือก ตำแหน่งนักวิชาการศึกษา สังกัดวิทยาลัยโพธิวิชชาลัย",
                        Title_TH="ประกาศรายชื่อผู้มีสิทธิ์สอบคัดเลือก ตำแหน่งนักวิชาการศึกษา สังกัดวิทยาลัยโพธิวิชชาลัย",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                    new News {
                        Title_EN="ขอเชิญเข้าร่วมโครงการค่ายสร้างแรงบันดาลใจเพื่อรับใช้สังคม สำหรับบุคลากรมหาวิทยาลัยศรีนครินทรวิโรฒ ระหว่างเดือนพฤศจิกายน 2560 – เดือนมกราคม 2561",
                        Title_TH="ขอเชิญเข้าร่วมโครงการค่ายสร้างแรงบันดาลใจเพื่อรับใช้สังคม สำหรับบุคลากรมหาวิทยาลัยศรีนครินทรวิโรฒ ระหว่างเดือนพฤศจิกายน 2560 – เดือนมกราคม 2561",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                    new News {
                        Title_EN="รับสมัครงาน ตำแหน่งพยาบาล (1) 7 – 1239 สังกัดโรงเรียนสาธิตมหาวิทยาลัยศรีนครินทรวิโรฒ ปทุมวัน",
                        Title_TH="รับสมัครงาน ตำแหน่งพยาบาล (1) 7 – 1239 สังกัดโรงเรียนสาธิตมหาวิทยาลัยศรีนครินทรวิโรฒ ปทุมวัน",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                    new News {
                        Title_EN="การทำประกันอุบัติเหตุกลุ่ม และการทำประกันสุขภาพกลุ่ม",
                        Title_TH="การทำประกันอุบัติเหตุกลุ่ม และการทำประกันสุขภาพกลุ่ม",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                };
            context.News.AddRange(news);
            context.SaveChanges();
            #endregion
        }
    }
}
