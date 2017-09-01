using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CommentProxy
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }
        public string CreatorPosition { get; set; }
        public string creatorUrl { get; set; }
    }
}
