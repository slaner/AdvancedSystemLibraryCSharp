using System.Collections.Generic;

namespace TeamDEV.Asl.PInvoke {
    static class SR {
        static readonly Dictionary<string, string> resourceString = new Dictionary<string, string>();
        public static string GetString(string resName) {
            if (resourceString.ContainsKey(resName))
                return resourceString[resName];

            return null;
        }
    }
}