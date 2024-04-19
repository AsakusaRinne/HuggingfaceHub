using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Huggingface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

// var res = await LlamaDownloader.LlamaDownloadFileAsync(
//     "https://hf-mirror.com/openai/clip-vit-base-patch16/resolve/main/config.json",
//     "/Users/liuyaohui/code/community/HFDownaloder/config.json"
// );

HFGlobalConfig.EndPoint = "https://hf-mirror.com";
using var factory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Information));
HFDownloader.Logger = factory.CreateLogger("HFDownloader");
// var meta = await HFDownloader.GetHfFileMetadata(new Uri("https://hf-mirror.com/mrm8488/bert-tiny-finetuned-sms-spam-detection/resolve/main/flax_model.msgpack"));
// Console.WriteLine(meta);

// var path = await HFDownloader.DownloadFileAsync("openai/clip-vit-base-patch16", "config.json");
// Console.WriteLine($"### Saved to {path}");

// var res = await HFDownloader.DownloadSnapshotAsync("mrm8488/bert-tiny-finetuned-sms-spam-detection", "main", maxWorkers:1);


var res = await HFDownloader.DownloadFileAsync("magicslabnu/clip_vit_small_patch16_224", "pytorch_model.bin", progress:new ConsoleProgress());

class ConsoleProgress : IProgress<float>
{
    public void Report(float value)
    {
        Console.WriteLine($"{value * 100}%");
    }
}