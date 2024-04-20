A library to download models & files from HuggingFace with C#.

*This library is under development. Some features have been completed but hey haven't been well tested. If you have any problem when running it from source, please open an issue to tell us.*

## Key features

- [x] Download single file.
- [x] Get information of file and repo.
- [x] Download snapshot (repo).
- [x] Resume download.
- [x] Parallel download multiple files (only in .NET 6 or higher).
- [ ] Upload files.
- [ ] Support repo types other than model.

## Usage

### Download single file

```cs
using Huggingface;
var path = await HFDownloader.DownloadFileAsync("<RepoId>", "<Filename>");
```

### Download repo

```cs
using Huggingface;
var res = await HFDownloader.DownloadSnapshotAsync("<RepoId>");
```

### Get repo information

*Currently, only model-type repo is supported.*

```cs
using Huggingface;
var info = await HFDownloader.GetModelInfoAsync("<RepoId>");
```

### Download the repo with progress handler

```cs
using Huggingface;
var res = await HFDownloader.DownloadSnapshotAsync("<RepoId>", progress: new MyConsoleProgress());

class MyConsoleProgress: IGroupedProgress
{
    public void Report(string filename, int progress)
    {
        // Do your work here. 
        // `progress` is in range [0, 100].
    }
}
```

### Customize the endpoint

```cs
using Huggingface;
HFGlobalConfig.EndPoint = "<Endpoint Url>";
```

**Please check the definition of `HFGlobalConfig` to see all the configuration you could set.**


## Acknowledgement

This library is mainly adopts from [huggingface_hub](https://github.com/huggingface/huggingface_hub), which is the official implementation written in Python.