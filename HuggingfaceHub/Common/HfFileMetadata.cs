using System.Net.Http.Headers;

namespace Huggingface.Common
{
    public record class HfFileMetadata(
        string? CommitHash, 
        EntityTagHeaderValue? Etag, 
        Uri? Location, 
        int? Size
    );
}