using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using TeamDEV.Asl.PInvoke.Internal.Enumerations;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.PInvoke.Internal.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class Kernel32 {
        /// <summary>
        /// 
        /// </summary>
        public const string ModuleName = nameof(Kernel32);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FormatMessage")]
        public static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, string[] Arguments);
        
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "OutputDebugString")]
        internal static extern void PInvoke_OutputDebugString(string lpOutputString);
        
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetSystemDirectory")]
        internal static extern int PInvoke_GetSystemDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetWindowsDirectory")]
        internal static extern int PInvoke_GetWindowsDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "QueryDosDevice")]
        internal static extern int PInvoke_QueryDosDevice(string lpDeviceName, string lpTargetPath, int ucchMax);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "QueryFullProcessImageName")]
        internal static extern int PInvoke_QueryFullProcessImageName(IntPtr hProcess, int dwFlags, StringBuilder lpExeName, ref int lpdwSize);
        
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "DebugActiveProcess")]
        internal static extern bool PInvoke_DebugActiveProcess(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "DebugActiveProcessStop")]
        internal static extern bool PInvoke_DebugActiveProcessStop(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "IsWow64Process")]
        internal static extern bool PInvoke_IsWow64Process(IntPtr hProcess, out bool bIs64WowProcess);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "TerminateProcess")]
        internal static extern bool PInvoke_TerminateProcess(IntPtr hProcess, int dwExitCode);
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
        internal static extern bool PInvoke_VirtualFreeEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flFreeType);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "VirtualProtectEx")]
        internal static extern bool PInvoke_VirtualProtectEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryProtections flNewProtect, out MemoryProtections lpflOldProtect);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "ReadProcessMemory")]
        internal static extern bool PInvoke_ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nReadBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "WriteProcessMemory")]
        internal static extern bool PInvoke_WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nWrittenBytes);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateProcess")]
        internal static extern bool PInvoke_CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, IntPtr lpStartupInfo, IntPtr lpProcessInformation);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Module32First")]
        internal static extern bool PInvoke_Module32First(IntPtr hSnapshot, ref ModuleEntry32 me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "Module32Next")]
        internal static extern bool PInvoke_Module32Next(IntPtr hSnapshot, ref ModuleEntry32 me32);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateRemoteThread")]
        internal static extern IntPtr PInvoke_CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, int dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, int dwCreationFlags, IntPtr lpThreadId);
        
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "AllocConsole")]
        internal static extern bool PInvoke_AllocConsole();
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "AttachConsole")]
        internal static extern bool PInvoke_AttachConsole(int dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "FreeConsole")]
        internal static extern bool PInvoke_FreeConsole();
        
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
        /// <param name="lpOutputString"></param>
        public static void OutputDebugString(string lpOutputString, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled) {
                PInvoke_OutputDebugString(lpOutputString);
                return;
            }

            PInvoke_OutputDebugString(lpOutputString);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(GetSystemDirectory),
                callerName,
                null,
                null,
                nameof(lpOutputString), lpOutputString
            );

            PInvokeDebugger.SafeCapture(debugInfo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpBuffer"></param>
        /// <param name="uSize"></param>
        /// <returns></returns>
        public static int GetSystemDirectory(StringBuilder lpBuffer, int uSize, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetSystemDirectory(lpBuffer, uSize);

            int returnValue = PInvoke_GetSystemDirectory(lpBuffer, uSize);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(GetSystemDirectory),
                callerName,
                returnValue,
                0,
                nameof(lpBuffer), lpBuffer,
                nameof(uSize), uSize
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpBuffer"></param>
        /// <param name="uSize"></param>
        /// <returns></returns>
        public static int GetWindowsDirectory(StringBuilder lpBuffer, int uSize, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetWindowsDirectory(lpBuffer, uSize);

            int returnValue = PInvoke_GetWindowsDirectory(lpBuffer, uSize);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(GetWindowsDirectory),
                callerName,
                returnValue,
                0,
                nameof(lpBuffer), lpBuffer,
                nameof(uSize), uSize
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpDeviceName"></param>
        /// <param name="lpTargetPath"></param>
        /// <param name="ucchMax"></param>
        /// <returns></returns>
        public static int QueryDosDevice(string lpDeviceName, string lpTargetPath, int ucchMax, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_QueryDosDevice(lpDeviceName, lpTargetPath, ucchMax);

            int returnValue = PInvoke_QueryDosDevice(lpDeviceName, lpTargetPath, ucchMax);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(QueryDosDevice),
                callerName,
                returnValue,
                0,
                nameof(lpDeviceName), lpDeviceName,
                nameof(lpTargetPath), lpTargetPath,
                nameof(ucchMax), ucchMax
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="dwFlags"></param>
        /// <param name="lpExeName"></param>
        /// <param name="lpdwSize"></param>
        /// <returns></returns>
        public static int QueryFullProcessImageName(IntPtr hProcess, int dwFlags, StringBuilder lpExeName, ref int lpdwSize, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_QueryFullProcessImageName(hProcess, dwFlags, lpExeName, ref lpdwSize);

            int returnValue = PInvoke_QueryFullProcessImageName(hProcess, dwFlags, lpExeName, ref lpdwSize);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(QueryFullProcessImageName),
                callerName,
                returnValue,
                0,
                nameof(hProcess), hProcess,
                nameof(dwFlags), dwFlags,
                nameof(lpExeName), lpExeName,
                nameof(lpdwSize), lpdwSize
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        public static IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, int dwProcessId, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_CreateToolhelp32Snapshot(dwFlags, dwProcessId);

            IntPtr returnValue = PInvoke_CreateToolhelp32Snapshot(dwFlags, dwProcessId);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(CreateToolhelp32Snapshot),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(dwFlags), dwFlags,
                nameof(dwProcessId), dwProcessId
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwAccess"></param>
        /// <param name="bInherit"></param>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        public static IntPtr OpenProcess(ProcessAccess dwAccess, bool bInherit, int dwProcessId, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_OpenProcess(dwAccess, bInherit, dwProcessId);

            IntPtr returnValue = PInvoke_OpenProcess(dwAccess, bInherit, dwProcessId);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(OpenProcess),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(dwAccess), dwAccess,
                nameof(bInherit), bInherit,
                nameof(dwProcessId), dwProcessId
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="bIs64WowProcess"></param>
        /// <returns></returns>
        public static bool IsWow64Process(IntPtr hProcess, out bool bIs64WowProcess, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_IsWow64Process(hProcess, out bIs64WowProcess);

            bool returnValue = PInvoke_IsWow64Process(hProcess, out bIs64WowProcess);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(IsWow64Process),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess,
                nameof(bIs64WowProcess), bIs64WowProcess
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="dwExitCode"></param>
        /// <returns></returns>
        public static bool TerminateProcess(IntPtr hProcess, int dwExitCode, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_TerminateProcess(hProcess, dwExitCode);

            bool returnValue = PInvoke_TerminateProcess(hProcess, dwExitCode);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(TerminateProcess),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess,
                nameof(dwExitCode), dwExitCode
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        public static bool DebugActiveProcess(int dwProcessId, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_DebugActiveProcess(dwProcessId);

            bool returnValue = PInvoke_DebugActiveProcess(dwProcessId);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(DebugActiveProcess),
                callerName,
                returnValue,
                false,
                nameof(dwProcessId), dwProcessId
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        public static bool DebugActiveProcessStop(int dwProcessId, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_DebugActiveProcessStop(dwProcessId);

            bool returnValue = PInvoke_DebugActiveProcessStop(dwProcessId);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(DebugActiveProcessStop),
                callerName,
                returnValue,
                false,
                nameof(dwProcessId), dwProcessId
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSnapshot"></param>
        /// <param name="pe32"></param>
        /// <returns></returns>
        public static bool Process32First(IntPtr hSnapshot, ref ProcessEntry32 pe32, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_Process32First(hSnapshot, ref pe32);

            bool returnValue = PInvoke_Process32First(hSnapshot, ref pe32);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(Process32First),
                callerName,
                returnValue,
                false,
                nameof(hSnapshot), hSnapshot,
                nameof(pe32), pe32
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSnapshot"></param>
        /// <param name="pe32"></param>
        /// <returns></returns>
        public static bool Process32Next(IntPtr hSnapshot, ref ProcessEntry32 pe32, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_Process32Next(hSnapshot, ref pe32);

            bool returnValue = PInvoke_Process32Next(hSnapshot, ref pe32);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(Process32Next),
                callerName,
                returnValue,
                false,
                nameof(hSnapshot), hSnapshot,
                nameof(pe32), pe32
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="dwSize"></param>
        /// <param name="flAllocationType"></param>
        /// <param name="flProtect"></param>
        /// <returns></returns>
        public static IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flAllocationType, MemoryProtections flProtect, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_VirtualAllocEx(hProcess, lpBaseAddress, dwSize, flAllocationType, flProtect);

            IntPtr returnValue = PInvoke_VirtualAllocEx(hProcess, lpBaseAddress, dwSize, flAllocationType, flProtect);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(VirtualAllocEx),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(hProcess), hProcess,
                nameof(lpBaseAddress), lpBaseAddress,
                nameof(dwSize), dwSize,
                nameof(flAllocationType), flAllocationType,
                nameof(flProtect), flProtect
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="dwSize"></param>
        /// <param name="flFreeType"></param>
        /// <returns></returns>
        public static bool VirtualFreeEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryAllocationTypes flFreeType, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_VirtualFreeEx(hProcess, lpBaseAddress, dwSize, flFreeType);

            bool returnValue = PInvoke_VirtualFreeEx(hProcess, lpBaseAddress, dwSize, flFreeType);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(VirtualFreeEx),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess,
                nameof(lpBaseAddress), lpBaseAddress,
                nameof(dwSize), dwSize,
                nameof(flFreeType), flFreeType
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="dwSize"></param>
        /// <param name="flNewProtect"></param>
        /// <param name="lpflOldProtect"></param>
        /// <returns></returns>
        public static bool VirtualProtectEx(IntPtr hProcess, IntPtr lpBaseAddress, int dwSize, MemoryProtections flNewProtect, out MemoryProtections lpflOldProtect, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_VirtualProtectEx(hProcess, lpBaseAddress, dwSize, flNewProtect, out lpflOldProtect);

            bool returnValue = PInvoke_VirtualProtectEx(hProcess, lpBaseAddress, dwSize, flNewProtect, out lpflOldProtect);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(VirtualProtectEx),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess,
                nameof(lpBaseAddress), lpBaseAddress,
                nameof(dwSize), dwSize,
                nameof(flNewProtect), flNewProtect,
                nameof(lpflOldProtect), lpflOldProtect
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="dwSize"></param>
        /// <param name="nReadBytes"></param>
        /// <returns></returns>
        public static bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nReadBytes, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, dwSize, out nReadBytes);

            bool returnValue = PInvoke_ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, dwSize, out nReadBytes);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(ReadProcessMemory),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess,
                nameof(lpBaseAddress), lpBaseAddress,
                nameof(lpBuffer), lpBuffer,
                nameof(dwSize), dwSize,
                nameof(nReadBytes), nReadBytes
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="dwSize"></param>
        /// <param name="nWrittenBytes"></param>
        /// <returns></returns>
        public static bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int nWrittenBytes, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_WriteProcessMemory(hProcess, lpBaseAddress, lpBuffer, dwSize, out nWrittenBytes);

            bool returnValue = PInvoke_ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, dwSize, out nWrittenBytes);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(WriteProcessMemory),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess,
                nameof(lpBaseAddress), lpBaseAddress,
                nameof(lpBuffer), lpBuffer,
                nameof(dwSize), dwSize,
                nameof(nWrittenBytes), nWrittenBytes
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpApplicationName"></param>
        /// <param name="lpCommandLine"></param>
        /// <param name="lpProcessAttributes"></param>
        /// <param name="lpThreadAttributes"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="dwCreationFlags"></param>
        /// <param name="lpEnvironment"></param>
        /// <param name="lpCurrentDirectory"></param>
        /// <param name="lpStartupInfo"></param>
        /// <param name="lpProcessInformation"></param>
        /// <returns></returns>
        public static bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, IntPtr lpStartupInfo, IntPtr lpProcessInformation, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_CreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandle, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation);

            bool returnValue = PInvoke_CreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandle, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(CreateProcess),
                callerName,
                returnValue,
                false,
                nameof(lpApplicationName), lpApplicationName,
                nameof(lpCommandLine), lpCommandLine,
                nameof(lpProcessAttributes), lpProcessAttributes,
                nameof(lpThreadAttributes), lpThreadAttributes,
                nameof(bInheritHandle), bInheritHandle,
                nameof(dwCreationFlags), dwCreationFlags,
                nameof(lpEnvironment), lpEnvironment,
                nameof(lpCurrentDirectory), lpCurrentDirectory,
                nameof(lpStartupInfo), lpStartupInfo,
                nameof(lpProcessInformation), lpProcessInformation
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSnapshot"></param>
        /// <param name="me32"></param>
        /// <returns></returns>
        public static bool Module32First(IntPtr hSnapshot, ref ModuleEntry32 me32, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_Module32First(hSnapshot, ref me32);

            bool returnValue = PInvoke_Module32First(hSnapshot, ref me32);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(Module32First),
                callerName,
                returnValue,
                false,
                nameof(hSnapshot), hSnapshot,
                nameof(me32), me32
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSnapshot"></param>
        /// <param name="me32"></param>
        /// <returns></returns>
        public static bool Module32Next(IntPtr hSnapshot, ref ModuleEntry32 me32, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_Module32Next(hSnapshot, ref me32);

            bool returnValue = PInvoke_Module32Next(hSnapshot, ref me32);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(Module32Next),
                callerName,
                returnValue,
                false,
                nameof(hSnapshot), hSnapshot,
                nameof(me32), me32
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpThreadAttributes"></param>
        /// <param name="dwStackSize"></param>
        /// <param name="lpStartAddress"></param>
        /// <param name="lpParameter"></param>
        /// <param name="dwCreationFlags"></param>
        /// <param name="lpThreadId"></param>
        /// <returns></returns>
        public static IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, int dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, int dwCreationFlags, IntPtr lpThreadId, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_CreateRemoteThread(hProcess, lpThreadAttributes, dwStackSize, lpStartAddress, lpParameter, dwCreationFlags, lpThreadId);

            IntPtr returnValue = PInvoke_CreateRemoteThread(hProcess, lpThreadAttributes, dwStackSize, lpStartAddress, lpParameter, dwCreationFlags, lpThreadId);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(CreateRemoteThread),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(hProcess), hProcess,
                nameof(lpThreadAttributes), lpThreadAttributes,
                nameof(dwStackSize), dwStackSize,
                nameof(lpStartAddress), lpStartAddress,
                nameof(lpParameter), lpParameter,
                nameof(dwCreationFlags), dwCreationFlags,
                nameof(lpThreadId), lpThreadId
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool AllocConsole([CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_AllocConsole();

            bool returnValue = PInvoke_AllocConsole();
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(AllocConsole),
                callerName,
                returnValue,
                false
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        public static bool AttachConsole(int dwProcessId, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_AttachConsole(dwProcessId);

            bool returnValue = PInvoke_AttachConsole(dwProcessId);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(AttachConsole),
                callerName,
                returnValue,
                false,
                nameof(dwProcessId), dwProcessId
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool FreeConsole([CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_FreeConsole();

            bool returnValue = PInvoke_FreeConsole();
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(FreeConsole),
                callerName,
                returnValue,
                false
            );

            PInvokeDebugger.SafeCapture(debugInfo);
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
                ModuleName,
                nameof(LoadLibrary),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(lpFileName), lpFileName
            );

            PInvokeDebugger.SafeCapture(debugInfo);
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
                ModuleName,
                nameof(FreeLibrary),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(hLibModule), hLibModule
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
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
                ModuleName,
                nameof(GetProcAddress),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(hModule), hModule,
                nameof(lpProcedureName), lpProcedureName
            );

            PInvokeDebugger.SafeCapture(debugInfo);
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
                ModuleName,
                nameof(GetModuleHandle),
                callerName,
                returnValue,
                IntPtr.Zero,
                nameof(lpModuleName), lpModuleName
            );

            PInvokeDebugger.SafeCapture(debugInfo);
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
                ModuleName,
                nameof(WaitForSingleObject),
                callerName,
                returnValue,
                WaitResult.Failed,
                nameof(hObject), hObject,
                nameof(dwMilliseconds), dwMilliseconds
            );

            PInvokeDebugger.SafeCapture(debugInfo);
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
                ModuleName,
                nameof(CloseHandle),
                callerName,
                returnValue,
                true,
                nameof(hObject), hObject
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
    }
}