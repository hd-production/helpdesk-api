using System;
using System.IO;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;

namespace HdProduction.Modules.SelfHost
{
  public class FileSystemAttachmentUploader : IAttachmentUploader
  {
    private readonly string _pathToContent;

    public FileSystemAttachmentUploader(string pathToContent = null)
    {
      _pathToContent = pathToContent ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cnt");
    }

    public async Task<string> UploadAsync(string fileName, Stream stream)
    {
      using (var fileStream = new FileStream(Path.Combine(_pathToContent, fileName), FileMode.Create))
      {
        await stream.CopyToAsync(fileStream);
      }

      return fileName;
    }
  }
}