using System;
using System.Runtime.InteropServices;


namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessExtendedBasicInformation {
        public int dwSize;
        public ProcessBasicInformation Pbi;
        public ProcessExtendedBasicInformationFlags Flags;
        
        public static int Size {
            get { return Marshal.SizeOf(typeof(ProcessExtendedBasicInformation)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessExtendedBasicInformationFlags {
        public uint Value;

        public bool IsProtectedProcess {
            get { return (Value & 0x1) != 0; }
        }
        public bool IsWow64Process {
            get { return (Value & 0x2) != 0; }
        }
        public bool IsProcessDeleting {
            get { return (Value & 0x4) != 0; }
        }
        public bool IsCrossSessionCreate {
            get { return (Value & 0x8) != 0; }
        }
    }
}