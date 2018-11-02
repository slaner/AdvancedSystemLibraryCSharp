using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.PInvoke.Internal.Methods {
    class PsApi {
        public const string ModuleName = nameof(PsApi);

        [DllImport("psapi")]
        internal static extern bool PInvoke_EmptyWorkingSet(IntPtr hProcess);
        [DllImport("psapi", CharSet = CharSet.Auto, EntryPoint = "GetProcessImageFileName")]
        internal static extern int PInvoke_GetProcessImageFileName(IntPtr hProcess, StringBuilder lpImageFileName, int nSize);
        [DllImport("psapi", CharSet = CharSet.Auto, EntryPoint = "GetModuleFileNameEx")]
        internal static extern int PInvoke_GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, StringBuilder lpModuleFileName, int nSize);

        public static bool EmptyWorkingSet(IntPtr hProcess, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_EmptyWorkingSet(hProcess);

            bool returnValue = PInvoke_EmptyWorkingSet(hProcess);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(EmptyWorkingSet),
                callerName,
                returnValue,
                false,
                nameof(hProcess), hProcess
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static int GetProcessImageFileName(IntPtr hProcess, StringBuilder lpImageFileName, int nSize, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetProcessImageFileName(hProcess, lpImageFileName, nSize);

            int returnValue = PInvoke_GetProcessImageFileName(hProcess, lpImageFileName, nSize);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(GetProcessImageFileName),
                callerName,
                returnValue,
                0,
                nameof(hProcess), hProcess,
                nameof(lpImageFileName), lpImageFileName,
                nameof(nSize), nSize
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static int GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, StringBuilder lpModuleFileName, int nSize, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetModuleFileNameEx(hProcess, hModule, lpModuleFileName, nSize);

            int returnValue = PInvoke_GetModuleFileNameEx(hProcess, hModule, lpModuleFileName, nSize);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(EmptyWorkingSet),
                callerName,
                0,
                false,
                nameof(hProcess), hProcess,
                nameof(hModule), hModule,
                nameof(lpModuleFileName), lpModuleFileName,
                nameof(nSize), nSize
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
    }
}
