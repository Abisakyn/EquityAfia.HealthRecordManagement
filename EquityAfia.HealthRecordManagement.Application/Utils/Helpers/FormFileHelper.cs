using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class CustomFormFile : IFormFile
{
    private readonly Stream _stream;
    private readonly long _length;

    public CustomFormFile(byte[] fileBytes)
    {
        _stream = new MemoryStream(fileBytes);
        _length = fileBytes.Length;
    }

    public string ContentType => "application/octet-stream";
    public string ContentDisposition => $"form-data; name=\"file\"; filename=\"file\"";
    public IHeaderDictionary Headers => new HeaderDictionary();
    public long Length => _length;
    public string Name => "file";
    public string FileName => "file";

    public void CopyTo(Stream target)
    {
        _stream.CopyTo(target);
    }

    public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
    {
        return _stream.CopyToAsync(target, cancellationToken);
    }

    public Stream OpenReadStream()
    {
        return _stream;
    }
}

public static class FormFileHelper
{
    public static IFormFile CreateFormFile(byte[] fileBytes)
    {
        return new CustomFormFile(fileBytes);
    }
}
