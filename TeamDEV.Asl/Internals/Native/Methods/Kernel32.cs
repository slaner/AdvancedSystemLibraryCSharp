using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.Internals.Native.Enumerations;
using TeamDEV.Asl.Internals.Native.Structures;

namespace TeamDEV.Asl.Internals.Native.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class Kernel32 {
        [DllImport("kernel32", CharSet = CharSet.Auto, BestFitMapping = true, EntryPoint = "OutputDebugString")]
        static extern void OutputDebugString(String text);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "QueryDosDevice")]
        static extern Int32 QueryDosDevice(String DeviceName, StringBuilder Target, Int32 Size);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "QueryFullProcessImageName")]
        static extern Int32 QueryFullProcessImageName(IntPtr ProcessHandle, Int32 Flags, IntPtr Name, ref Int32 Size);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "GetWindowsDirectory")]
        static extern Int32 GetWindowsDirectory(StringBuilder Buffer, ref Int32 BufferLength);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "GetSystemDirectory")]
        static extern Int32 GetSystemDirectory(StringBuilder Buffer, Int32 BufferLength);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "FormatMessage")]
        static extern Int32 FormatMessage(FormatMessageFlags Flags, IntPtr Source, UInt32 MessageId, Int32 LanguageId, StringBuilder Buffer, Int32 Size, IntPtr Arguments);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "FormatMessage")]
        static extern Int32 FormatMessage(FormatMessageFlags Flags, IntPtr Source, UInt32 MessageId, Int32 LanguageId, out String Buffer, Int32 Size, IntPtr Arguments);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "AttachConsole")]
        static extern Int32 AttachConsole(Int32 ProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "FreeConsole")]
        static extern Int32 FreeConsole();
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "VirtualAllocEx")]
        static extern IntPtr VirtualAllocEx(IntPtr ProcessHandle, IntPtr BaseAddress, Int32 Size, MemoryStates AllocType, MemoryProtections ProtectType);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "VirtualFreeEx")]
        static extern Int32 VirtualFreeEx(IntPtr ProcessHandle, IntPtr BaseAddress, Int32 Size, MemoryStates FreType);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "VirtualProtectEx")]
        static extern Int32 VirtualProtectEx(IntPtr ProcessHandle, IntPtr BaseAddress, Int32 Size, MemoryProtections NewProtection, out MemoryProtections OldProtection);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "ReadProcessMemory")]
        static extern Int32 ReadProcessMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, Int32 Size, out Int32 ReadBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "WriteProcessMemory")]
        static extern Int32 WriteProcessMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, Int32 Size, out Int32 WrittenBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "CreateProcess")]
        static extern Int32 CreateProcess(String ApplicationName, String CommandLine, IntPtr ProcessAttributes, IntPtr ThreadAttributes, Boolean InheritHandle, Int32 CreationFlags, IntPtr Environment, String CurrentDirectory, IntPtr StartupInfo, IntPtr ProcessInformation);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "GetLastError")]
        static extern Int32 GetLastError();
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "CreateRemoteThread")]
        static extern IntPtr CreateRemoteThread(IntPtr ProcessHandle, IntPtr ThreadAttributes, Int32 Size, IntPtr StartAddress, IntPtr Parameter, Int32 CreationFlags, IntPtr ThreadId);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "FreeLibrary")]
        static extern Int32 FreeLibrary(IntPtr Library);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "LoadLibrary")]
        static extern IntPtr LoadLibrary(String FileName);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "GetProcAddress")]
        static extern IntPtr GetProcAddress(IntPtr Module, String ProcedureName);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "GetModuleHandle")]
        static extern IntPtr GetModuleHandle(String ModuleName);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "Module32First")]
        static extern Int32 Module32First(IntPtr Snapshot, ref ModuleEntry32 Me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "Module32Next")]
        static extern Int32 Module32Next(IntPtr Snapshot, ref ModuleEntry32 Me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "WaitForSingleObject")]
        static extern Int32 WaitForSingleObject(IntPtr Object, Int32 Milliseconds);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "OpenProcess")]
        static extern IntPtr OpenProcess(ProcessAccess Access, Boolean Inherit, Int32 Id);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "CreateToolhelp32Snapshot")]
        static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags Flags, Int32 Id);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "Process32First")]
        static extern Boolean Process32First(IntPtr Snapshot, ref ProcessEntry32 Pe32);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "Process32Next")]
        static extern Boolean Process32Next(IntPtr Snapshot, ref ProcessEntry32 Pe32);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "CloseHandle")]
        static extern IntPtr CloseHandle(IntPtr Handle);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "DebugActiveProcess")]
        static extern Int32 DebugActiveProcess(Int32 Id);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "DebugActiveProcessStop")]
        static extern Int32 DebugActiveProcessStop(Int32 Id);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "IsWow64Process")]
        static extern Int32 IsWow64Process(IntPtr ProcessHandle, out Boolean Is64BitProcess);
        [DllImport("kernel32", CharSet = CharSet.Auto, EntryPoint = "TerminateProcess")]
        static extern Int32 TerminateProcess(IntPtr ProcessHandle, Int32 ExitCode);

    }
}