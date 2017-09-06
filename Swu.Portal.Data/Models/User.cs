using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName_EN { get; set; }
        public string LastName_EN { get; set; }
        public string FirstName_TH { get; set; }
        public string LastName_TH { get; set; }
        public string ImageUrl { get; set; }

        //Teacher
        public string Position { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }

        //Student
        public string StudentId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Forum> Forums { get; set; }

        public virtual ICollection<Course> TeacherCourses { get; set; }

        public virtual ICollection<Course> StudentCourses { get; set; }
    }
}
