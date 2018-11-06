// $LEGAL_NOTICE
using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectAttributes {
        public uint Length;
        public IntPtr RootDirectory;
        public IntPtr ObjectName;
        public uint Attributes;
        public IntPtr SecurityDescriptor;
        public IntPtr SecurityQOS;
        public static int Size {
            get { return Marshal.SizeOf(typeof(ObjectAttributes)); }
        }
    }
}