using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct RtlUserProcessParametersEx {
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

        public IntPtr Environment;

        public uint StartingX;
        public uint StartingY;
        public uint CountX;
        public uint CountY;
        public uint CountCharsX;
        public uint CountCharsY;
        public uint FillAttribute;
        public uint WindowFlags;
        public uint ShowWindowFlags;

        public UnicodeString WindowTitle;
        public UnicodeString DesktopInfo;
        public UnicodeString ShellInfo;
        public UnicodeString RuntimeData;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public RtlDriveLetterCurDir[] CurrentDirectores;
        public uint EnvironmentSize;

        public static int Size {
            get { return Marshal.SizeOf(typeof(RtlUserProcessParametersEx)); }
        }
    }
}