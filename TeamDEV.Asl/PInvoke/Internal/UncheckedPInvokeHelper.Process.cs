using System;
using System.Runtime.InteropServices;
using TeamDEV.Asl.Extensions;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Internal.Methods;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.PInvoke.Internal {
    static partial class UncheckedPInvokeHelper {
        public static partial class Process {
            public static IntPtr OpenProcess(ProcessAccess access, bool inherit, int pid) {
                return Kernel32.PInvoke_OpenProcess(access, inherit, pid);
            }
            public static IntPtr OpenProcessNative(ProcessAccess access, bool inherit, int pid) {
                IntPtr hProcess = IntPtr.Zero;
                ObjectAttributes objectAttributes = default(ObjectAttributes);
                objectAttributes.Length = (uint) ObjectAttributes.Size;
                ClientId clientId = default(ClientId);
                clientId.UniqueProcess = new IntPtr(pid);

                NTSTATUS result = Ntdll.PInvoke_NtOpenProcess(ref hProcess, access, ref objectAttributes, ref clientId);
                if (result.IsSuccess())
                    return hProcess;
                return IntPtr.Zero;
            }
            public static bool TerminateProcess(int id, int exitCode) {
                IntPtr hProcess = OpenProcess(ProcessAccess.Terminate, false, id);
                if (hProcess.IsZero()) return false;

                bool result = Kernel32.PInvoke_TerminateProcess(hProcess, exitCode);
                Kernel32.PInvoke_CloseHandle(hProcess);
                return result;
            }
            public static bool TerminateProcessNative(int id, NTSTATUS exitStatus) {
                IntPtr hProcess = OpenProcess(ProcessAccess.Terminate, false, id);
                if (hProcess == IntPtr.Zero) return false;

                NTSTATUS result = Ntdll.PInvoke_NtTerminateProcess(hProcess, exitStatus);
                Ntdll.PInvoke_NtClose(hProcess);
                return result.IsSuccess();
            }

            public static bool GetProcessExtendedBasicInformation(int id, out ProcessExtendedBasicInformation extendedBasicInformation) {
                IntPtr hProcess = OpenProcessNative(GetLimitedQueryAccess(), false, id);
                return GetProcessExtendedBasicInformation(hProcess, out extendedBasicInformation, true);
            }
            public static bool GetProcessExtendedBasicInformation(IntPtr hProcess, out ProcessExtendedBasicInformation extendedBasicInformation, bool closeHandle = false) {
                extendedBasicInformation = default(ProcessExtendedBasicInformation);
                extendedBasicInformation.dwSize = ProcessExtendedBasicInformation.Size;
                
                if (hProcess.IsZero()) return false;

                IntPtr pInformation = Marshal.AllocHGlobal(ProcessExtendedBasicInformation.Size);
                if (pInformation.IsZero()) {
                    NtCloseIfTrue(hProcess, closeHandle);
                    return false;
                }

                NTSTATUS status = Ntdll.PInvoke_NtQueryInformationProcess(hProcess, ProcessInformationClass.ProcessBasicInformation, pInformation, (uint) ProcessExtendedBasicInformation.Size, out uint returnLength);
                if (!status.IsSuccess()) {
                    NtCloseIfTrue(hProcess, closeHandle);
                    pInformation.FreeHGlobal();
                    return false;
                }

                extendedBasicInformation = pInformation.To<ProcessExtendedBasicInformation>();
                pInformation.FreeHGlobal();
                return true;
            }
        }
    }
}