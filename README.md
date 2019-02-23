# SDL2-CS-libs-bundle

This repo contains precompiled `SDL2*` and related shared libs for various platforms. 

I use it as a git submodule for my multi-platform projects written using [SDL2-CS](https://github.com/flibitijibibo/SDL2-CS/) (C# wrapper for SDL2).


SDL2 libs:
* `SDL2` 2.0.8 - will not be updated, because 2.0.9 wants Android API Level >= 26 
* `SDL2_image` 2.0.4
* `SDL2_mixer` 2.0.4
* `SDL2_ttf` 2.0.15

Platforms:
* `android`: `arm64-v8a`, `armeabi-v7a`, `x86`, `x86_64`
* `osx`: `>=10.6`
* `linux`: `x86_64`
* `windows`: `x86`, `x86_64`

The list of platforms and architectures will be expanded in the future during porting.

Android libraries are useful for porting projects using [SDL2-CS-Xamarin.Android](https://github.com/ru-ace/SDL2-CS-Xamarin.Android)

Please note that libs not stripped.

## Why?

* I need this libs for developing and testing projects written in C#(mono) with [SDL2-CS](https://github.com/flibitijibibo/SDL2-CS/) on different platforms.
* I have several cross-platform linked projects, and this repository allows me to use one git submodule with all the necessary pre-compiled libraries in all related projects.
* I need identical versions of libraries on different platforms and in all related projects.

## Manual builds

You can build bundle of libs by yourself using the instructions from `BUILD.*.md`:
* [Android](./BUILD.android.md)
* [macOS](./BUILD.osx.md)
* [Linux](./BUILD.linux.md)
* [Windows](./BUILD.windows.md)
