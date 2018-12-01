using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct RtlUserProcessParameters {
        public uint MaximumLength;
        public uint Length;
        public uint Flags;
        public uint DebugFlags;

        public IntPtr ConsoleHandle;
        public uint ConsoleFlags;

        public IntPtr StandardInput;
        public IntPtr StandardOutput;
        public IntPtr StandardError;

        public CurDir CurrentDirectory;

        public UnicodeString DllPath;
        public UnicodeString ImagePathName;
        public UnicodeString CommandLine;

        public static int Size {
            get { return Marshal.SizeOf(typeof(RtlUserProcessParameters)); }
        }
    }
}