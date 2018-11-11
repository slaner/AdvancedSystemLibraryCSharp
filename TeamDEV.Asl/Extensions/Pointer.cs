using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.Extensions {
    static class Pointer {
        public static bool IsValid(this IntPtr p) {
            return p.ToInt64() >= 0;
        }
        public static bool IsZero(this IntPtr p) {
            return p == IntPtr.Zero;
        }
        public static void FreeHGlobal(this IntPtr p) {
            Marshal.FreeHGlobal(p);
        }
        public static T To<T>(this IntPtr p) where T: struct {
            return (T) Marshal.PtrToStructure(p, typeof(T));
        }
    }
}