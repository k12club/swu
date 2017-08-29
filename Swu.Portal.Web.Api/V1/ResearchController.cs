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
    [RoutePrefix("V1/Research")]
    public class ResearchController : ApiController
    {
        private readonly IRepository2<Research> _researchRepository;
        private readonly IRepository<ResearchCategory> _researchCategoryRepository;
        public ResearchController(IRepository2<Research> researchRepository, IRepository<ResearchCategory> researchCategoryRepository)
        {
            this._researchRepository = researchRepository;
            this._researchCategoryRepository = researchCategoryRepository;
        }
        [HttpGet, Route("allItems")]
        public List<WebboardItemProxy> GetAllItems(string keyword)
        {
            var webboardItems = new List<WebboardItemProxy>();
            var research = new List<Research>();
            if (keyword.Equals("*"))
            {
                research = this._researchRepository.List.ToList();
            }
            else
            {
                research = this._researchRepository.List.Where(i => i.Name_EN.ToLower().Contains(keyword.ToLower()) || i.Name_TH.ToLower().Contains(keyword.ToLower())).ToList();
            }
            foreach (var r in research)
            {
                webboardItems.Add(new WebboardItemProxy(r));
            }
            return webboardItems;
        }
        [HttpGet, Route("category")]
        public List<WebboardCategoryProxy> GetCategory()
        {
            var webboardCategories = new List<WebboardCategoryProxy>();
            var catgories = this._researchCategoryRepository.List.ToList();
            foreach (var c in catgories)
            {
                webboardCategories.Add(new WebboardCategoryProxy(c));
            }
            return webboardCategories;
        }
    }
}
