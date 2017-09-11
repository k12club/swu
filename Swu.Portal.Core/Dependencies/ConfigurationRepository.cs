using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Core.Dependencies
{
    public interface IConfigurationRepository
    {
        string UploadFilePath { get; }
        string DefaultUserImage { get; }
    }
    public class ConfigurationRepository : IConfigurationRepository
    {
        public ConfigurationRepository()
        {

        }

        public string UploadFilePath
        {
            get {
                return "~/App_Data/Temp/FileUploads";
            }
        }
        public string DefaultUserImage
        {
            get {
                return "Content/images/default.jpg";
            }
        }
    }
}
