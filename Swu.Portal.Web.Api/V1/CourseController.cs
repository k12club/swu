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

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/Course")]
    public class CourseController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository2<Course> _courseRepository;
        public CourseController(IDateTimeRepository datetimeRepository, IRepository2<Course> courseRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._courseRepository = courseRepository;
        }
        [HttpGet, Route("all")]
        public List<CourseCardProxy> GetAll()
        {
            if (ModelState.IsValid)
            {
                var cards = new List<CourseCardProxy>();
                var courses = this._courseRepository.List.ToList();
                foreach (var c in courses) {
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
        public CourseAllDetailProxy GetById(string id)
        {
            var course = this._courseRepository.FindById(id);
            return new CourseAllDetailProxy(course);
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
                        Id = Guid.NewGuid().ToString(),
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
