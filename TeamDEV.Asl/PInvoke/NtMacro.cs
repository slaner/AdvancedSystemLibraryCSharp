using TeamDEV.Asl.PInvoke.Internals.Enumerations;

namespace TeamDEV.Asl.PInvoke {
    public static class NtMacro {
        public static bool IsSuccess(this NTSTATUS status) {
            return (status >= 0 && status <= (NTSTATUS) 0x3FFFFFFF) || IsInformation(status);
        }
        public static bool IsInformation(this NTSTATUS status) {
            return (status >= (NTSTATUS) 0x40000000 && status <= (NTSTATUS) 0x7FFFFFFF);
        }
        public static bool IsWarning(this NTSTATUS status) {
            return (status >= (NTSTATUS) 0x80000000 && status <= (NTSTATUS) 0xBFFFFFFF);
        }
        public static bool IsError(this NTSTATUS status) {
            return (status >= (NTSTATUS) 0xC0000000 && status <= (NTSTATUS) 0xFFFFFFFF);
        }
    }
}