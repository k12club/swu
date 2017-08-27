using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class CourseCategory :BaseModel
    {
        public string Title { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
