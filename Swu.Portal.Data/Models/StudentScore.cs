using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class StudentScore : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Activated { get; set; }
        public int Score { get; set; }

        public int CurriculumId { get; set; }
        [ForeignKey("CurriculumId")]
        public virtual Curriculum Curriculum { get; set; }

        public virtual ApplicationUser Student { get; set; }
    }
}
