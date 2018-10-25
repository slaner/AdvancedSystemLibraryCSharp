using System;
using System.Runtime.InteropServices;
using TeamDEV.Asl.PInvoke.Internals.Enumerations;
using TeamDEV.Asl.PInvoke.Internals.Structures;

namespace TeamDEV.Asl.PInvoke.Internals.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class Ntdll {
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtDuplicateObject")]
        static extern NTSTATUS ntDuplicateObject(IntPtr SourceProcessHandle, IntPtr SourceHandle, IntPtr TargetProcessHandle, ref IntPtr TargetHandle, AccessMask DesiredAccess, UInt32 Attributes, UInt32 Options);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtReadVirtualMemory")]
        static extern NTSTATUS ntReadVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, UInt32 BufferSize, out UInt32 BytesRead);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtWriteVirtualMemory")]
        static extern NTSTATUS ntWriteVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, UInt32 BufferSize, out UInt32 BytesWritten);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtProtectVirtualMemory")]
        static extern NTSTATUS ntProtectVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, UInt32 Length, MemoryProtections NewProtection, out MemoryProtections OldProtection);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryObject")]
        static extern NTSTATUS ntQueryObject(IntPtr ObjectHandle, ObjectInformationClass ObjectInformationClass, IntPtr Info, UInt32 InfoLength, out UInt32 ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtClose")]
        static extern NTSTATUS ntClose(IntPtr Handle);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQuerySymbolicLinkObject")]
        static extern NTSTATUS ntQuerySymbolicLinkObject(IntPtr LinkHandle, IntPtr LinkTarget, out UInt32 ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtOpenSymbolicLinkObject")]
        static extern NTSTATUS ntOpenSymbolicLinkObject(IntPtr LinkHandle, AccessMask Access, IntPtr ObjectAttributes);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtOpenProcess")]
        static extern NTSTATUS ntOpenProcess(ref IntPtr ProcessHandle, ProcessAccess Access, ref ObjectAttributes ObjectAttributes, ref ClientId Cid);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQuerySystemInformation")]
        static extern NTSTATUS ntQuerySystemInformation(SystemInformationClass InfoClass, IntPtr Info, UInt32 InfoLength, out UInt32 ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryInformationProcess")]
        static extern NTSTATUS ntQueryInformationProcess(IntPtr ProcessHandle, ProcessInformationClass InfoClass, out Boolean Info, UInt32 InfoLength, out UInt32 ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryInformationProcess")]
        static extern NTSTATUS ntQueryInformationProcess(IntPtr ProcessHandle, ProcessInformationClass InfoClass, IntPtr Info, UInt32 InfoLength, out UInt32 ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryInformationProcess")]
        static extern NTSTATUS ntQueryVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, MemoryInformationClass InfoClass, IntPtr Info, UInt32 InfoLength, out UInt32 ReturnLength);
    }
}