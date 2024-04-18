using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Huggingface;

// var res = await LlamaDownloader.LlamaDownloadFileAsync(
//     "https://hf-mirror.com/openai/clip-vit-base-patch16/resolve/main/config.json",
//     "/Users/liuyaohui/code/community/HFDownaloder/config.json"
// );

HFGlobalConfig.EndPoint = "https://hf-mirror.com";
// var res = await HFDownloader.GetHfFileMetadata("https://hf-mirror.com/openai/clip-vit-base-patch16/resolve/main/config.json");
// Console.WriteLine(res);

var path = await HFDownloader.DownloadFile("openai/clip-vit-base-patch16", "config.json");
Console.WriteLine($"### Saved to {path}");
