# Build a shared binaries bundle of SDL2 and SDL2_* libs for Linux

This document contains instruction for manual build bundle of SDL2 libs for linux

**Please note that the best way is to install this libs from the repository of your linux distro.** 

At the end you will got precompiled libs for `x86_64`:
* `SDL2` 2.0.8 - cause it needs Android API Level 19 (2.0.9 wants >= 26)
* `SDL2_image` 2.0.4
* `SDL2_mixer` 2.0.4
* `SDL2_ttf` 2.0.15

## Credits

* SDL2 - https://www.libsdl.org/
* SDL2 Wiki - https://wiki.libsdl.org/Installation#Linux.2FUnix

## Pre-requisites

If you will not alter commands (change dirname, and etc) - all commands can be copy-past-execute. 

Tested on Kubuntu 18.04 x86_64

```
sudo apt-get install build-essential make cmake autoconf automake libtool wget unzip

# SDL2
sudo apt-get install libwayland-dev libxkbcommon-dev wayland-protocols libasound2-dev libpulse-dev libaudio-dev libx11-dev libxext-dev libxrandr-dev libxcursor-dev libxi-dev libxinerama-dev libxxf86vm-dev libxss-dev libgl1-mesa-dev libdbus-1-dev libudev-dev libglvnd-dev libgles2-mesa-dev libegl1-mesa-dev libibus-1.0-dev fcitx-libs-dev libsamplerate0-dev libsndio-dev

# SDL2_image
sudo apt-get install libwebp-dev libtiff-dev libjpeg-dev libpng-dev

# SDL2_mixer
sudo apt-get install libvorbis-dev libflac-dev libfluidsynth-dev libmodplug-dev libmpg123-dev libopus-dev 

# make dirs
mkdir -p ~/SDL2_linux/linux/x86_64
mkdir -p ~/SDL2_linux/root


# build_lib.sh script
echo -e "cd ~/SDL2_linux/\$3\nmake clean\n./configure --prefix=`echo ~`/SDL2_linux/root --host=\$1-linux-gnu\nmake -j$(nproc)\ncp \$4 ~/SDL2_linux/linux/\$2/\nmake install\n" > ~/SDL2_linux/build_lib.sh
chmod +x ~/SDL2_linux/build_lib.sh

# build_bundle.sh script
echo > ~/SDL2_linux/build_bundle.sh
chmod +x ~/SDL2_linux/build_bundle.sh
nano ~/SDL2_linux/build_bundle.sh

```
#### Copy next block to `~/SDL2_linux/build_bundle.sh` 
```
# recreate destination root
rm -rf ~/SDL2_linux/root
mkdir -p ~/SDL2_linux/root

# SDL2
~/SDL2_linux/build_lib.sh $1 $2 SDL2 build/.libs/libSDL2-2.0.so.0

# SDL2_image
~/SDL2_linux/build_lib.sh $1 $2 SDL2_image/external/libpng-1.6.32 .libs/libpng16.so.16
~/SDL2_linux/build_lib.sh $1 $2 SDL2_image/external/jpeg-9b .libs/libjpeg.so.9
~/SDL2_linux/build_lib.sh $1 $2 SDL2_image/external/libwebp-1.0.0 src/.libs/libwebp.so.7
~/SDL2_linux/build_lib.sh $1 $2 SDL2_image/external/tiff-4.0.8 libtiff/.libs/libtiff.so.5
~/SDL2_linux/build_lib.sh $1 $2 SDL2_image .libs/libSDL2_image-2.0.so.0 

# SDL2_mixer 
~/SDL2_linux/build_lib.sh $1 $2 SDL2_mixer/external/libogg-1.3.2 src/.libs/libogg.so.0
~/SDL2_linux/build_lib.sh $1 $2 SDL2_mixer/external/flac-1.3.2 src/libFLAC/.libs/libFLAC.so.8
~/SDL2_linux/build_lib.sh $1 $2 SDL2_mixer/external/libvorbis-1.3.5 lib/.libs/libvorbis.so.0
~/SDL2_linux/build_lib.sh $1 $2 SDL2_mixer/external/mpg123-1.25.6 src/libmpg123/.libs/libmpg123.so.0
~/SDL2_linux/build_lib.sh $1 $2 SDL2_mixer/external/opus-1.0.3 .libs/libopus.so.0 
~/SDL2_linux/build_lib.sh $1 $2 SDL2_mixer build/.libs/libSDL2_mixer-2.0.so.0

# SDL2_ttf
~/SDL2_linux/build_lib.sh $1 $2 SDL2_ttf/external/freetype-2.9.1 objs/.libs/libfreetype.so.6 --enable-freetype-config
~/SDL2_linux/build_lib.sh $1 $2 SDL2_ttf .libs/libSDL2_ttf-2.0.so.0

```

## Build SDL2 and SDL2_* libs 

#### Download and unpack src files
```
cd ~/SDL2_linux/
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

#### Build bundle
```
~/SDL2_linux/build_bundle.sh x86_64 x86_64
```

#### Strip (optional)

## ToDo 
* cross-compile x86 version
```
# in progress
# sudo apt-get install gcc-i686-linux-gnu gcc-multilib 
# mkdir -p ~/SDL2_linux/linux/x86
# ~/SDL2_linux/build_bundle.sh i686 x86 
```
* cross-compile arm raspberry pi version (github.com/raspberrypi/tools)
