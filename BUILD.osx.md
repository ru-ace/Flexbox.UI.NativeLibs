# Building bundle of `SDL2*` and related shared libs for Mac OS X

This document contains instructions for manually building bundle of SDL2 shared libs for macOS

At the end you will got precompiled libs for macOS `>=10.6`:
* `SDL2` 2.0.8 - will not be updated, because 2.0.9 wants Android API Level >= 26 
* `SDL2_image` 2.0.4
* `SDL2_mixer` 2.0.4
* `SDL2_ttf` 2.0.15

## Credits

* SDL2 - https://www.libsdl.org/
* SDL2 Wiki - https://wiki.libsdl.org/Installation#Mac_OS_X

## Pre-requisites

If you will not alter commands (change dirname, and etc) - all commands can be copy-past-execute. 

Tested on macOS Majave 10.14.3 with Xcode 10.1

```
xcode-select --install
mkdir -p ~/SDL2_osx/osx/
mkdir -p ~/SDL2_osx/root/

# build_lib.sh script
echo -e "cd ~/SDL2_osx/\$1\nmake clean\n./configure --prefix=`echo ~`/SDL2_osx/root CFLAGS=\"-mmacosx-version-min=10.6 -DMAC_OS_X_VERSION_MIN_REQUIRED=1060\" \$3\nmake -j`sysctl -n hw.ncpu`\ncp \$2 ~/SDL2_osx/osx/\nmake install\n" > ~/SDL2_osx/build_lib.sh
chmod +x ~/SDL2_osx/build_lib.sh
```
## Build SDL2 and SDL2_* libs 

#### Download and unpack src files
```
cd ~/SDL2_osx/
curl -O https://www.libsdl.org/release/SDL2-2.0.8.tar.gz
curl -O https://www.libsdl.org/projects/SDL_image/release/SDL2_image-2.0.4.tar.gz
curl -O https://www.libsdl.org/projects/SDL_mixer/release/SDL2_mixer-2.0.4.tar.gz
curl -O https://www.libsdl.org/projects/SDL_ttf/release/SDL2_ttf-2.0.15.tar.gz

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
# SDL2
~/SDL2_osx/build_lib.sh SDL2 build/.libs/libSDL2-2.0.0.dylib

# SDL2_image
~/SDL2_osx/build_lib.sh SDL2_image/external/libpng-1.6.32 .libs/libpng16.16.dylib
~/SDL2_osx/build_lib.sh SDL2_image/external/jpeg-9b .libs/libjpeg.9.dylib
~/SDL2_osx/build_lib.sh SDL2_image/external/libwebp-1.0.0 src/.libs/libwebp.7.dylib
~/SDL2_osx/build_lib.sh SDL2_image/external/tiff-4.0.8 libtiff/.libs/libtiff.5.dylib
~/SDL2_osx/build_lib.sh SDL2_image .libs/libSDL2_image-2.0.0.dylib 

# SDL2_mixer 
~/SDL2_osx/build_lib.sh SDL2_mixer/external/libogg-1.3.2 src/.libs/libogg.0.dylib
~/SDL2_osx/build_lib.sh SDL2_mixer/external/flac-1.3.2 src/libFLAC/.libs/libFLAC.8.dylib
~/SDL2_osx/build_lib.sh SDL2_mixer/external/libvorbis-1.3.5 lib/.libs/*.*.dylib
~/SDL2_osx/build_lib.sh SDL2_mixer/external/mpg123-1.25.6 src/libmpg123/.libs/libmpg123.0.dylib
~/SDL2_osx/build_lib.sh SDL2_mixer/external/opus-1.0.3 .libs/libopus.0.dylib 
~/SDL2_osx/build_lib.sh SDL2_mixer build/.libs/libSDL2_mixer-2.0.0.dylib "--enable-music-mp3-mpg123=`echo ~`/SDL2_osx/root --enable-music-ogg=`echo ~`/SDL2_osx/root --enable-music-flac=`echo ~`/SDL2_osx/root --enable-music-opus=`echo ~`/SDL2_osx/root"

# SDL2_ttf
~/SDL2_osx/build_lib.sh SDL2_ttf/external/freetype-2.9.1 objs/.libs/libfreetype.6.dylib --enable-freetype-config
~/SDL2_osx/build_lib.sh SDL2_ttf .libs/libSDL2_ttf-2.0.0.dylib --with-ft-prefix=`echo ~`/SDL2_osx/root

```
