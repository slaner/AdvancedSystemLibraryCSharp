using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct PebLdrData {
        public uint Length;
        public uint Initialized;
        public IntPtr SsHandle;
        public ListEntry InLoadOrderModuleList;
        public ListEntry InMemoryOrderModuleList;
        public ListEntry InInitializationOrderModuleList;
        public IntPtr EntryInProgress;

        public static int Size {
            get { return Marshal.SizeOf(typeof(PebLdrData)); }
        }
    }
}