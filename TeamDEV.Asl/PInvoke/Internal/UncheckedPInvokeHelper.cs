using System;
using System.Text;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Modules;

namespace TeamDEV.Asl.PInvoke.Internal {
    static partial class UncheckedPInvokeHelper {
        public static ProcessAccess GetLimitedQueryAccess() {
            return Environment.OSVersion.Version.Major >= 6 ? ProcessAccess.QueryLimitedInformation : ProcessAccess.QueryInformation;
        }
        public static bool NtClose(IntPtr hObject) {
            return Ntdll.PInvoke_NtClose(hObject).IsSuccess();
        }
        public static bool NtCloseIfTrue(IntPtr hObject, bool statement) {
            return statement ? NtClose(hObject) : statement;
        }

        public static string GetWindowsDirectory() {
            StringBuilder sbDirectory = new StringBuilder(0x100);
            int charsCopied = Kernel32.PInvoke_GetWindowsDirectory(sbDirectory, sbDirectory.Capacity);
            if (charsCopied <= 0) return Const.UnknownString;
            return sbDirectory.ToString();
        }
        public static string GetSystemDirectory() {
            StringBuilder sbDirectory = new StringBuilder(0x100);
            int charsCopied = Kernel32.PInvoke_GetSystemDirectory(sbDirectory, sbDirectory.Capacity);
            if (charsCopied <= 0) return Const.UnknownString;
            return sbDirectory.ToString();
        }
    }
}