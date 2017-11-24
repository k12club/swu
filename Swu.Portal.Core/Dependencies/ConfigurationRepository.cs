using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Swu.Portal.Core.Dependencies
{
    public interface IConfigurationRepository
    {
        string UploadFilePath { get; }
        string DefaultUserImage { get; }

        string AdminEmail { get; }
        string AdminPassword { get; }

        string dummyCourse { get; }

    }
    public class ConfigurationRepository : IConfigurationRepository
    {
        public ConfigurationRepository()
        {

        }

        public string UploadFilePath
        {
            get {
                return ConfigurationManager.AppSettings["UploadFilePath"];
            }
        }
        public string DefaultUserImage
        {
            get {
                return ConfigurationManager.AppSettings["DefaultUserImage"];
            }
        }

        public string AdminEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["AdminEmail"];
            }
        }

        public string AdminPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["AdminPassword"];
            }
        }

        public string dummyCourse
        {
            get
            {
                return ConfigurationManager.AppSettings["dummyCourse"];
            }
        }
    }
}
