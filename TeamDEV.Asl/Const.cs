using System;
using System.Collections.Generic;

namespace TeamDEV.Asl {
    static class Const {
        #region Types
        public static readonly IReadOnlyDictionary<string, Type> AtomicTypes = new Dictionary<string, Type> {
            { nameof(Byte), typeof(Byte) },
            { nameof(SByte), typeof(SByte) },

            { nameof(Char), typeof(Char) },
            { nameof(Int16), typeof(Int16) },
            { nameof(UInt16), typeof(UInt16) },

            { nameof(Int32), typeof(Int32) },
            { nameof(UInt32), typeof(UInt32) },
            { nameof(Single), typeof(Single) },

            { nameof(Int64), typeof(Int64) },
            { nameof(UInt64), typeof(UInt64) },
            { nameof(Double), typeof(Double) },

            { nameof(String), typeof(String) },

            { nameof(IntPtr), typeof(IntPtr) },
            { nameof(UIntPtr), typeof(UIntPtr) },

            { nameof(Decimal), typeof(Decimal) },
        };
        #endregion


        public const string Empty = nameof(Empty);
        public const string Field = nameof(Field);
        public const string Method = nameof(Method);
        public const string Property = nameof(Property);
        public const string Unknown = nameof(Unknown);
        public const string CommonLanguageRuntimeLibrary = nameof(CommonLanguageRuntimeLibrary);
    }
}