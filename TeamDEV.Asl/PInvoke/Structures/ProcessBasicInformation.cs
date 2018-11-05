using System;
using System.Runtime.InteropServices;

using TeamDEV.Asl.PInvoke.Enumerations;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessBasicInformation {
        public NTSTATUS ExitStatus;
        public IntPtr PebBaseAddress;
        public IntPtr AffinityMask;
        public int BasePriority;
        public IntPtr UniqueProcessId;
        public IntPtr InheritedFromUniqueProcessId;

        public static int Size {
            get { return Marshal.SizeOf(typeof(ProcessBasicInformation)); }
        }
    }
}