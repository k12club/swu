using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class AttachFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FilePath { get; set; }

        public string ResearchId { get; set; }
        [ForeignKey("ResearchId")]
        public virtual Research Research { get; set; }
    }
}
