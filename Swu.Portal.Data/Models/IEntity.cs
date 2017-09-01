using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class IEntity
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        public string CreatedUser { get; set; }
        [ForeignKey("CreatedUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}
