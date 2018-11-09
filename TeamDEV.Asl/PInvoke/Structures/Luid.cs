using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct Luid {
        public uint Low;
        public int High;

        public static int Size {
            get { return Marshal.SizeOf(typeof(Luid)); }
        }
    }
}