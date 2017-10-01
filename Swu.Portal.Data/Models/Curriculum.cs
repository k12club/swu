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
        public Curriculum()
        {
            StudentScores = new HashSet<StudentScore>();
            CurriculumDocuments = new HashSet<CurriculumDocument>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public CurriculumType Type { get; set; }
        public int NumberOfTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }
        public string RoomDescription { get; set; }
        public string SurveyLink { get; set; }
        public string CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public virtual ICollection<StudentScore> StudentScores { get; set; }
        public virtual ICollection<CurriculumDocument> CurriculumDocuments { get; set; }

    }
}
