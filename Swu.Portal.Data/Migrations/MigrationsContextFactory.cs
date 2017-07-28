using Swu.Portal.Data.Context;
using System.Configuration;
using System.Data.Entity.Infrastructure;

namespace Swu.Portal.Data.Context
{
    internal sealed class MigrationsContextFactory : IDbContextFactory<SwuDBContext>
    {
        public SwuDBContext Create()
        {
            return new SwuDBContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}
