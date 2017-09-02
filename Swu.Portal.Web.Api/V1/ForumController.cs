using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api.V1
{
    [RoutePrefix("V1/Forum")]
    public class ForumController : ApiController
    {
        private readonly IRepository2<Forum> _forumRepository;
        private readonly IRepository<ForumCategory> _forumCategoryRepository;
        private readonly IRepository<Comment> _commentRepository;
        public ForumController(IRepository2<Forum> forumRepository, IRepository<ForumCategory> forumCategoryRepository, IRepository<Comment> commentRepository)
        {
            this._forumRepository = forumRepository;
            this._forumCategoryRepository = forumCategoryRepository;
            this._commentRepository = commentRepository;
        }
        [HttpGet, Route("allItems")]
        public List<WebboardItemProxy> GetAllItems(string keyword)
        {
            var webboardItems = new List<WebboardItemProxy>();
            var forums = new List<Forum>();
            if (keyword.Equals("*"))
            {
                forums = this._forumRepository.List.ToList();
            }
            else
            {
                forums = this._forumRepository.List.Where(i => i.Name.ToLower().Contains(keyword.ToLower())).ToList();
            }
            foreach (var f in forums)
            {
                webboardItems.Add(new WebboardItemProxy(f));
            }
            return webboardItems;
        }
        [HttpGet, Route("category")]
        public List<WebboardCategoryProxy> GetCategory()
        {
            var webboardCategories = new List<WebboardCategoryProxy>();
            var catgories = this._forumCategoryRepository.List.ToList();
            foreach (var c in catgories)
            {
                webboardCategories.Add(new WebboardCategoryProxy(c));
            }
            return webboardCategories;
        }
        [HttpGet, Route("getForumDetail")]
        public ForumDetailProxy GetForumDetail(string id) {
            var forum = this._forumRepository.FindById(id);
            var comments = this._commentRepository.List.Where(i => i.ForumId == id)
                .Select(c => new CommentProxy(c)).ToList();
            return new ForumDetailProxy {
                Forum= new ForumProxy {
                    Id = forum.Id,
                    Name = forum.Name,
                    ShortDescription = forum.ShortDescription,
                    FullDescription = forum.FullDescription,
                    ImageUrl = forum.ImageUrl,
                    NumberOfViews= comments.Count(),
                    Price = forum.Price,
                    CreatorName = forum.ApplicationUser.FirstName_EN + " " + forum.ApplicationUser.LastName_EN,
                    CreatedDate = forum.CreatedDate
                },
                Comments = comments
            };
        }
    }
}
