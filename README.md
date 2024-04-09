# Fretty in Maui

Fretty is a helpful guitar assistant implemented in .NET and C++. Time to get ready for Fretty!

## Structure

The following graphic accurately depicts the structure of this project:

![](assets/fretty.svg)

The main points include:

### MauiFretty

A cross-platform .NET MAUI application.

### FrettysEssentia

A C++ backend application capable of satisfying requests to process audio. Audio processing tasks include but are not limited to:

- Chord detection
- Tempo detection
- Key detection

## Build and Run

The following steps will successfully download, install, and run this project.

### Dependencies

First, ensure you have the following dependencies installed:

- [FrettysEssentia](https://github.com/music-retrieval/FrettysEssentia)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download)
- [.NET MAUI](https://dotnet.microsoft.com/en-us/learn/maui/first-app-tutorial/install)
- [Xcode](https://developer.apple.com/xcode/) (MacOS only)
- [JetBrains Rider](https://www.jetbrains.com/community/education/#students) (Recommended for development)
- [Android Studio](https://developer.android.com/studio) (Recommended for Android development)

Next, clone the repository:

     git clone https://github.com/music-retrieval/MauiFretty.git

You are now ready to build and run this application.

### Build

With the correct environment configured in the previous steps, we are ready to build the app.

First, restore nuget packages:

     cd MauiFretty
     dotnet restore Fretty.sln

Next build and publish the solution:
     
     mkdir artifacts
     dotnet build -f <target> -c Release -o ./artifacts
     dotnet publish -f <target> -c Release -p:BuildIpa=True -o ./artifacts

where `<target>` is the intended target platform and one of:

- net8.0-maccatalyst (Mac)
- net8.0-ios (iOS)
- net8.0-android (Android)
- net8.0-windows10.0.19041.0 (Windows)

### Run

Double click the produced artifact on Mac or Windows. Mobile steps to come.
