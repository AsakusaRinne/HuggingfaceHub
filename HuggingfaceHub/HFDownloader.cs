using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace Huggingface
{
    public static partial class HFDownloader
    {
        public static HttpClient HttpClient { get; set; }

        public static ILogger? Logger { get; set; }

        static HFDownloader()
        {
#if WINDOWS
        // In Windows, you can use HttpClientHandler to use the system's certificate store
        HttpClientHandler handler = new HttpClientHandler()
        {
            UseDefaultCredentials = true
        };
#else
            // If you're not in Windows, default handler can be used.
            HttpClientHandler handler = new HttpClientHandler();
#endif
            HttpClient = new HttpClient();
        }

        private static string GetFileUrl(string repoId, string revision, string filename, string? endpoint = null)
        {
            if(endpoint is null){
                endpoint = HFGlobalConfig.EndPoint;
            }
            return $"{endpoint}/{repoId}/resolve/{revision}/{filename}";
        }

        /// <summary>
        /// Build headers dictionary to send in a HF Hub call.
        /// 
        /// By default, authorization token is always provided either from argument (explicit
        /// use) or retrieved from the cache (implicit use). To explicitly avoid sending the
        /// token to the Hub, set `token=False`.

        /// In case of an API call that requires write access, an error is thrown if token is
        /// `null` or token is an organization token (starting with `"api_org***"`).

        /// In addition to the auth header, a user-agent is added to provide information about
        /// the installed packages (versions of python, huggingface_hub, torch, tensorflow,
        /// fastai and fastcore).

        /// </summary>
        /// <param name="token"></param>
        /// <param name="isWriteAction"></param>
        /// <param name="userAgent"></param>
        private static IDictionary<string, string> BuildHFHeaders(string? token = null, bool isWriteAction = false, IDictionary<string, string>? userAgent = null)
        {
            if(token is not null){
                throw new NotImplementedException("Token support is not implemented yet");
            }

            // TODO: verify the implementations and complete it
            return userAgent ?? new Dictionary<string, string>();
        }
    }
}