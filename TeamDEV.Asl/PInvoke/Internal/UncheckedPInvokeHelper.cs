using System;

using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Internal.Methods;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.PInvoke.Internal {
    static class UncheckedPInvokeHelper {
        public static IntPtr OpenProcess(ProcessAccess access, bool inherit, int pid) {
            return Kernel32.PInvoke_OpenProcess(access, inherit, pid);
        }
        public static IntPtr OpenProcessNative(ProcessAccess access, bool inherit, int pid) {
            IntPtr hProcess = IntPtr.Zero;
            ObjectAttributes objectAttributes = default(ObjectAttributes);
            objectAttributes.Attributes = inherit ? ObjectAttributesFlags.Inherit : 0;
            objectAttributes.Length = (uint) ObjectAttributes.Size;
            ClientId clientId = default(ClientId);
            clientId.UniqueProcess = new IntPtr(pid);

            NTSTATUS result = Ntdll.PInvoke_NtOpenProcess(ref hProcess, access, ref objectAttributes, ref clientId);
            if (result.IsSuccess())
                return hProcess;
            return IntPtr.Zero;
        }

        public static bool TerminateProcess(IntPtr processHandle, int exitCode) {
            return Kernel32.PInvoke_TerminateProcess(processHandle, exitCode);
        }
        public static bool TerminateProcessNative(IntPtr processHandle, NTSTATUS exitStatus) {
            return Ntdll.PInvoke_NtTerminateProcess(processHandle, exitStatus).IsSuccess();
        }
    }
}