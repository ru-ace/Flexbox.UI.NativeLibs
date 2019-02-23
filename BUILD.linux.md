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

mkdir -p ~/SDL2_linux/linux/x86_64


# build_lib.sh script
echo -e "cd ~/SDL2_linux/\$2\nmake clean\n./configure --host=\$1-linux-gnu\nmake -j$(nproc)\ncp \$3/lib\$2-2.0.so.0 ~/SDL2_linux/linux/\$4/\nmake clean\n" > ~/SDL2_linux/build_lib.sh
chmod +x ~/SDL2_linux/build_lib.sh

# build_bundle.sh script
echo -e "~/SDL2_linux/build_lib.sh \$1 SDL2 build/.libs \$2\n~/SDL2_linux/build_lib.sh \$1 SDL2_image .libs \$2\n~/SDL2_linux/build_lib.sh \$1 SDL2_mixer build/.libs \$2\n~/SDL2_linux/build_lib.sh \$1 SDL2_ttf .libs \$2\n" > ~/SDL2_linux/build_bundle.sh
chmod +x ~/SDL2_linux/build_bundle.sh


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
* precompile external libs
