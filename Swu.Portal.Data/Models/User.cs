using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName_EN { get; set; }
        public string LastName_EN { get; set; }


        public string FirstName_TH { get; set; }
        public string LastName_TH { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Forum> Forums { get; set; }
    }
}
