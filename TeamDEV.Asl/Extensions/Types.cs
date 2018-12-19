using System;

namespace TeamDEV.Asl.Extensions {
    static class Types {
        public static bool IsAtomicType(this Type t) {
            return Const.AtomicTypes.ContainsKey(t.Name) && (t == Const.AtomicTypes[t.Name]);
        }
        public static bool IsStringType(this Type t) {
            return Const.AtomicTypes.ContainsKey(t.Name) && t.Name.Equals(Const.String);
        }
    }
}