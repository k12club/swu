using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class StudentCourse : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Activated { get; set; }
        public int Score { get; set; }

        public virtual ICollection<Curriculum> Curriculum { get; set; }

        public virtual ICollection<ApplicationUser> Students { get; set; }
    }
}
