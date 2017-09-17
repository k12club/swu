using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class Research :IEntity
    {
        public Research()
        {
            AttachFiles = new HashSet<AttachFile>();
        }
        [Key]
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Name_TH { get; set; }
        public string Name_EN { get; set; }
        public decimal Price { get; set; }
        public int NumberOfViews { get; set; }


        public string CreatorName { get; set; }
        public string Publisher { get; set; }
        public string Contributor { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime PublishDate { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ResearchCategory Category { get; set; }

        public virtual ICollection<AttachFile> AttachFiles { get; set; }
    }
}
