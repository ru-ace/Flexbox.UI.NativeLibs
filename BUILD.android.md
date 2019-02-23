# Build a shared binaries bundle of SDL and SDL_* libs for Android

This document contains instruction for manual build bundle of SDL2 libs for using in https://github.com/ru-ace/SDL2Droid-CS 

At the end you will got precompiled libs for `arm64-v8a`, `armeabi-v7a`, `x86`, `x86_64`:
* `SDL2` 2.0.8 - cause it needs API Level 19 (2.0.9 wants >= 26)
* `SDL2_image` 2.0.4
* `SDL2_mixer` 2.0.4
* `SDL2_ttf` 2.0.15
* `libmain.so` - wrapper for SDL2Droid-CS

## Credits

* SDL2 - https://www.libsdl.org/
* SDL2 Wiki - https://wiki.libsdl.org/Android (section 4.1)
* SDL2Droid-CS (original) - https://github.com/0x0ade/SDL2Droid-CS

## Pre-requisites

If you will not alter commands (change dirname, and etc) - all commands can be copy-past-execute. 

Tested on Kubuntu 18.04 x86_64

```
sudo apt-get install build-essential openjdk-8-jdk ant android-sdk-platform-tools-common wget unzip
mkdir -p ~/Android/android 
cd ~/Android/
wget https://dl.google.com/android/repository/android-ndk-r10e-linux-x86_64.zip 
unzip android-ndk-r10e-linux-x86_64.zip
``` 

Install Android SDK with API level 19 to `~/Android/sdk`. I use SDK Manager from Android Studio (https://developer.android.com/studio/)

Configure your environment variables:  
```
PATH="~/Android/android-ndk-r10e:$PATH"                     # for 'ndk-build'
PATH="~/Android/sdk/tools:$PATH"                            # for 'android'
PATH="~/Android/sdk/platform-tools:$PATH"                   # for 'adb'
export PATH
export ANDROID_HOME="~/Android/sdk"                         # for gradle
export ANDROID_NDK_HOME="~/Android/android-ndk-r10e"        # for gradle
```
You can edit `~/.bashrc` and add this to the end of file. Re-login.

## SDL2, SDL2_* and libmain for SDL2Droid-CS

#### Download and unpack src files
```
cd ~/Android/
wget https://www.libsdl.org/release/SDL2-2.0.8.tar.gz
wget https://www.libsdl.org/projects/SDL_image/release/SDL2_image-2.0.4.tar.gz
wget https://www.libsdl.org/projects/SDL_mixer/release/SDL2_mixer-2.0.4.tar.gz
wget https://www.libsdl.org/projects/SDL_ttf/release/SDL2_ttf-2.0.15.tar.gz

tar xf SDL2-2.0.8.tar.gz
tar xf SDL2_image-2.0.4.tar.gz
tar xf SDL2_mixer-2.0.4.tar.gz
tar xf SDL2_ttf-2.0.15.tar.gz

ln -s SDL2-2.0.8 SDL2
ln -s SDL2_image-2.0.4 SDL2_image
ln -s SDL2_mixer-2.0.4 SDL2_mixer
ln -s SDL2_ttf-2.0.15 SDL2_ttf
```
#### Config 
``` 
cd ~/Android/SDL2/build-scripts/
# androidbuild.sh must be run just after untar src.tgz. 
# Please don't run configure or other build scripts - compilation will failed. 
./androidbuild.sh org.libsdl /dev/null
cd ~/Android/SDL2/build/org.libsdl/app/jni/
ln -s ~/Android/SDL2_image ./
ln -s ~/Android/SDL2_mixer ./
ln -s ~/Android/SDL2_ttf ./
rm src/*
```
* Copy files from https://github.com/ru-ace/SDL2Droid-CS/tree/master/SDL2Droid-CS-Native/wrapper to `~/Android/SDL2/build/org.libsdl/app/jni/src/`
* Edit `~/Android/SDL2/build/org.libsdl/app/jni/Application.mk` change `APP_PLATFORM` to `android-19`
* Edit `~/Android/SDL2_image/Android.mk` change `WEBP_LIBRARY_PATH` to `external/libwebp-1.0.0`

#### Build 
```
cd ~/Android/SDL2/build/org.libsdl/app/jni/
ndk-build -j$(nproc)
cp -R ~/Android/SDL2/build/org.libsdl/app/libs/* ~/Android/android/
``` 

#### Strip (optional)
