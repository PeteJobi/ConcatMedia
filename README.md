# Concat Media
Using Concat Media, you can merge video or audio files together, provided the files you're merging have the same extensions, codec parameters and number of tracks. Only supports Windows 10 and 11 (not tested on other versions of Windows). Powered by FFMPEG.

<img width="690" height="522" alt="image" src="https://github.com/user-attachments/assets/00bd8bad-bf6a-4c8e-9d42-b358f5b21832" />

## How to build
You need to have at least .NET 9 runtime installed to build the software. Download the latest runtime [here](https://dotnet.microsoft.com/en-us/download). If you're not sure which one to download, try [.NET 9.0 Version 9.0.203](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-9.0.203-windows-x64-installer)

In the project folder, run the below
```
dotnet publish -c Release -p:Platform=x64 -p:WindowsAppSDKSelfContained=true -p:WindowsPackageType=None
```
When that completes, go to `\bin\Release\net<version>-windows\win-x64` and you'll find the **ConcatMedia.exe**.

## Run without building
You can also just download the release builds if you don't wish to build manually. Unfortunately packages created in WinUI 3 have to be signed with a certificate, and certificates sourced from trusted companies cost hundreds of dollars. If you wish to install the package, you'll have to install a certificate signed by myself, as described [here](https://github.com/PeteJobi/ConcatMedia/releases/tag/cert). You only need to do this once - future updates will not require different certificates.

## How to use
When you open the program, you will be prompted to upload media files. Once that is done, you will be taken to the concat interface page. All the files you selected will be shown in a list in alphabetical order. You can delete individual files, and you can also upload more files. You can also drag and drop files in the list to rearrange them. When you're done setting up, click the **Concat** button to start the merge process.

It's important to note that the files you try to merge must be of similar types. They have to be of the same file extension (.mp4 and .mkv won't work). They must have the same codec parameters (e.g same framerate and resolution for video, same sample rate and channel layout for audio). They must have the same number of tracks/streams (a video with 1 audio track cannot be merged with one with 2 audio tracks).

This program is suited to merge files that have been cut up into chunks with programs like [VideoSplitter](https://github.com/PeteJobi/VideoSplitter).
