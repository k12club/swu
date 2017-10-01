using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IPersonalFileService
    {
        void AddNewFile(PersonalFile file, string userId);
        void DeleteFile(int id);
    }
    public class PersonalFileService : IPersonalFileService
    {
        private readonly IApplicationUserServices _applicationUserServices;
        public PersonalFileService(IApplicationUserServices applicationUserServices)
        {
            this._applicationUserServices = applicationUserServices;
        }
        public void AddNewFile(PersonalFile file, string userId)
        {
            var user = this._applicationUserServices.FindById(userId);
            using (var context = new SwuDBContext())
            {
                context.Users.Attach(user);
                context.PersonalFiles.Add(file);
                context.SaveChanges();
            }
        }

        public void DeleteFile(int id)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.PersonalFiles.Where(i => i.Id == id).FirstOrDefault();
                context.PersonalFiles.Remove(existing);
                context.SaveChanges();
            }
        }
    }
}
