using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class ReferenceUser :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool Approved { get; set; }

        public string ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual ApplicationUser Parent { get; set; }

        public string ChildId { get; set; }
        [ForeignKey("ChildId")]
        public virtual ApplicationUser Child { get; set; }
    }
}
