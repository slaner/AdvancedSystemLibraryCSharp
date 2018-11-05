using System;

using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Internal.Methods;

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
    }
}