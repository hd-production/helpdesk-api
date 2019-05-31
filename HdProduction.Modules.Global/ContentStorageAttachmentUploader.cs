using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;

namespace HdProduction.Modules.Global
{
  public class ContentStorageAttachmentUploader : IAttachmentUploader
  {
    private static readonly HttpClient HttpClient;

    static ContentStorageAttachmentUploader()
    {
      HttpClient = new HttpClient();
      HttpClient.DefaultRequestHeaders.Add("access-key", "25666AB4CE0D3512E1C1FD1BA044C460E4814F66A9ABFCD4A81FAF7C2BE9A9C9");
    }

    private readonly string _contentServiceUrl;

    public ContentStorageAttachmentUploader(string contentServiceUrl)
    {
      _contentServiceUrl = contentServiceUrl;
    }

    public async Task<string> UploadAsync(string fileName, Stream stream)
    {
      using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
      {
          content.Add(new StreamContent(stream), "file", fileName);
        using (var response = await HttpClient.PostAsync(_contentServiceUrl, content))
        {
          response.EnsureSuccessStatusCode();
        }
      }

      return GetDownloadLink(fileName);
    }

    private string GetDownloadLink(string fileKey)
    {
      return $"{_contentServiceUrl}/{fileKey}";
    }
  }
}