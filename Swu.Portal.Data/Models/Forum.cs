using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class Forum : IEntity
    {
        [Key]
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int NumberOfViews { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ForumCategory Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
