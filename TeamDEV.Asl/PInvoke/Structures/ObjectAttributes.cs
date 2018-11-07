// $LEGAL_NOTICE
using System;
using System.Runtime.InteropServices;
using TeamDEV.Asl.PInvoke.Enumerations;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectAttributes {
        public uint Length;
        public IntPtr RootDirectory;
        public IntPtr ObjectName;
        public ObjectAttributesFlags Attributes;
        public IntPtr SecurityDescriptor;
        public IntPtr SecurityQOS;

        public static int Size {
            get { return Marshal.SizeOf(typeof(ObjectAttributes)); }
        }
    }
}