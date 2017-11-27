using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IBannerService
    {
        void CreateNew(Banner b);
        void Update(Banner b);
        void Delete(Banner b);

    }
    public class BannerService : IBannerService
    {
        public void CreateNew(Banner b)
        {
            using (var context = new SwuDBContext())
            {
                context.Banners.Add(b);
                context.SaveChanges();
            }
        }

        public void Delete(Banner b)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Banners
                    .Where(i => i.Id == b.Id)
                    .FirstOrDefault();
                context.Banners.Remove(existing);
                context.SaveChanges();
            }
        }

        public void Update(Banner b)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Banners
                    .Where(i => i.Id == b.Id)
                    .FirstOrDefault();
                existing.Title_EN = b.Title_EN;
                existing.Title_TH = b.Title_TH;
                existing.Description_EN = b.Description_EN;
                existing.Description_TH = b.Description_TH;
                existing.ImageUrl = b.ImageUrl;
                existing.IsActive = b.IsActive;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
