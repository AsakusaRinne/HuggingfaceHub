using System;
using System.Net;
using Huggingface.Common;
using Newtonsoft.Json;

namespace Huggingface
{
    public partial class HFDownloader
    {
        /// <summary>
        /// Get info on one specific model on huggingface.co
        /// Model can be private if you pass an acceptable token.
        /// </summary>
        /// <param name="repoId">A namespace (user or an organization) and a repo name separated by a `/`.</param>
        /// <param name="revision">The revision of the model repository from which to get the information.</param>
        /// <param name="timeout">Whether to set a timeout for the request to the Hub.</param>
        /// <param name="token">
        /// A valid authentication token (see https://huggingface.co/settings/token).
        /// If `None` or `True` and machine is logged in (through `huggingface-cli login`
        /// or [`~huggingface_hub.login`]), token will be retrieved from the cache.
        /// If `False`, token is not sent in the request header.
        /// </param>
        /// <returns></returns>
        public static async Task<ModelInfo?> GetModelInfoAsync(string repoId, string revision = "main", int? timeout = null, string? token = null)
        {
            string path = revision.Equals("main") ? $"{HFGlobalConfig.EndPoint}/api/models/{repoId}"
             : $"{HFGlobalConfig.EndPoint}/api/models/{repoId}/revision/{Uri.EscapeDataString(revision)}";
            var response = await HttpClient.GetAsync(path);
            if(response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Failed to get model info: {response.StatusCode}. " +  
                "Please check your input first, then try to use a mirror site.");
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ModelInfo>(content);
        }
    }
}