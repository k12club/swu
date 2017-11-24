﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class News :IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title_TH { get; set; }
        public string Title_EN { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public string FullDescription_TH { get; set; }
        public string FullDescription_EN { get; set; }
        public DateTime StartDate { get; set; }
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
