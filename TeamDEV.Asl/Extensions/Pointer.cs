using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.Extensions {
    static class Pointer {
        public static bool IsZero(this IntPtr p) {
            return p == IntPtr.Zero;
        }
    }
}