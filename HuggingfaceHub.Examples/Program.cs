using Huggingface;
using Microsoft.Extensions.Logging;
using HuggingfaceHub;

//HFGlobalConfig.EndPoint = "https://hf-mirror.com";
using var factory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Information));
HFDownloader.Logger = factory.CreateLogger("HFDownloader");
// var meta = await HFDownloader.GetHfFileMetadata(new Uri("https://hf-mirror.com/mrm8488/bert-tiny-finetuned-sms-spam-detection/resolve/main/flax_model.msgpack"));
// Console.WriteLine(meta);

//var path = await HFDownloader.DownloadFileAsync("mrm8488/bert-tiny-finetuned-sms-spam-detection", "model.safetensors");
//Console.WriteLine($"### Saved to {path}");

var res = await HFDownloader.DownloadSnapshotAsync("Bingsu/vitB32_bert_ko_small_clip", "main", maxWorkers: 4, progress: new GroupedConsoleProgress());


//var res = await HFDownloader.DownloadFileAsync("magicslabnu/clip_vit_small_patch16_224", "pytorch_model.bin", progress:new ConsoleProgress());

Console.WriteLine($"### Saved to {res}");

class ConsoleProgress : IProgress<float>
{
    public void Report(float value)
    {
        Console.WriteLine($"{value * 100}%");
    }
}

class GroupedConsoleProgress: IGroupedProgress
{
    public void Report(string filename, int progress)
    {
        Console.WriteLine(filename + " " + progress + "%");
    }
}