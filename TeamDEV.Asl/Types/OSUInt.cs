using System;

#if X64
using __uint3264 = System.UInt64;
#else
using __uint3264 = System.UInt32;
#endif

namespace TeamDEV.Asl.Types {
    /// <summary>
    /// Represents a platform specific unsigned integer. (uint for x86 build, ulong for x64 build)
    /// </summary>
    public struct OSUInt {
        private __uint3264 innerValue;

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
        /// Gets size of <see cref="OSUInt" /> structures in bytes.
        /// </summary>
        public static int Size => sizeof(__uint3264);

        public static implicit operator __uint3264(OSUInt value) {
            return value.innerValue;
        }
        public static implicit operator OSUInt(__uint3264 value) {
            return value;
        }
        public static implicit operator UIntPtr(OSUInt value) {
            return new UIntPtr(value.innerValue);
        }
        public static implicit operator OSUInt(UIntPtr value) {
            return new OSUInt {
                innerValue = (__uint3264) value
            };
        }
    }
}