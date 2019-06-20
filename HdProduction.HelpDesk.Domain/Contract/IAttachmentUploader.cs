using System.IO;
using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface IAttachmentUploader
  {
    Task<string> UploadAsync(string fileName, Stream stream);
  }

  public class FakeAttachmentUploader : IAttachmentUploader
  {
    public Task<string> UploadAsync(string fileName, Stream stream)
    {
      return Task.FromResult(string.Empty);
    }
  }
}