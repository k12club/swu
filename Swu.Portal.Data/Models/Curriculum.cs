using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public enum CurriculumType {
        Lecture = 1,
        Quize = 2,
    }
    public class Curriculum : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public CurriculumType Type { get; set; }
        public int NumberOfTime { get; set; }

        public string CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }
    }
}
