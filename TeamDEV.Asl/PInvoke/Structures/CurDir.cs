using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct CurDir {
        public UnicodeString DosPath;
        public IntPtr Handle;

        public static int Size {
            get { return Marshal.SizeOf(typeof(CurDir)); }
        }
    }
}