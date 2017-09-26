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
        public string LineId { get; set; }
        public string Mobile { get; set; }
        public string OfficeTel { get; set; }

        public string Position_EN { get; set; }
        public string Tag_EN { get; set; }
        public string Description_EN { get; set; }


        public string Position_TH { get; set; }
        public string Tag_TH { get; set; }
        public string Description_TH { get; set; }

        //Student
        public string StudentId { get; set; }
        public string PasswordId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Forum> Forums { get; set; }
        public virtual ICollection<Course> TeacherCourses { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<StudentScore> StudentScore { get; set; }

        public string RefUserId { get; set; }
        [ForeignKey("RefUserId")]
        public virtual ApplicationUser ReferenceUser { get; set; }

        public virtual Department Department { get; set; }

        public virtual University University { get; set; }
    }
}
