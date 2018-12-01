using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Explicit)]
    public struct ULargeInteger {
        [FieldOffset(0)]
        public ulong QuadPart;
        [FieldOffset(0)]
        public uint LowPart;
        [FieldOffset(4)]
        public int HighPart;

        public static int Size {
            get { return Marshal.SizeOf(typeof(LargeInteger)); }
        }
    }
}