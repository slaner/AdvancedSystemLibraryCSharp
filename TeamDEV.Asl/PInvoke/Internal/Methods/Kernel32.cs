using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using TeamDEV.Asl.PInvoke.Internal.Enumerations;
using TeamDEV.Asl.PInvoke.Internals.Enumerations;
using TeamDEV.Asl.PInvoke.Internals.Structures;

namespace TeamDEV.Asl.PInvoke.Internals.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class Kernel32 {
        /// <summary>
        /// 
        /// </summary>
        public const string ModuleName = nameof(Kernel32);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "OutputDebugString")]
        internal static extern void PInvoke_OutputDebugString(string lpOutputString);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FormatMessage")]
        internal static extern int PInvoke_FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, string[] Arguments);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetSystemDirectory")]
        internal static extern int PInvoke_GetSystemDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetWindowsDirectory")]
        internal static extern int PInvoke_GetWindowsDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "QueryDosDevice")]
        internal static extern int PInvoke_QueryDosDevice(string lpDeviceName, string lpTargetPath, int ucchMax);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "QueryFullProcessImageName")]
        internal static extern int PInvoke_QueryFullProcessImageName(IntPtr hProcess, int dwFlags, StringBuilder lpExeName, ref int lpdwSize);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "DebugActiveProcess")]
        internal static extern int PInvoke_DebugActiveProcess(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "DebugActiveProcessStop")]
        internal static extern int PInvoke_DebugActiveProcessStop(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "IsWow64Process")]
        internal static extern int PInvoke_IsWow64Process(IntPtr hProcess, out bool bIs64BitProcess);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "TerminateProcess")]
        internal static extern int PInvoke_TerminateProcess(IntPtr hProcess, int dwExitCode);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "OpenProcess")]
        internal static extern IntPtr PInvoke_OpenProcess(ProcessAccess dwAccess, bool bInherit, int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateToolhelp32Snapshot")]
        internal static extern IntPtr PInvoke_CreateToolhelp32Snapshot(SnapshotFlags dwFlags, int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Process32First")]
        internal static extern bool PInvoke_Process32First(IntPtr hSnapshot, ref ProcessEntry32 pe32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Process32Next")]
        internal static extern bool PInvoke_Process32Next(IntPtr hSnapshot, ref ProcessEntry32 pe32);



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualAllocEx")]
        internal static extern IntPtr PInvoke_VirtualAllocEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flAllocationType, MemoryProtections flProtect);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualFreeEx")]
        internal static extern int PInvoke_VirtualFreeEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flFreeType);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualProtectEx")]
        internal static extern int PInvoke_VirtualProtectEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryProtections flNewProtect, out MemoryProtections lpflOldProtect);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "ReadProcessMemory")]
        internal static extern int PInvoke_ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nReadBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "WriteProcessMemory")]
        internal static extern int PInvoke_WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nWrittenBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateProcess")]
        internal static extern int PInvoke_CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, IntPtr lpStartupInfo, IntPtr lpProcessInformation);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Module32First")]
        internal static extern int PInvoke_Module32First(IntPtr hSnapshot, ref ModuleEntry32 me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Module32Next")]
        internal static extern int PInvoke_Module32Next(IntPtr hSnapshot, ref ModuleEntry32 me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateRemoteThread")]
        internal static extern IntPtr PInvoke_CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, int dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, int dwCreationFlags, IntPtr lpThreadId);
        


        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "AttachConsole")]
        internal static extern int PInvoke_AttachConsole(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FreeConsole")]
        internal static extern int PInvoke_FreeConsole();



        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FreeLibrary")]
        internal static extern bool PInvoke_FreeLibrary(IntPtr hLibModule);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "LoadLibrary")]
        internal static extern IntPtr PInvoke_LoadLibrary(string lpFileName);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetProcAddress")]
        internal static extern IntPtr PInvoke_GetProcAddress(IntPtr hModule, string lpProcedureName);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetModuleHandle")]
        internal static extern IntPtr PInvoke_GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "WaitForSingleObject")]
        internal static extern WaitResult PInvoke_WaitForSingleObject(IntPtr hObject, int dwMilliseconds);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CloseHandle")]
        internal static extern bool PInvoke_CloseHandle(IntPtr hObject);


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hModule"></param>
        /// <param name="lpProcedureName"></param>
        /// <returns></returns>
        public static IntPtr GetProcAddress(IntPtr hModule, string lpProcedureName, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetProcAddress(hModule, lpProcedureName);

            IntPtr returnValue = PInvoke_GetProcAddress(hModule, lpProcedureName);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                PInvokeDebugger.TraceFilters,
                ModuleName,
                nameof(GetProcAddress),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(hModule), hModule,
                nameof(lpProcedureName), lpProcedureName
            );

            PInvokeDebugger.SafeTrace(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        public static IntPtr LoadLibrary(string lpFileName, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_LoadLibrary(lpFileName);

            IntPtr returnValue = PInvoke_LoadLibrary(lpFileName);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                PInvokeDebugger.TraceFilters,
                ModuleName,
                nameof(LoadLibrary),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(lpFileName), lpFileName
            );

            PInvokeDebugger.SafeTrace(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hLibModule"></param>
        /// <returns></returns>
        public static bool FreeLibrary(IntPtr hLibModule, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_FreeLibrary(hLibModule);

            bool returnValue = PInvoke_FreeLibrary(hLibModule);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                PInvokeDebugger.TraceFilters,
                ModuleName,
                nameof(FreeLibrary),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(hLibModule), hLibModule
            );

            PInvokeDebugger.SafeTrace(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpModuleName"></param>
        /// <returns></returns>
        public static IntPtr GetModuleHandle(string lpModuleName, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetModuleHandle(lpModuleName);

            IntPtr returnValue = PInvoke_GetModuleHandle(lpModuleName);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                PInvokeDebugger.TraceFilters,
                ModuleName,
                nameof(GetModuleHandle),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(lpModuleName), lpModuleName
            );

            PInvokeDebugger.SafeTrace(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hObject"></param>
        /// <param name="dwMilliseconds"></param>
        /// <returns></returns>
        public static WaitResult WaitForSingleObject(IntPtr hObject, int dwMilliseconds, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_WaitForSingleObject(hObject, dwMilliseconds);

            WaitResult returnValue = PInvoke_WaitForSingleObject(hObject, dwMilliseconds);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                PInvokeDebugger.TraceFilters,
                ModuleName,
                nameof(WaitForSingleObject),
                callerName,
                returnValue,
                WaitResult.Failed,
                nameof(hObject), hObject,
                nameof(dwMilliseconds), dwMilliseconds
            );

            PInvokeDebugger.SafeTrace(debugInfo);
            return returnValue;
        }
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
                ModuleName,
                nameof(CloseHandle),
                callerName,
                returnValue,
                true,
                nameof(hObject), hObject
            );

            PInvokeDebugger.SafeTrace(debugInfo);
            return returnValue;
        }
    }
}