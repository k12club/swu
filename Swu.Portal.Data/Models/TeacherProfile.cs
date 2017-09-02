using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class TeacherProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

        //public virtual Contact Contact { get; set; }
        public virtual ApplicationUser ReferenceUser { get; set; }
    }
}
