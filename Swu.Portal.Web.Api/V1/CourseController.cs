using Swu.Portal.Core.Dependencies;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/Course")]
    public class CourseController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        public CourseController(IDateTimeRepository datetimeRepository)
        {
            this._datetimeRepository = datetimeRepository;
        }
        [HttpGet, Route("all")]
        public List<CourseCardProxy> GetAll()
        {
            if (ModelState.IsValid)
            {
                return new List<CourseCardProxy>{
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11BHS Behavioural Sciences",
                            Name_EN = "A11BHS Behavioural Sciences",
                            ImageUrl = "Content/images/courses/1.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student2.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.Popular
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                            Name_EN = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                            ImageUrl = "Content/images/courses/2.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student3.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.Popular
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11HDT Human Development and Tissue Differentiation",
                            Name_EN = "A11HDT Human Development and Tissue Differentiation",
                            ImageUrl = "Content/images/courses/13.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student4.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.Popular
                    },


                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11MBM Molecular Basis of Medicine",
                            Name_EN = "A11MBM Molecular Basis of Medicine",
                            ImageUrl = "Content/images/courses/4.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student1.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.TopRate
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11CS1 Communication Skills (I)",
                            Name_EN = "A11CS1 Communication Skills (I)",
                            ImageUrl = "Content/images/courses/5.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student2.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.TopRate
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11CLS Clinical Laboratory Sciences (I)",
                            Name_EN = "A11CLS Clinical Laboratory Sciences (I)",
                            ImageUrl = "Content/images/courses/6.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student3.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.TopRate
                    },

                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11CRH Cardiovascular, Respiratory and Haematology",
                            Name_EN = "A11CRH Cardiovascular, Respiratory and Haematology",
                            ImageUrl = "Content/images/courses/7.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student4.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.Recently
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11SF1 Human Development Structure and Function (I)",
                            Name_EN = "A11SF1 Human Development Structure and Function (I)",
                            ImageUrl = "Content/images/courses/8.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student1.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.Recently
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name_TH = "A11PD1 Early Clinical and Professional Development (I)",
                            Name_EN = "A11PD1 Early Clinical and Professional Development (I)",
                            ImageUrl = "Content/images/courses/11.jpg",
                            NumberOfRegistered = 123,
                            NumberOfComments = 5,
                            Price = 12
                        },
                        Teacher = new TeacherProxy
                        {
                            Id = 1,
                            ImageUrl = "Content/images/resource/student1.png",
                            Name = "Jessica Hamson"
                        },
                        CardType=Enum.CardType.Recently
                    }
                };
            }
            return null;
        }
        [HttpGet, Route("allItems")]
        public List<WebboardItemProxy> GetAllItems() {
            return new List<WebboardItemProxy> {
                new WebboardItemProxy {
                    Id =1,
                    Name = "Applied Science and Best Technology (AST)",
                    ShortDescription= "However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    NumberOfComments=123,
                    NumberOfView=321,
                    Type=WebboardType.course,
                    CategoryId=1,
                    CreatorImageUrl="Content/images/resource/student1.png",
                    CreateBy ="Chansak",
                    ImageUrl = "Content/images/courses/1.jpg",
                },
                new WebboardItemProxy {
                    Id =2,
                    Name = "Applied Science and Best Technology (AST)",
                    ShortDescription= "However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    NumberOfComments=123,
                    NumberOfView=321,
                    ImageUrl = "Content/images/courses/1.jpg",
                    Type=WebboardType.course,
                    CategoryId=1,
                    CreatorImageUrl="Content/images/resource/student1.png",
                    CreateBy ="Chansak"
                },
                new WebboardItemProxy {
                    Id =3,
                    Name = "Applied Science and Best Technology (AST)",
                    ShortDescription= "However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    NumberOfComments=123,
                    NumberOfView=321,
                    ImageUrl = "Content/images/courses/1.jpg",
                    Type=WebboardType.course,
                    CategoryId=1,
                    CreatorImageUrl="Content/images/resource/student1.png",
                    CreateBy ="Chansak"
                },
                new WebboardItemProxy {
                    Id =4,
                    Name = "Applied Science and Best Technology (AST)",
                    ShortDescription= "However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    NumberOfComments=123,
                    NumberOfView=321,
                    ImageUrl = "Content/images/courses/1.jpg",
                    Type=WebboardType.course,
                    CategoryId=1,
                    CreatorImageUrl="Content/images/resource/student1.png",
                    CreateBy ="Chansak"
                },
                new WebboardItemProxy {
                    Id =5,
                    Name = "Applied Science and Best Technology (AST)",
                    ShortDescription= "However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    NumberOfComments=123,
                    NumberOfView=321,
                    ImageUrl = "Content/images/courses/1.jpg",
                    Type=WebboardType.course,
                    CategoryId=2,
                    CreatorImageUrl="Content/images/resource/student1.png",
                    CreateBy ="Chansak"
                },
                new WebboardItemProxy {
                    Id =6,
                    Name = "Applied Science and Best Technology (AST)",
                    ShortDescription= "However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    NumberOfComments=123,
                    NumberOfView=321,
                    ImageUrl = "Content/images/courses/1.jpg",
                    Type=WebboardType.course,
                    CategoryId=3,
                    CreatorImageUrl="Content/images/resource/student1.png",
                    CreateBy ="Chansak"
                }
            };
        }
        [HttpGet, Route("category")]
        public List<WebboardCategoryProxy> GetCategory()
        {
            return new List<WebboardCategoryProxy> {
                new Proxy.WebboardCategoryProxy {
                    Id =1,
                    Title = "Category 1"
                },
                new Proxy.WebboardCategoryProxy {
                    Id =2,
                    Title = "Category 2"
                },
                new Proxy.WebboardCategoryProxy {
                    Id =3,
                    Title = "Category 3"
                }
            };
        }
        [HttpGet, Route("getById")]
        public CourseAllDetailProxy GetById(int id)
        {
            #region Student registered
            var students = new List<StudentProxy> {
                new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    },
                    new StudentProxy {
                        Id=1,
                        Name="Chansak Kochasen",
                        ImageUrl="",
                        StudentId="12345678",
                    }
            };
            #endregion

            #region Curriculums
            var curriculums = new List<CurriculumProxy> {
                    new CurriculumProxy {
                        Name="Lecture 1.1 Practical language work",
                        Type=Enum.CurriculumType.Lecture,
                        NumberOfTime=4,
                    },
                    new CurriculumProxy {
                        Name="Lecture 1.2 Study of important works and/or topics",
                        Type=Enum.CurriculumType.Lecture,
                        NumberOfTime=4,
                    },
                    new CurriculumProxy {
                        Name="Lecture 1.3 Literature of the language",
                        Type=Enum.CurriculumType.Lecture,
                        NumberOfTime=4,
                    },
                    new CurriculumProxy {
                        Name="Quizzes History of the language test",
                        Type=Enum.CurriculumType.Quize,
                        NumberOfTime=2,
                    },
                    new CurriculumProxy {
                        Name="Lecture 1.4 General linguistics",
                        Type=Enum.CurriculumType.Lecture,
                        NumberOfTime=4,
                    },
                    new CurriculumProxy {
                        Name="Lecture 1.5 Phonetics and phonology ",
                        Type=Enum.CurriculumType.Lecture,
                        NumberOfTime=4,
                    },
                    new CurriculumProxy {
                        Name="Lecture 1.6 Grammatical analysis",
                        Type=Enum.CurriculumType.Lecture,
                        NumberOfTime=4,
                    },
                    new CurriculumProxy {
                        Name="Quizzes History of the language test",
                        Type=Enum.CurriculumType.Quize,
                        NumberOfTime=4,
                    },
                };
            #endregion

            #region Teacher
            var teachers = new List<TeacherProxy> {
                    new TeacherProxy {
                        Id=1,
                        Name="Annie Thornburg",
                        ImageUrl="Content/images/courses/s4.png",
                        Position="History of Arts Teacher",
                        Description="Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures."
                    },
                    new TeacherProxy {
                        Id=2,
                        Name="Miguel M. Ball",
                        ImageUrl="Content/images/team/tsm2.png",
                        Position="Physics and Philosophy Teacher",
                        Description="Your week’s work will include a tutorial on linguistics and one on literature, in or arranged by your college, a linguistics class and language classes on different skills relating to the language or languages you study, and five or six lectures."
                    }
            };
            #endregion
            return new CourseAllDetailProxy
            {
                CourseInfo = new CourseDetailProxy
                {
                    Id = 1,
                    Name_TH = "A11BHS Behavioural Sciences",
                    Name_EN = "A11BHS Behavioural Sciences",
                    ImageUrl = "Content/images/courses/1.jpg",
                    NumberOfRegistered = 123,
                    NumberOfComments = 5,
                    Price = 12,
                    NumberOfLecture = curriculums.Where(i => i.Type == Enum.CurriculumType.Lecture).Count(),
                    NumberOfQuizes = curriculums.Where(i => i.Type == Enum.CurriculumType.Quize).Count(),
                    NumberOfStudents = students.Count(),
                    NumberOfTeachers = teachers.Count(),
                    NumberOfTimes = curriculums.Sum(i => i.NumberOfTime),
                    Language = "English",
                    BigImageUrl = "Content/images/courses/cd1.jpg",
                    FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>"
                },
                Curriculums = curriculums,
                Teacher = teachers,
                Students = students,
                PhotosAlbum = new PhotoAlbumProxy
                {
                    Id = 1,
                    Photos = new List<PhotoProxy> {
                        new PhotoProxy {
                            Id=1,
                            ImageUrl="Content/images/courses/1/1.jpg",
                            Name="Architecture",
                            PublishedDate = this._datetimeRepository.Now(),
                            UploadBy = "Chansak"
                        },
                        new PhotoProxy {
                            Id=2,
                            ImageUrl="Content/images/courses/1/2.jpg",
                            Name="Design",
                            PublishedDate = this._datetimeRepository.Now(),
                            UploadBy = "Wasinee"
                        },
                        new PhotoProxy {
                            Id=3,
                            ImageUrl="Content/images/courses/1/3.jpg",
                            Name="Environment",
                            PublishedDate = this._datetimeRepository.Now(),
                            UploadBy = "Chansak"
                        },
                        new PhotoProxy {
                            Id=3,
                            ImageUrl="Content/images/courses/1/4.jpg",
                            Name="Environment",
                            PublishedDate = this._datetimeRepository.Now(),
                            UploadBy = "Jirayu"
                        },
                        new PhotoProxy {
                            Id=3,
                            ImageUrl="Content/images/courses/1/5.jpg",
                            Name="Environment",
                            PublishedDate = this._datetimeRepository.Now(),
                            UploadBy = "Chansak"
                        }
                    }
                }
            };
        }
        [HttpGet, Route("getCourseByCriteria")]
        public List<CourseBriefDetailProxy> getCourseByCriteria(string keyword)
        {
            #region Teacher
            var teachers = new List<TeacherProxy> {
                    new TeacherProxy {
                        Id=1,
                        Name="Annie Thornburg",
                        ImageUrl="Content/images/courses/s4.png",
                    },
                    new TeacherProxy {
                        Id=2,
                        Name="Miguel M. Ball",
                        ImageUrl="Content/images/team/tsm2.png",
                    }
            };
            #endregion

            #region All Data
            var data = new List<CourseBriefDetailProxy>
            {
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11BHS Behavioural Sciences",
                            Name_EN = "A11BHS Behavioural Sciences",
                            ImageUrl = "Content/images/courses/1.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                        Price = 12,
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11BHS Behavioural Sciences",
                            Name_EN = "A11BHS Behavioural Sciences",
                            ImageUrl = "Content/images/courses/1.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                            Name_EN = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                            ImageUrl = "Content/images/courses/2.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11HDT Human Development and Tissue Differentiation",
                            Name_EN = "A11HDT Human Development and Tissue Differentiation",
                            ImageUrl = "Content/images/courses/13.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11MBM Molecular Basis of Medicine",
                            Name_EN = "A11MBM Molecular Basis of Medicine",
                            ImageUrl = "Content/images/courses/4.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11CS1 Communication Skills (I)",
                            Name_EN = "A11CS1 Communication Skills (I)",
                            ImageUrl = "Content/images/courses/5.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11CLS Clinical Laboratory Sciences (I)",
                            Name_EN = "A11CLS Clinical Laboratory Sciences (I)",
                            ImageUrl = "Content/images/courses/6.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11CRH Cardiovascular, Respiratory and Haematology",
                            Name_EN = "A11CRH Cardiovascular, Respiratory and Haematology",
                            ImageUrl = "Content/images/courses/7.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11SF1 Human Development Structure and Function (I)",
                            Name_EN = "A11SF1 Human Development Structure and Function (I)",
                            ImageUrl = "Content/images/courses/8.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                },
                new CourseBriefDetailProxy {
                    CourseInfo = new CourseDetailProxy
                    {
                        Id = 1,
                            Name_TH = "A11PD1 Early Clinical and Professional Development (I)",
                            Name_EN = "A11PD1 Early Clinical and Professional Development (I)",
                            ImageUrl = "Content/images/courses/11.jpg",
                        NumberOfRegistered = 123,
                        NumberOfComments = 5,
                        Price = 12,
                        ShortDescription="However, the aspect of citizenship that Dr Schlissel wants to address is that of understanding how to accumulate and assess information.",
                    },
                    Teacher = teachers
                }
            };
            #endregion
            var result = new List<CourseBriefDetailProxy>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = data.Where(i => i.CourseInfo.Name_EN.ToLower().Contains(keyword) || i.CourseInfo.Name_TH.Contains(keyword)).ToList();
            }
            else
            {
                result = data.ToList();
            }
            return result;
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
    }
}
