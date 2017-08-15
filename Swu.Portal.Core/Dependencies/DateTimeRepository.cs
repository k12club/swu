using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Core.Dependencies
{
    public interface IDateTimeRepository
    {
        DateTime Now();
    }
    public class DateTimeRepository : IDateTimeRepository
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
