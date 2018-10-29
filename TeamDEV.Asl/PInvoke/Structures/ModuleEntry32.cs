// $LEGAL_NOTICE
using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
        [StructLayout(LayoutKind.Sequential)]
        public struct ModuleEntry32 {
            public uint dwSize;
            public uint th32ModuleID;
            public uint th32ProcessID;
            public uint GlblcntUsage;
            public uint ProccntUsage;
            public IntPtr modBaseAddr;
            public uint modBaseSize;
            public IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExePath;

            public static int Size {
                get { return Marshal.SizeOf(typeof(ModuleEntry32)); }
            }
        }
    }