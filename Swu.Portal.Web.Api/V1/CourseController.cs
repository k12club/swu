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
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                        CardType=Enum.CardType.Popular
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                        CardType=Enum.CardType.Popular
                    },
                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                        CardType=Enum.CardType.Popular
                    },


                    new CourseCardProxy
                    {
                        Course = new CourseProxy
                        {
                            Id = 1,
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                            Name = "INDE 201: Practice of Medicine I",
                            ImageUrl = "Content/images/courses/1.jpg",
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
                    Title=@"Receive a world-class <br>
education in the heart of <br>
the west.",
                    Description="Top rated for combining academic quality and outdoor reacreation.",
                    ImageUrl="Content/images/home/h1.jpg"
                },
                new SliderProxy {
                    Id=1,
                    Title=@"Want to experience how life is <br>
on our campus?",
                    Description="Learning Resources Centre, a student social space.",
                    ImageUrl="Content/images/home/h2.jpg"
                },
                new SliderProxy {
                    Id=1,
                    Title=@" Make a bold decision today <br>
and start a new fresh tomorrow. ",
                    Description="Top rated for combining academic quality and outdoor reacreation.",
                    ImageUrl="Content/images/home/h3.jpg"
                }
            };
        }
    }
}
