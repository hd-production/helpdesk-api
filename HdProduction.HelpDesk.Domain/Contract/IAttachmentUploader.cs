using System.IO;
using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface IAttachmentUploader
  {
    Task<string> UploadAsync(string fileName, Stream stream);
  }
}