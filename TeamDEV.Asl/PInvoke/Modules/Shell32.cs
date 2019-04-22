using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke.Structures;
using TeamDEV.Asl.Types;

namespace TeamDEV.Asl.PInvoke.Modules {
    static class Shell32 {
        /// <summary>
        /// 
        /// </summary>
        public const string ModuleName = nameof(Shell32);

        [DllImport("shell32", CharSet = CharSet.Auto, EntryPoint = "SHGetFileInfo")]
        internal static extern OSUInt PInvoke_SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFileInfo psfi, int cbFileInfo, int uFlags);

        [DllImport("shell32", CharSet = CharSet.Auto, EntryPoint = "ShellExecute")]
        internal static extern OSInt PInvoke_ShellExecute(IntPtr hWnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        
        [DllImport("shell32", CharSet = CharSet.Auto, EntryPoint = "ShellExecuteEx")]
        internal static extern bool PInvoke_ShellExecuteEx(ShellExecuteInfo pExecInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="dwFileAttirbute"></param>
        /// <param name="psfi"></param>
        /// <param name="cbFileInfo"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        public static OSUInt SHGetFileInfo(string pszPath, int dwFileAttirbute, ref SHFileInfo psfi, int cbFileInfo, int uFlags, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_SHGetFileInfo(pszPath, dwFileAttirbute, ref psfi, cbFileInfo, uFlags);

            OSUInt returnValue = PInvoke_SHGetFileInfo(pszPath, dwFileAttirbute, ref psfi, cbFileInfo, uFlags);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(SHGetFileInfo),
                callerName,
                returnValue,
                false,
                nameof(pszPath), pszPath,
                nameof(dwFileAttirbute), dwFileAttirbute,
                nameof(psfi), psfi,
                nameof(cbFileInfo), cbFileInfo,
                nameof(uFlags), uFlags
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpOperation"></param>
        /// <param name="lpFile"></param>
        /// <param name="lpParameters"></param>
        /// <param name="lpDirectory"></param>
        /// <param name="nShowCmd"></param>
        /// <returns></returns>
        public static OSInt ShellExecute(IntPtr hWnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_ShellExecute(hWnd, lpOperation, lpFile, lpParameters, lpDirectory, nShowCmd);

        OSInt returnValue = PInvoke_ShellExecute(hWnd, lpOperation, lpFile, lpParameters, lpDirectory, nShowCmd);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(ShellExecute),
                callerName,
                returnValue,
                false, // TODO: Pass predicate<T> to flexible result check
                nameof(hWnd), hWnd,
                nameof(lpOperation), lpOperation,
                nameof(lpFile), lpFile,
                nameof(lpParameters), lpParameters,
                nameof(lpDirectory), lpDirectory,
                nameof(nShowCmd), nShowCmd
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pExecInfo"></param>
        /// <returns></returns>
        public static bool ShellExecuteEx(ShellExecuteInfo pExecInfo, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_ShellExecuteEx(pExecInfo);

            bool returnValue = PInvoke_ShellExecuteEx(pExecInfo);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(ShellExecuteEx),
                callerName,
                returnValue,
                false,
                nameof(pExecInfo), pExecInfo
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
    }
}