﻿using System;
using System.Runtime.InteropServices;
using TeamDEV.Asl.Extensions;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Modules;
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
                objectAttributes.Attributes = inherit ? ObjectAttributesFlags.Inherit : 0;
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

            public static bool GetProcessBasicInformation(int id, out ProcessBasicInformation basicInformation) {
                IntPtr hProcess = OpenProcessNative(ProcessAccess.QueryInformation, false, id);
                return GetProcessBasicInformation(hProcess, out basicInformation, true);
            }
            public static bool GetProcessBasicInformation(IntPtr hProcess, out ProcessBasicInformation basicInformation, bool closeHandle = false) {
                basicInformation = default(ProcessBasicInformation);
                if (!hProcess.IsValid()) return false;

                IntPtr pInformation = Marshal.AllocHGlobal(ProcessBasicInformation.Size);
                if (pInformation.IsZero()) {
                    NtCloseIfTrue(hProcess, closeHandle);
                    return false;
                }

                NTSTATUS status = Ntdll.PInvoke_NtQueryInformationProcess(hProcess, ProcessInformationClass.ProcessBasicInformation, pInformation, (uint) ProcessBasicInformation.Size, out uint returnLength);
                if (!status.IsSuccess()) {
                    NtCloseIfTrue(hProcess, closeHandle);
                    pInformation.FreeHGlobal();
                    return false;
                }

                basicInformation = pInformation.To<ProcessBasicInformation>();
                NtCloseIfTrue(hProcess, closeHandle);
                pInformation.FreeHGlobal();
                return true;
            }
            
            public static bool GetProcessExtendedBasicInformation(int id, out ProcessExtendedBasicInformation extendedBasicInformation) {
                IntPtr hProcess = OpenProcessNative(ProcessAccess.QueryInformation, false, id);
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
                NtCloseIfTrue(hProcess, closeHandle);
                pInformation.FreeHGlobal();
                return true;
            }

            public static bool GetProcessPEB(int id, out ProcessEnvironmentBlock peb) {
                IntPtr hProcess = OpenProcessNative(ProcessAccess.QueryInformation | ProcessAccess.VmRead, false, id);
                return GetProcessPEB(hProcess, out peb, true);
            }
            public static bool GetProcessPEB(IntPtr hProcess, out ProcessEnvironmentBlock peb, bool closeHandle = false) {
                peb = default(ProcessEnvironmentBlock);
                if (!hProcess.IsValid()) return false;
                
                if (!GetProcessBasicInformation(hProcess, out ProcessBasicInformation pbi)) {
                    NtCloseIfTrue(hProcess, closeHandle);
                    return false;
                }

                return GetProcessPEB(hProcess, pbi, out peb, closeHandle);
            }
            public static bool GetProcessPEB(IntPtr hProcess, ProcessBasicInformation pbi, out ProcessEnvironmentBlock peb, bool closeHandle = false) {
                peb = default(ProcessEnvironmentBlock);
                if (!hProcess.IsValid()) return false;

                if (!pbi.PebBaseAddress.IsValid()) {
                    NtCloseIfTrue(hProcess, closeHandle);
                    return false;
                }

                bool result = PtrToStructure(hProcess, pbi.PebBaseAddress, out peb);
                NtCloseIfTrue(hProcess, closeHandle);
                return result;
            }

            public static bool PtrToStructure<T>(IntPtr hProcess, IntPtr baseAddress, out T structure) where T: struct {
                structure = default(T);

                if (!hProcess.IsValid() || !baseAddress.IsValid()) return false;

                uint length = (uint) Marshal.SizeOf(typeof(T));
                if (ReadProcessVirtualMemoryFast(hProcess, baseAddress, ref length, out IntPtr pStruct)) {
                    structure = pStruct.To<T>();
                    pStruct.FreeHGlobal();
                    return true;
                }

                return false;
            }


            static Boolean ReadProcessVirtualMemoryFast(IntPtr hProcess, IntPtr baseAddress, ref UInt32 size, out IntPtr processMemory) {
                processMemory = Marshal.AllocHGlobal((Int32) size);
                UInt32 readBytes = 0;
                NTSTATUS status = 0;
                MemoryProtections oldProtect = 0;

                status = Ntdll.NtReadVirtualMemory(hProcess, baseAddress, processMemory, size, out readBytes);
                if (!status.IsSuccess()) {

                    status = Ntdll.NtProtectVirtualMemory(hProcess, baseAddress, size, MemoryProtections.ReadWrite, out oldProtect);
                    if (!status.IsSuccess()) {
                        Marshal.FreeHGlobal(processMemory);
                        return false;
                    }

                    status = Ntdll.NtReadVirtualMemory(hProcess, baseAddress, processMemory, size, out readBytes);
                    if (!status.IsSuccess()) {
                        Ntdll.NtProtectVirtualMemory(hProcess, baseAddress, size, oldProtect, out oldProtect);
                        Marshal.FreeHGlobal(processMemory);
                        return false;
                    }

                    Ntdll.NtProtectVirtualMemory(hProcess, baseAddress, size, oldProtect, out oldProtect);
                }

                size = readBytes;
                return true;
            }
        }
    }
}