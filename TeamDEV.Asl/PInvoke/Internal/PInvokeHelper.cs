using System;
using System.Text;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Modules;

namespace TeamDEV.Asl.PInvoke.Internal {
    public static partial class PInvokeHelper {
        public static void Test() {
            int k = 1;
            CloseIf(IntPtr.Zero, () => { return k == 1; });
        }
        public static bool Close(IntPtr hObject) {
            NTSTATUS result = Ntdll.NtClose(hObject);
            return result.IsSuccess();
        }
        public static bool CloseIf(IntPtr hObject, bool condition) {
            if (condition) return Close(hObject);
            return false;
        }
        public static bool CloseIf(IntPtr hObject, Func<bool> condition) {
            if (condition == null) return false;
            return CloseIf(hObject, condition());
        }

        public static string GetWindowsDirectory() {
            StringBuilder sbDirectory = new StringBuilder(0x100);
            int charsCopied = Kernel32.GetWindowsDirectory(sbDirectory, sbDirectory.Capacity);
            if (charsCopied <= 0) return Const.Unknown;
            return sbDirectory.ToString();
        }
        public static string GetSystemDirectory() {
            StringBuilder sbDirectory = new StringBuilder(0x100);
            int charsCopied = Kernel32.GetSystemDirectory(sbDirectory, sbDirectory.Capacity);
            if (charsCopied <= 0) return Const.Unknown;
            return sbDirectory.ToString();
        }
    }
}
