using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class PhotoAlbum : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
