using System.Net.Http.Headers;

namespace HuggingfaceHub.Common
{
    public record class HfFileMetadata(
        string? CommitHash, 
        EntityTagHeaderValue? Etag, 
        Uri? Location, 
        long? Size
    );
}