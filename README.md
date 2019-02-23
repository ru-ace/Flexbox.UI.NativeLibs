# SDL2-CS-libs-bundle

This repo contains precompiled SDL2 & SDL2_* libs for various platforms. 

This is a git submodule for my multi-platform projects written using [SDL2-CS](https://github.com/flibitijibibo/SDL2-CS/) (C# wrapper for SDL2).


It contain libs:
* `SDL2` 2.0.8
* `SDL2_image` 2.0.4
* `SDL2_mixer` 2.0.4
* `SDL2_ttf` 2.0.15

For platforms:
* `android`: `arm64-v8a`, `armeabi-v7a`, `x86`, `x86_64`
* `linux`: `x86_64`
* `windows`: `x86`, `x86_64`

* platforms and architectures will be expanded in future during porting time.

Androids libs are useful for porting projects using proof-of-concept [SDL2-CS-Xamarin.Android](https://github.com/ru-ace/SDL2-CS-Xamarin.Android)

Please note that libs not stripped.

## Why?

* I need binaries for developing and testing projects written in C#(mono) with [SDL2-CS](https://github.com/flibitijibibo/SDL2-CS/) on different platforms.
* I has several crossplatform linked project, so I decide to create one git submodule with all needed precompiled libraries, cause i need identical version of libs at different platforms and all projects
* I stuck with SDL2 version 2.0.8 - this is version could be used with Android API Level 19 (2.0.9 wants >= 26) 

## Manual builds

You can build libs bundle by yourself using instructions from this repo:
* [Android](./BUILD.android.md)
* [Linux](./BUILD.linux.md)
* [Windows](./BUILD.windows.md)
