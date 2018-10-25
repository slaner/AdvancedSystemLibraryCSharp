// $LEGAL_NOTICE
using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Internals.Structures {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32 {
        public uint dwSize;
        public uint cntUsage;
        public uint th32ProcessID;
        public IntPtr th32DefaultHeapID;
        public uint th32ModuleID;
        public uint cntThreads;
        public uint th32ParentProcessID;
        public uint pcPriClassBase;
        public uint dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szExeFile;
        public static int Size {
            get { return Marshal.SizeOf(typeof(ProcessEntry32)); }
        }
    }
}