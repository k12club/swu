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
        public CourseController()
        {
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
        [HttpGet, Route("getSlider")]
        public List<SliderProxy> GetSlider() {
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
