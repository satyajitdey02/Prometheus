using System.IO;
using Framework.Core.Base.ModelEntity;

namespace FlightAction.Core.Models
{
    public class UploadedFiles : ModelEntityBase
    {
        public string FullPath { get; set; }

        public string FileName => Path.GetFileName(FullPath);
    }
}
