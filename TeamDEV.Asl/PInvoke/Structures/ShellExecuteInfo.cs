using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential)]
    public struct ShellExecuteInfo {
        public uint cbSize;
        public uint fMask;
        public IntPtr hWnd;
        public string lpVerb;
        public string lpFile;
        public string lpParameters;
        public string lpDirectory;
        public int nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        public string lpClass;
        public IntPtr hKeyClass;
        public uint dwHotKey;
        public IntPtr hIcon;        // same as hMonitor
        public IntPtr hProcess;

        public static int Size => Marshal.SizeOf(typeof(ShellExecuteInfo));
    }
}