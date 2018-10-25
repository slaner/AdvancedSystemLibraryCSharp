using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.Extensions {
    static class Numeric {
        public static bool IsZero(this char value) {
            return value == 0;
        }
        public static bool IsZero(this byte value) {
            return value == 0;
        }
        public static bool IsZero(this ushort value) {
            return value == 0;
        }
        public static bool IsZero(this short value) {
            return value == 0;
        }
        public static bool IsZero(this int value) {
            return value == 0;
        }
        public static bool IsZero(this uint value) {
            return value == 0;
        }
        public static bool IsZero(this long value) {
            return value == 0;
        }
        public static bool IsZero(this ulong value) {
            return value == 0;
        }
        public static bool IsZero(this decimal value) {
            return value == 0;
        }
    }
}