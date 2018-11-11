using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ListEntry {
        public IntPtr FLink;
        public IntPtr BLink;

        public static int Size {
            get { return Marshal.SizeOf(typeof(ListEntry)); }
        }
    }
}