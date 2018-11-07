using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct TokenPrivileges {
        public int Count;
        public Luid Luid;
        public int Attributes;

        public static int Size {
            get { return Marshal.SizeOf(typeof(TokenPrivileges)); }
        }
    }
}
