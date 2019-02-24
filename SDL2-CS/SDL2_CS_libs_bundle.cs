#region License
/* SDL2_CS_libs_bundle - Support class for git submodule https://github.com/ru-ace/SDL2-CS-libs-bundle
 *
 * Copyright (c) 2019 ace.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * ace (https://github.com/ru-ace/)
 *
 */
#endregion

using System;
using System.Runtime.InteropServices;
using System.IO;
namespace SDL2
{
    public static class SDL2_CS_libs_bundle
    {

        public static void Init()
        {
            // Mono respects SDL2-CS.dll.config, .NET - no
            Type t = Type.GetType("Mono.Runtime");

            if (t == null && (int)Environment.OSVersion.Platform <= 4)
            {
                // Make small hack for .NET under windows
                string ds = Path.DirectorySeparatorChar.ToString();
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + ds + "libs" + ds + "windows" + ds;

                if (System.Environment.Is64BitProcess)
                    SetDllDirectory(path + "x64");
                else
                    SetDllDirectory(path + "x86");
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool SetDllDirectory(string lpPathName);
    }

}
