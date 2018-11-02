// $LEGAL_NOTICE
using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectAttributes {
        public UInt32 Length;
        public IntPtr RootDirectory;
        public IntPtr ObjectName;
        public UInt32 Attributes;
        public IntPtr SecurityDescriptor;
        public IntPtr SecurityQOS;
        public static UInt32 Size {
            get { return (UInt32) Marshal.SizeOf(typeof(ObjectAttributes)); }
        }
    }
}