using System;

#if X64
using __int3264 = System.Int64;
#else
using __int3264 = System.Int32;
#endif

namespace TeamDEV.Asl.Types {
    /// <summary>
    /// Represents a platform specific signed integer. (int for x86 build, long for x64 build)
    /// </summary>
    public struct OSInt {
        private __int3264 innerValue;

        public override string ToString() {
            return innerValue.ToString();
        }
        public string ToString(string format) {
            return innerValue.ToString(format);
        }
        public string ToString(IFormatProvider provider) {
            return innerValue.ToString(provider);
        }
        public string ToString(string format, IFormatProvider provider) {
            return innerValue.ToString(format, provider);
        }

        /// <summary>
        /// Gets size of <see cref="OSInt" /> structures in bytes.
        /// </summary>
        public static int Size => sizeof(__int3264);

        public static implicit operator __int3264(OSInt value) {
            return value.innerValue;
        }
        public static implicit operator OSInt(__int3264 value) {
            return new OSInt {
                innerValue = value
            };
        }
        public static implicit operator IntPtr(OSInt value) {
            return new IntPtr(value.innerValue);
        }
        public static implicit operator OSInt(IntPtr value) {
            return new OSInt {
                innerValue = (__int3264) value
            };
        }
    }
}