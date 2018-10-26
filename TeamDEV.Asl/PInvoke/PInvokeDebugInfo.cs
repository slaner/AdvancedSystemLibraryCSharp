using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// 
    /// </summary>
    public sealed class PInvokeDebugInfo {
        /// <summary>
        /// 
        /// </summary>
        public const string InfoNotTraced = "<NotTraced>";

        /// <summary>
        /// 
        /// </summary>
        public string PInvokeName { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleName { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public string CallerName { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public object ReturnValue { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public PInvokeParameters Parameters { get; } = new PInvokeParameters();
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorDescription { get; internal set; }


        internal static PInvokeDebugInfo TraceDebugInfo(string moduleName, string pinvokeName, string callerName, object returnValue, object errorReturnValue, params object[] args) {
            return TraceDebugInfo(PInvokeDebugger.TraceFilters, moduleName, pinvokeName, callerName, returnValue, errorReturnValue, args);
        }
        /// <summary>
        /// Trace debug information for specified PInvoke calls.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="moduleName">Module name</param>
        /// <param name="pinvokeName"></param>
        /// <param name="callerName"></param>
        /// <param name="returnValue"></param>
        /// <param name="errorReturnValue"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static PInvokeDebugInfo TraceDebugInfo(TraceFilters filter, string moduleName, string pinvokeName, string callerName, object returnValue, object errorReturnValue, params object[] args) {
            string moduleInfo = filter.HasFlag(TraceFilters.ModuleName) ? moduleName : InfoNotTraced;
            string pinvokeInfo = filter.HasFlag(TraceFilters.PInvokeName) ? pinvokeName : InfoNotTraced;
            string callerInfo = filter.HasFlag(TraceFilters.CallerName) ? callerName : InfoNotTraced;
            object returnValueInfo = filter.HasFlag(TraceFilters.ReturnValue) ? returnValue : InfoNotTraced;

            PInvokeDebugInfo debugInfo = new PInvokeDebugInfo {
                ModuleName = moduleInfo,
                PInvokeName = pinvokeInfo,
                CallerName = callerInfo,
                ReturnValue = returnValueInfo
            };

            if (filter.HasFlag(TraceFilters.Parameters)) {
                if (args.Length % 2 != 0) throw new ArgumentException(SR.GetString("SR_InvalidParameterArgsLength"));
                
                for (int i = 0; i < args.Length; i += 2) {
                    string paramName = (string) args[i];
                    object paramValue = args[i + 1];

                    debugInfo.Parameters[paramName] = paramValue;
                }
            }

            // trace error code and description
            // only if return value is equal to error return value
            if (returnValue == errorReturnValue) {
                int errorCode = Marshal.GetLastWin32Error();
                if (filter.HasFlag(TraceFilters.ErrorCode)) debugInfo.ErrorCode = errorCode;
                if (filter.HasFlag(TraceFilters.ErrorDescription)) debugInfo.ErrorDescription = PInvokeDebugger.TranslateError(errorCode);
            }

                
            return debugInfo;
        }
    }
}