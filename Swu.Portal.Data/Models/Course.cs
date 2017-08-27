﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class Course : BaseModel
    {
        [Key]
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Name_TH { get; set; }
        public string Name_EN { get; set; }
        public decimal Price { get; set; }
        public int NumberOfViews { get; set; }
        public string Language { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CourseCategory Category { get; set; }

        public virtual ICollection<Curriculum> Curriculums { get; set; }

    }
}