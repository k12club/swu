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
                UserName = "chansak",
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
            var student = new ApplicationUser
            {
                UserName = "std1",
                FirstName_EN = "Alex",
                LastName_EN = "Rendal",
                FirstName_TH = "",
                LastName_TH = "",
                Email = "chansakcsc@gmail.com.com",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            userManager.Create(admin, "password");
            userManager.Create(student, "password");
            foreach (var roleName in roleNames)
            {
                roleManager.Create(new IdentityRole { Name = roleName });
            }
            var user = userManager.FindByName(admin.UserName);
            userManager.AddToRole(user.Id, "Teacher");
            var std1 = userManager.FindByName(student.UserName);
            userManager.AddToRole(student.Id, "Student");
            #endregion

            #region Curriculum
            var cur1 = new Curriculum
            {
                Name = "Lecture 1.1 Practical language work",
                Type = CurriculumType.Lecture,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            var cur2 = new Curriculum
            {
                Name = "Lecture 1.2 Study of important works and/or topics",
                Type = CurriculumType.Lecture,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            var cur3 = new Curriculum
            {
                Name = "Lecture 1.3 Literature of the language",
                Type = CurriculumType.Lecture,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            var cur4 = new Curriculum
            {
                Name = "Quizzes History of the language test",
                Type = CurriculumType.Quize,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            var cur5 = new Curriculum
            {
                Name = "Lecture 1.4 General linguistics",
                Type = CurriculumType.Lecture,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            var cur6 = new Curriculum
            {
                Name = "Lecture 1.5 Phonetics and phonology ",
                Type = CurriculumType.Lecture,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            var cur7 = new Curriculum
            {
                Name = "Lecture 1.6 Grammatical analysis",
                Type = CurriculumType.Lecture,
                CourseId = CID1,
                NumberOfTime = 2,
                ApplicationUser = defaultUser
            };
            curriculums.Add(cur1);
            curriculums.Add(cur2);
            curriculums.Add(cur3);
            curriculums.Add(cur4);
            curriculums.Add(cur5);
            curriculums.Add(cur6);
            curriculums.Add(cur7);
            #endregion

            #region Teacher
            var t1 = new ApplicationUser
            {
                UserName = "teacher1",
                FirstName_EN = "teacher1",
                LastName_EN = "teacher1",
                FirstName_TH = "teacher1",
                LastName_TH = "teacher1",
                Email = "test.test@test.com",
                ImageUrl = "Content/images/courses/s4.png",
                Description_EN = "Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures.",
            };
            var t2 = new ApplicationUser
            {
                UserName = "teacher2",
                FirstName_EN = "teacher2",
                LastName_EN = "teacher2",
                FirstName_TH = "teacher2",
                LastName_TH = "teacher2",
                Email = "test.test@test.com",
                ImageUrl = "Content/images/courses/s4.png",
                Description_EN = "Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures.",
            };
            teachers.Add(t1);
            teachers.Add(t2);
            #endregion

            #region Student
            var s1 = new ApplicationUser
            {
                UserName = "student1",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "11111"

            };
            var s2 = new ApplicationUser
            {
                UserName = "student2",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "22222"
            };
            var s3 = new ApplicationUser
            {
                UserName = "student3",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "33333"
            };
            var s4 = new ApplicationUser
            {
                UserName = "student4",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "44444"
            };
            var s5 = new ApplicationUser
            {
                UserName = "student5",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "55555"
            };
            var s6 = new ApplicationUser
            {
                UserName = "student6",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "66666"
            };
            var s7 = new ApplicationUser
            {
                UserName = "student7",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "77777"
            };
            var s8 = new ApplicationUser
            {
                UserName = "student8",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "88888"
            };
            var s9 = new ApplicationUser
            {
                UserName = "student9",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "99999"
            };
            var s10 = new ApplicationUser
            {
                UserName = "student10",
                FirstName_EN = "student",
                LastName_EN = "student",
                FirstName_TH = "student",
                LastName_TH = "student",
                Email = "test.test@test.com",
                StudentId = "00000"
            };

            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);
            students.Add(s6);
            students.Add(s7);
            students.Add(s8);
            students.Add(s9);
            students.Add(s10);
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
                Id = CID1,
                Name_TH = "A11BHS Behavioural Sciences",
                Name_EN = "A11BHS Behavioural Sciences",
                ImageUrl = "Content/images/courses/1.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat1,
                Teachers = new List<ApplicationUser> {
                    t1
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c2 = new Course
            {
                Id = CID2,
                Name_TH = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                Name_EN = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                ImageUrl = "Content/images/courses/2.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat1,
                Teachers = new List<ApplicationUser> {
                    t1
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c3 = new Course
            {
                Id = CID3,
                Name_TH = "A11HDT Human Development and Tissue Differentiation",
                Name_EN = "A11HDT Human Development and Tissue Differentiation",
                ImageUrl = "Content/images/courses/13.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat1,
                Teachers = new List<ApplicationUser> {
                    t1
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c4 = new Course
            {
                Id = CID4,
                Name_TH = "A11MBM Molecular Basis of Medicine",
                Name_EN = "A11MBM Molecular Basis of Medicine",
                ImageUrl = "Content/images/courses/4.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat2,
                Teachers = new List<ApplicationUser> {
                    t1
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c5 = new Course
            {
                Id = CID5,
                Name_TH = "A11CS1 Communication Skills (I)",
                Name_EN = "A11CS1 Communication Skills (I)",
                ImageUrl = "Content/images/courses/5.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat2,
                Teachers = new List<ApplicationUser> {
                    t1
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c6 = new Course
            {
                Id = CID6,
                Name_TH = "A11CLS Clinical Laboratory Sciences (I)",
                Name_EN = "A11CLS Clinical Laboratory Sciences (I)",
                ImageUrl = "Content/images/courses/6.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat2,
                Teachers = new List<ApplicationUser> {
                    t2
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c7 = new Course
            {
                Id = CID7,
                Name_TH = "A11CRH Cardiovascular, Respiratory and Haematology",
                Name_EN = "A11CRH Cardiovascular, Respiratory and Haematology",
                ImageUrl = "Content/images/courses/7.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat3,
                Teachers = new List<ApplicationUser> {
                    t2
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c8 = new Course
            {
                Id = CID8,
                Name_TH = "A11SF1 Human Development Structure and Function (I)",
                Name_EN = "A11SF1 Human Development Structure and Function (I)",
                ImageUrl = "Content/images/courses/8.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat3,
                Teachers = new List<ApplicationUser> {
                    t2
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var c9 = new Course
            {
                Id = CID9,
                Name_TH = "A11PD1 Early Clinical and Professional Development (I)",
                Name_EN = "A11PD1 Early Clinical and Professional Development (I)",
                ImageUrl = "Content/images/courses/11.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat3,
                Teachers = new List<ApplicationUser> {
                    t2
                },
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            courses.Add(c1);
            courses.Add(c2);
            courses.Add(c3);
            courses.Add(c4);
            courses.Add(c5);
            courses.Add(c6);
            courses.Add(c7);
            courses.Add(c8);
            courses.Add(c9);
            #endregion

            #region PhotoAlbum
            var album = new PhotoAlbum
            {
                Id = PID1,
                Name = "default album",
                CourseId = CID1,
                ApplicationUser = defaultUser
            };
            var p1 = new Photo
            {
                PhotoAlbumId = PID1,
                Name = "1.jpg",
                ImageUrl = "Content/images/courses/2e172c30-ba70-4036-b609-91ecabbad3b7/1.jpg",
                PublishedDate = new DateTime(2017, 8, 7),
                UploadBy = "chansak",
                ApplicationUser = defaultUser
            };
            photos.Add(p1);
            #endregion

            #region Forum Category
            var fcat1 = new ForumCategory
            {
                Title = "ข่าวประกาศ",
                ApplicationUser = defaultUser
            };
            var fcat2 = new ForumCategory
            {
                Title = "ถามตอบ",
                ApplicationUser = defaultUser
            };
            var fcat3 = new ForumCategory
            {
                Title = "สมาคมศิษย์เก่า",
                ApplicationUser = defaultUser
            };
            var fcat4 = new ForumCategory
            {
                Title = "ทั่วไป",
                ApplicationUser = defaultUser
            };
            fcategories.Add(fcat1);
            fcategories.Add(fcat2);
            fcategories.Add(fcat3);
            fcategories.Add(fcat3);
            #endregion

            #region Forum
            var f1 = new Forum
            {
                Id = FID1,
                Category = fcat1,
                Name = "คณะทันตแพทยศาสตร์ มศว ต้อนรับนิสิตแลกเปลี่ยน คณะทันตแพทย์ จาก TMDU",
                ShortDescription = "คณะทันตแพทยศาสตร์ มหาวิทยาลัยศรีนครินทรวิโรฒ (มศว) ต้อนรับนิสิตแลกเปลี่ยน คณะทันตแพทย์ จาก TMDU( Tokyo Medical and Dental University) ประเทศญี่ปุ่น โดยพานิสิตแลกเปลี่ยนเยี่ยมชมสถานที่สำคัญในมหาวิทยาลัย และบรรยายแลกเปลี่ยนประสบการณ์การจัดการเรียนการสอนและระบบสุขภาพในประเทศไทย ให้นิสิตแลกเปลี่ยนทั้ง 9 คน เมื่อวันที่ 28 สิงหาคม 2560",
                FullDescription = @"<p>However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information. During my freshman year, I was looking for ways to get involved on campus. As it is currently the midst of finals season here in Cambridge, many here on campus can’t help but think about their Winter Break plans. </p>
<p> Known as J - Term on campus,
                Harvard’s Winter Break lasts for over a month.Depending on your final exam schedules in December, one’s winter break can last from early-to - mid December to late January. With over a month of break in between Fall and Spring Semesters, may Harvard students opt to take the time to do a variety of things: spend time with family, travel abroad, volunteer, work, prepare for graduate school exams, etc. </p>
<p> Freshman year J - term and this upcoming J - term I plan to stay home for the majority of it to rest and spend time with my family in Los Angeles.A fellow Harvard program attendee and I co - wrote a piece for Vice News Latin America about American expats that live in Mexico and how their experiences in Mexico had informed their thoughts on the upcoming presidential election.The link to the article can be found below: </p>
<p><a class='irs-active-link text-thm2' href='#'>https://news.vice.com/article/wed-be-on-the-other-side-of-the-wall-us-ex…</a></p>
<p>Not only was this experience a remarkable opportunity to immerse myself in a new country, but it gave me a supportive network of friends and programming that made that adjustment in a new country all the more enjoyable.</p>
<p class='irs-mrgntop-ffty'>It kinda stinks getting deferred because no one likes waiting, but there’s still hope.Just because you got deferred doesn’t mean that you can’t get accepted later.Me and my roommate both got deferred and then got in during regular decision.So, don’t freak out. You’re still rockin’! </p>
<p class='irs-mrgntop-ffty'>There’s nothing like a nice relaxing cup of tea, says my grandma, and she’s been around on this green and blue planet for 88 years so I trust her.Take some time to gather yourself and chill out. Everything’s A-okay.The sky is still above your head probably/hopefully, and you will eventually go to college next year. </p>",
                ImageUrl = "Content/images/blog/blog-post-ip1.jpg",
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            //            var f2 = new Forum
            //            {
            //                Id = FID2,
            //                Category = fcat1,
            //                Name = "เปิดบ้านศิลปกรรมฯ มศว เส้นทางสู่อาชีพสร้างฝันน้องๆ ม.ปลาย ให้เป็นจริง",
            //                ShortDescription = "คณะศิลปกรรมศาสตร์ มหาวิทยาลัยศรีนครินทรวิโรฒ (มศว) นับเป็นอีกหนึ่งคณะของสถาบันการศึกษาอุดมศึกษาที่เป็นที่เรียนที่ใฝ่ฝันของน้องๆ นักเรียน ม.ปลาย เพราะมีเหล่าศิลปินนักแสดงรุ่นใหม่ในปัจจุบันจำนวนไม่น้อยที่จบจากรั้ว มศว เช่น นิวเยียร์ กิตติวัฒน์ / ซีซีน ภัสธราภรณ์ / ซีน ปัณณ์ญาณัช / ไต้ฝุ่น KPN / แอปเปิ้ล เดอะสตาร์ เป็นต้น ล่าสุดคณะศิลปกรรมศาสตร์ มศว จึงได้จัดกิจกรรมเปิดบ้านศิลปกรรมศาสตร์ มศว แนะนำหลักสูตรพร้อมนำรุ่นพี่ศิษย์เก่ามากความสามารถมาร่วมพูดคุย สร้างแรงบันดาลใจให้กับน้องๆ เหล่านักเรียน ม.ปลาย ที่อยากจะเข้าเรียนที่แห่งนี้ด้วยงาน “FOFA SWU : Open House 2017” แนะแนวการเตรียมตัวสอบด้วยระบบ TCAS ในปี 2561 ซึ่งก็ได้รับความสนใจจากน้องๆ นักเรียนทั้งในกรุงเทพฯ และมาจากต่างจังหวัดมากกว่า 600 คน ณ อาคารนวัตกรรม ศาสตราจารย์ ดร.สาโรช บัวศรี มศว ประสานมิตร สุขุมวิท 23",
            //                FullDescription = @"<p>However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information. During my freshman year, I was looking for ways to get involved on campus. As it is currently the midst of finals season here in Cambridge, many here on campus can’t help but think about their Winter Break plans. </p>
            //<p> Known as J - Term on campus,
            //                Harvard’s Winter Break lasts for over a month.Depending on your final exam schedules in December, one’s winter break can last from early-to - mid December to late January. With over a month of break in between Fall and Spring Semesters, may Harvard students opt to take the time to do a variety of things: spend time with family, travel abroad, volunteer, work, prepare for graduate school exams, etc. </p>
            //<p> Freshman year J - term and this upcoming J - term I plan to stay home for the majority of it to rest and spend time with my family in Los Angeles.A fellow Harvard program attendee and I co - wrote a piece for Vice News Latin America about American expats that live in Mexico and how their experiences in Mexico had informed their thoughts on the upcoming presidential election.The link to the article can be found below: </p>
            //<p>< a class='irs-active-link text-thm2' href='#'>https://news.vice.com/article/wed-be-on-the-other-side-of-the-wall-us-ex…</a></p>
            //<p>Not only was this experience a remarkable opportunity to immerse myself in a new country, but it gave me a supportive network of friends and programming that made that adjustment in a new country all the more enjoyable.</p>
            //<p class='irs-mrgntop-ffty'>It kinda stinks getting deferred because no one likes waiting, but there’s still hope.Just because you got deferred doesn’t mean that you can’t get accepted later.Me and my roommate both got deferred and then got in during regular decision.So, don’t freak out. You’re still rockin’! </p>
            //<p class='irs-mrgntop-ffty'>There’s nothing like a nice relaxing cup of tea, says my grandma, and she’s been around on this green and blue planet for 88 years so I trust her.Take some time to gather yourself and chill out. Everything’s A-okay.The sky is still above your head probably/hopefully, and you will eventually go to college next year. </p>",
            //                ImageUrl = "Content/images/courses/1.jpg",
            //                //ApplicationUser = defaultUser
            //            };
            //            var f3 = new Forum
            //            {
            //                Id = FID3,
            //                Category = fcat1,
            //                Name = "นิสิต สาขาวิชาวิทยาศาสตร์ทั่วไป คณะวิทยาศาสตร์ มศว ที่ได้รับ",
            //                ShortDescription = "มหาวิทยาลัยศรีนครินทรวิโรฒ (มศว) ขอแสดงความยินดีกับ ผศ.ดร.สุรศักดิ์ ละลอกน้ำ และนิสิตหลักสูตรการศึกษาบัณฑิต สาขาวิชาวิทยาศาสตร์ทั่วไป คณะวิทยาศาสตร์ ได้แก่ นายมารุตต์ แสงสุข นางสาวพิณพิชา เพียรมานะ นายนราธิป ปราโมทย์ นายภานุกร คงไสยะ นางสาวปัทมาพร น่าดู นางสาวสิรินญา ไพเราะ และนางสาววาสนา ไผ่งาม ที่ได้รับ รางวัลรองชนะเลิศอันดับหนึ่ง จากการเข้าร่วมประกวดผลงานประเภท นวัตกรรม จากผลงาน ชุดกิจกรรมวิทยาศาสตร์ เรื่อง 9 กิจกรรมวิทยาศาสตร์ตามแนวทางพระราชดำริ ใน การประชุมวิชาการวิจัยและนวัตกรรมสร้างสรรค์ครั้งที่ 4 และการประชุมสัมมนาวิชาการระดับนานาชาติ ด้านพลังงานไฟฟ้าแรงสูง พลาสมาและไมโครนาโนบับเบิลสำหรับเกษตรกรและการประมงขั้นสูง ครั้งที่ 2 จัดโดย มหาวิทยาลัยเทคโนโลยีราชมงคลล้านนา ระหว่างวันที่ 26 - 27 กรกฎาคม 2560 ณ ศูนย์ประชุมนานาชาติ โรงแรมเชียงใหม่แกรนด์วิว จังหวัดเชียงใหม่",
            //                FullDescription = @"<p>However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information. During my freshman year, I was looking for ways to get involved on campus. As it is currently the midst of finals season here in Cambridge, many here on campus can’t help but think about their Winter Break plans. </p>
            //<p> Known as J - Term on campus,
            //                Harvard’s Winter Break lasts for over a month.Depending on your final exam schedules in December, one’s winter break can last from early-to - mid December to late January. With over a month of break in between Fall and Spring Semesters, may Harvard students opt to take the time to do a variety of things: spend time with family, travel abroad, volunteer, work, prepare for graduate school exams, etc. </p>
            //<p> Freshman year J - term and this upcoming J - term I plan to stay home for the majority of it to rest and spend time with my family in Los Angeles.A fellow Harvard program attendee and I co - wrote a piece for Vice News Latin America about American expats that live in Mexico and how their experiences in Mexico had informed their thoughts on the upcoming presidential election.The link to the article can be found below: </p>
            //<p>< a class='irs-active-link text-thm2' href='#'>https://news.vice.com/article/wed-be-on-the-other-side-of-the-wall-us-ex…</a></p>
            //<p>Not only was this experience a remarkable opportunity to immerse myself in a new country, but it gave me a supportive network of friends and programming that made that adjustment in a new country all the more enjoyable.</p>
            //<p class='irs-mrgntop-ffty'>It kinda stinks getting deferred because no one likes waiting, but there’s still hope.Just because you got deferred doesn’t mean that you can’t get accepted later.Me and my roommate both got deferred and then got in during regular decision.So, don’t freak out. You’re still rockin’! </p>
            //<p class='irs-mrgntop-ffty'>There’s nothing like a nice relaxing cup of tea, says my grandma, and she’s been around on this green and blue planet for 88 years so I trust her.Take some time to gather yourself and chill out. Everything’s A-okay.The sky is still above your head probably/hopefully, and you will eventually go to college next year. </p>",
            //                ImageUrl = "Content/images/courses/1.jpg",
            //                //ApplicationUser = defaultUser
            //            };
            forums.Add(f1);
            //forums.Add(f2);
            //forums.Add(f3);
            #endregion

            #region Comment
            var com1 = new Comment
            {
                Description = "Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures.",
                Forum = f1,
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var com2 = new Comment
            {
                Description = "Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures.",
                Forum = f1,
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            var com3 = new Comment
            {
                Description = "Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures.",
                Forum = f1,
                ApplicationUser = defaultUser,
                CreatedDate = DateTime.Now
            };
            comments.Add(com1);
            comments.Add(com2);
            comments.Add(com3);
            #endregion

            #region Research Category
            var rcat1 = new ResearchCategory
            {
                Title = "สมุนไพร",
                ApplicationUser = defaultUser
            };
            var rcat2 = new ResearchCategory
            {
                Title = "วินิจฉัยโรค",
                ApplicationUser = defaultUser
            };
            rcategories.Add(rcat1);
            rcategories.Add(rcat2);
            #endregion

            #region Research
            var r1 = new Research
            {
                Id = FID1,
                Category = rcat1,
                Name_TH = "Yellow Head Virus - YHV",
                Name_EN = "Yellow Head Virus - YHV",
                ShortDescription = "การคัดเลือกพืชสมุนไพรที่แสดงฤทธิ์ต้านไวรัส (Yellow Head Virus - YHV) ในกุ้งกุลาดำ",
                ImageUrl = "Content/images/courses/1.jpg",
                CreatorName = "Nuchanart Srichan",
                Publisher = "Kasetsart University. Office of the University Library Address: Bangkok",
                Contributor = "Patnaree Srisuphaolarn",
                PublishDate = new DateTime(2009, 8, 23),
                ApplicationUser = defaultUser
            };
            researchs.Add(r1);
            #endregion

            context.CourseCategory.AddRange(categories);
            context.SaveChanges();

            context.Courses.AddRange(courses);
            context.SaveChanges();

            context.Curriculums.AddRange(curriculums);
            context.SaveChanges();

            context.PhotoAlbums.Add(album);
            context.SaveChanges();

            context.Photos.AddRange(photos);
            context.SaveChanges();

            context.ForumCategory.AddRange(fcategories);
            context.SaveChanges();

            context.Forums.AddRange(forums);
            context.SaveChanges();

            context.Comments.AddRange(comments);
            context.SaveChanges();

            context.ResearchCategory.AddRange(rcategories);
            context.SaveChanges();

            context.Research.AddRange(researchs);
            context.SaveChanges();

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

            #region Student Score
            //var sc1 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 42,
            //    Student = s1
            //};
            //var sc2 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 30,
            //    Student = s2
            //};
            //var sc3 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 45,
            //    Student = s3
            //};
            //var sc4 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 20,
            //    Student = s4
            //};
            //var sc5 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 39,
            //    Student = s5
            //};
            //var sc6 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 39,
            //    Student = s6
            //};
            //var sc7 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 21,
            //    Student = s7
            //};
            //var sc8 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 43,
            //    Student = s8
            //};
            //var sc9 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 30,
            //    Student = s9
            //};
            //var sc10 = new StudentScore
            //{
            //    CurriculumId = cur4.Id,
            //    Activated = true,
            //    Score = 40,
            //    Student = s10
            //};
            //studentScores.Add(sc1);
            //studentScores.Add(sc2);
            //studentScores.Add(sc3);
            //studentScores.Add(sc4);
            //studentScores.Add(sc5);
            //studentScores.Add(sc6);
            //studentScores.Add(sc7);
            //studentScores.Add(sc8);
            //studentScores.Add(sc9);
            //studentScores.Add(sc10);
            //context.StudentCourse.AddRange(studentScores);
            //context.SaveChanges();
            #endregion

            #region Video
            var videos = new List<Video> {
                    new Video {
                        ImageUrl="Content/images/campus/1.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=hYEnh4LuruQ",
                        Title_EN="Campus Life",
                        Title_TH="การใช้ชีวิต"
                    },
                    new Video {
                        ImageUrl="Content/images/campus/2.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=PvXZKSumtk8",
                        Title_EN="Interview",
                        Title_TH="สัมภาษณ์"
                    },
                    new Video {
                        ImageUrl="Content/images/campus/3.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=JxvrkpMRk4o",
                        Title_EN="Job fair",
                        Title_TH="หางาน"
                    },
                    new Video {
                        ImageUrl="Content/images/campus/4.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=1GaMGdOQLvg",
                        Title_EN="Sport day",
                        Title_TH="กีฬาสี"
                    },
                };
            context.Videos.AddRange(videos);
            #endregion

            #region News
            var news = new List<News>
                {
                    new News {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                    new News {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                    new News {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        StartDate = new DateTime(2017, 8, 14, 9, 0, 0).ToUniversalTime(),
                        ApplicationUser = defaultUser
                    },
                    new News {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
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
