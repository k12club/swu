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
        public ForumController(IRepository2<Forum> forumRepository, IRepository<ForumCategory> forumCategoryRepository)
        {
            this._forumRepository = forumRepository;
            this._forumCategoryRepository = forumCategoryRepository;
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
                forums = this._forumRepository.List.Where(i => i.Name_EN.ToLower().Contains(keyword.ToLower()) || i.Name_TH.ToLower().Contains(keyword.ToLower())).ToList();
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
    }
}
