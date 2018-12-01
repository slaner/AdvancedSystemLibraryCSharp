using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct GdiHandleBuffer {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =
#if X64
			60
#else
            34
#endif
        )]
        public uint[] Buffer;
    }
}
