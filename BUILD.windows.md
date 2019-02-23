# Creating bundle of `SDL2*` and related shared libs for Windows

This document contains instruction for creating bundle of SDL2 shared libs for Windows

At the end you will got precompiled libs for `x86`, `x86_64`:
* `SDL2` 2.0.8 - will not be updated, because 2.0.9 wants Android API Level >= 26 
* `SDL2_image` 2.0.4
* `SDL2_mixer` 2.0.4
* `SDL2_ttf` 2.0.15

libsdl.org provides precompiled runtime binaries:
* `SDL2` - https://www.libsdl.org/download-2.0.php
* `SDL2_image` - https://www.libsdl.org/projects/SDL_image/
* `SDL2_mixer` - https://www.libsdl.org/projects/SDL_mixer/
* `SDL2_ttf` - https://www.libsdl.org/projects/SDL_ttf/

## Pre-requisites

If you will not alter commands (change dirname, and etc) - all commands can be copy-past-execute. 

Tested on Kubuntu 18.04 x86_64

```
sudo apt-get install wget unzip
mkdir -p ~/SDL2_windows/dl
mkdir -p ~/SDL2_windows/LICENSE
mkdir -p ~/SDL2_windows/windows/x86
mkdir -p ~/SDL2_windows/windows/x64
```

## Create bundle of SDL2 and SDL2_* libs 

#### Download and unzip precompiled libs
```
cd ~/SDL2_windows/dl
wget https://www.libsdl.org/release/SDL2-2.0.8-win32-x64.zip
wget https://www.libsdl.org/release/SDL2-2.0.8-win32-x86.zip
wget https://www.libsdl.org/projects/SDL_image/release/SDL2_image-2.0.4-win32-x64.zip
wget https://www.libsdl.org/projects/SDL_image/release/SDL2_image-2.0.4-win32-x86.zip
wget https://www.libsdl.org/projects/SDL_mixer/release/SDL2_mixer-2.0.4-win32-x64.zip
wget https://www.libsdl.org/projects/SDL_mixer/release/SDL2_mixer-2.0.4-win32-x86.zip
wget https://www.libsdl.org/projects/SDL_ttf/release/SDL2_ttf-2.0.15-win32-x64.zip
wget https://www.libsdl.org/projects/SDL_ttf/release/SDL2_ttf-2.0.15-win32-x86.zip

# unzip to dirs
for f in *.zip; do unzip -d "${f%*.zip}" "$f"; done
```
#### Move files to bundle dir
```
cd ~/SDL2_windows/dl

# x86
for f in *-x86.zip; do mv "${f%*.zip}"/*.dll ~/SDL2_windows/windows/x86/; done

# x64
for f in *-x64.zip; do mv "${f%*.zip}"/*.dll ~/SDL2_windows/windows/x64/; done

# LICENSE
for f in *-x86.zip; do mv "${f%*.zip}"/LICENSE.*.txt ~/SDL2_windows/LICENSE/; done
mv SDL2-2.0.8-win32-x86/README-SDL.txt ~/SDL2_windows/LICENSE/README-SDL2.txt
mv SDL2_image-2.0.4-win32-x86/README.txt ~/SDL2_windows/LICENSE/README-SDL2_image.txt
mv SDL2_mixer-2.0.4-win32-x86/README.txt ~/SDL2_windows/LICENSE/README-SDL2_mixer.txt
mv SDL2_ttf-2.0.15-win32-x86/README.txt ~/SDL2_windows/LICENSE/README-SDL2_ttf.txt
