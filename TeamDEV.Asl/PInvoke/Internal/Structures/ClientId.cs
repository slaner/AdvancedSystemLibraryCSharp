using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Internals.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ClientId {
        public IntPtr UniqueProcess;
        public IntPtr UniqueThread;
        public static int Size {
            get { return Marshal.SizeOf(typeof(ClientId)); }
        }
    }
}