using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke.Structures;
using TeamDEV.Asl.Types;

namespace TeamDEV.Asl.PInvoke.Modules {
    static class Shell32 {
        /// <summary>
        /// 
        /// </summary>
        public const string ModuleName = nameof(Shell32);

        [DllImport("shell32", CharSet = CharSet.Auto, EntryPoint = "SHGetFileInfo")]
        internal static extern OSUInt PInvoke_SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFileInfo psfi, int cbFileInfo, int uFlags);
    }
}