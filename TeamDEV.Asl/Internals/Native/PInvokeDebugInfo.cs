using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.Internals.Native {
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
        

        internal static PInvokeDebugInfo TraceDebugInfo(TraceFilters filter, string moduleName, string pinvokeName, string callerName, object returnValue, object expectedReturnValue, params object[] args) {
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
            // only if return value is not equal to expected return value
            if (returnValue != expectedReturnValue) {
                int errorCode = Marshal.GetLastWin32Error();
                if (filter.HasFlag(TraceFilters.ErrorCode)) debugInfo.ErrorCode = errorCode;
            }

                
            return debugInfo;
        }
    }
}