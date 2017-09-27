using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Swu.Portal.Data.Repository
{
    //public class ReferenceUserRepository :IRepository<ReferenceUser>
    //{
    //    private SwuDBContext context;
    //    public ReferenceUserRepository()
    //    {
    //        this.context = new SwuDBContext();//DbContextFactory.Instance.GetOrCreateContext();
    //    }
    //    public IEnumerable<ReferenceUser> List
    //    {
    //        get
    //        {
    //            return this.context.ReferenceUser
    //                .Include(i=>i.Referer)
    //                .AsEnumerable();
    //        }
    //    }
    //    public void Add(ReferenceUser entity)
    //    {
    //        this.context.ReferenceUser.Add(entity);
    //        this.context.SaveChanges();
    //    }
    //    public void Delete(ReferenceUser entity)
    //    {
    //        this.context.ReferenceUser.Remove(entity);
    //        this.context.SaveChanges();
    //    }
    //    public void Update(ReferenceUser entity)
    //    {
    //        this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
    //        this.context.SaveChanges();

    //    }
    //    public ReferenceUser FindById(int Id)
    //    {
    //        var result = this.context.ReferenceUser
    //            .Include(i => i.Referer)
    //            .Where(i => i.Id == Id).FirstOrDefault();
    //        return result;
    //    }
    //}
}
