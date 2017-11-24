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
    public class Event : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title_EN { get; set; }
        public string Description_EN { get; set; }
        public string Place_EN { get; set; }

        public string Title_TH { get; set; }
        public string Description_TH { get; set; }
        public string Place_TH { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }
        [DefaultValue(false)]
        public bool IsActive { get; set; }

    }
}
