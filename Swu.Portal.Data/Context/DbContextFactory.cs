using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Context
{
    public class DbContextFactory
    {
        private static volatile DbContextFactory _dbContextFactory;
        private static readonly object SyncRoot = new Object();
        public SwuDBContext Context;

        public static DbContextFactory Instance
        {
            get
            {
                if (_dbContextFactory == null)
                {
                    lock (SyncRoot)
                    {
                        if (_dbContextFactory == null)
                            _dbContextFactory = new DbContextFactory();
                    }
                }
                return _dbContextFactory;
            }
        }

        public SwuDBContext GetOrCreateContext()
        {
            if (this.Context == null)
                this.Context = new SwuDBContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            return Context;
        }
    }
}
