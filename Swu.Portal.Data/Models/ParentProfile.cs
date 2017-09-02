using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class ParentProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ChildId { get; set; }
        [ForeignKey("ChildId")]
        public virtual ApplicationUser Child { get; set; }

        public int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
    }
}
