using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

using TeamDEV.Asl.Internals.Native.Enumerations;
using TeamDEV.Asl.Internals.Native.Structures;

namespace TeamDEV.Asl.Internals.Native.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class Kernel32 {
        /// <summary>
        /// 
        /// </summary>
        private const string ClassName = nameof(Kernel32);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "OutputDebugString")]
        private static extern void PInvoke_OutputDebugString(string lpOutputString);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FormatMessage")]
        private static extern int PInvoke_FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr Arguments);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetSystemDirectory")]
        private static extern int PInvoke_GetSystemDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetWindowsDirectory")]
        private static extern int PInvoke_GetWindowsDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "QueryDosDevice")]
        private static extern int PInvoke_QueryDosDevice(string lpDeviceName, string lpTargetPath, int ucchMax);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "QueryFullProcessImageName")]
        private static extern int PInvoke_QueryFullProcessImageName(IntPtr hProcess, int dwFlags, StringBuilder lpExeName, ref int lpdwSize);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "DebugActiveProcess")]
        private static extern int PInvoke_DebugActiveProcess(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "DebugActiveProcessStop")]
        private static extern int PInvoke_DebugActiveProcessStop(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "IsWow64Process")]
        private static extern int PInvoke_IsWow64Process(IntPtr hProcess, out bool bIs64BitProcess);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "TerminateProcess")]
        private static extern int PInvoke_TerminateProcess(IntPtr hProcess, int dwExitCode);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "OpenProcess")]
        private static extern IntPtr PInvoke_OpenProcess(ProcessAccess dwAccess, bool bInherit, int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateToolhelp32Snapshot")]
        private static extern IntPtr PInvoke_CreateToolhelp32Snapshot(SnapshotFlags dwFlags, int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Process32First")]
        private static extern bool PInvoke_Process32First(IntPtr hSnapshot, ref ProcessEntry32 pe32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Process32Next")]
        private static extern bool PInvoke_Process32Next(IntPtr hSnapshot, ref ProcessEntry32 pe32);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualAllocEx")]
        private static extern IntPtr PInvoke_VirtualAllocEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flAllocationType, MemoryProtections flProtect);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualFreeEx")]
        private static extern int PInvoke_VirtualFreeEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flFreeType);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualProtectEx")]
        private static extern int PInvoke_VirtualProtectEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryProtections flNewProtect, out MemoryProtections lpflOldProtect);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "ReadProcessMemory")]
        private static extern int PInvoke_ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nReadBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "WriteProcessMemory")]
        private static extern int PInvoke_WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nWrittenBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateProcess")]
        private static extern int PInvoke_CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, IntPtr lpStartupInfo, IntPtr lpProcessInformation);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Module32First")]
        private static extern int PInvoke_Module32First(IntPtr hSnapshot, ref ModuleEntry32 me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Module32Next")]
        private static extern int PInvoke_Module32Next(IntPtr hSnapshot, ref ModuleEntry32 me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateRemoteThread")]
        private static extern IntPtr PInvoke_CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, int dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, int dwCreationFlags, IntPtr lpThreadId);
        


        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "AttachConsole")]
        private static extern int PInvoke_AttachConsole(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FreeConsole")]
        private static extern int PInvoke_FreeConsole();



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FreeLibrary")]
        private static extern int PInvoke_FreeLibrary(IntPtr hLibrary);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "LoadLibrary")]
        private static extern IntPtr PInvoke_LoadLibrary(string lpFileName);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetProcAddress")]
        private static extern IntPtr PInvoke_GetProcAddress(IntPtr hModule, string lpProcedureName);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetModuleHandle")]
        private static extern IntPtr PInvoke_GetModuleHandle(string lpModuleName);
        


        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "WaitForSingleObject")]
        private static extern int PInvoke_WaitForSingleObject(IntPtr hObject, int dwMilliseconds);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CloseHandle")]
        private static extern bool PInvoke_CloseHandle(IntPtr hObject);







        /// <summary>
        /// 
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        public static bool CloseHandle(IntPtr hObject, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_CloseHandle(hObject);

            bool returnValue = PInvoke_CloseHandle(hObject);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                PInvokeDebugger.TraceFilters,
                ClassName,
                nameof(CloseHandle),
                callerName,
                returnValue,
                true,

            );
            if (!returnValue)
            {
                if (PInvokeDebugger.TraceFilters.HasFlag(TraceFilters.ErrorCode))
                Marshal.GetLastWin32Error();
            }
            PInvokeDebugInfo debugInfo = new PInvokeDebugInfo();

            if (PInvokeDebugger.TraceFilters.HasFlag(TraceFilters.PInvokeName))
                debugInfo.PInvokeName = nameof(PInvoke_CloseHandle).Substring(PInvokeDebugger.PInvokeCallPrefix.Length);

            if (PInvokeDebugger.TraceFilters.HasFlag(TraceFilters.ModuleName))
                debugInfo.ModuleName = nameof(Kernel32);

            if (PInvokeDebugger.TraceFilters.HasFlag(TraceFilters.CallerName))
                debugInfo.CallerName = callerName;

            if (PInvokeDebugger.TraceFilters.HasFlag(TraceFilters.Parameters)) {
                debugInfo.Parameters[nameof(hObject)] = hObject;
            }

            if (PInvokeDebugger.TraceFilters.HasFlag(TraceFilters.ReturnValue))
                debugInfo.ReturnValue = returnValue;
            
            return returnValue;
        }
    }
}