using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct RtlDriveLetterCurDir {
        public ushort Flags;
        public ushort Length;
        public uint Timestamp;
        public UnicodeString DosPath;

        public static int Size {
            get { return Marshal.SizeOf(typeof(RtlDriveLetterCurDir)); }
        }
    }
}