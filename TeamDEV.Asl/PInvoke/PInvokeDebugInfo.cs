using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TeamDEV.Asl.PInvoke.Enumerations;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// 
    /// </summary>
    public sealed class PInvokeDebugInfo {
        /// <summary>
        /// 
        /// </summary>
        public const string InfoNotTraced = "<NotTraced>";

        private readonly IReadOnlyDictionary<string, object> cachedParametersCollection;

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
        public IReadOnlyDictionary<string, object> Parameters { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorDescription { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWarning { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsError { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="pinvokeName"></param>
        /// <param name="callerName"></param>
        /// <param name="returnValue"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static PInvokeDebugInfo TraceDebugInfo(string moduleName, string pinvokeName, string callerName, NTSTATUS returnValue, params object[] args) {
            return TraceDebugInfo(PInvokeDebugger.CaptureFilters, moduleName, pinvokeName, callerName, returnValue, null, args);
        }
        /// <summary>
        /// Trace debug information for specified PInvoke calls with global filter configuration.
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="pinvokeName"></param>
        /// <param name="callerName"></param>
        /// <param name="returnValue"></param>
        /// <param name="errorReturnValue"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static PInvokeDebugInfo TraceDebugInfo(string moduleName, string pinvokeName, string callerName, object returnValue, object errorReturnValue, params object[] args) {
            return TraceDebugInfo(PInvokeDebugger.CaptureFilters, moduleName, pinvokeName, callerName, returnValue, errorReturnValue, args);
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
        internal static PInvokeDebugInfo TraceDebugInfo(PInvokeCaptureFilters filter, string moduleName, string pinvokeName, string callerName, object returnValue, object errorReturnValue, params object[] args) {
            PInvokeDebugInfo debugInfo = SetupDebugInfo(filter, moduleName, pinvokeName, callerName, returnValue, args);

            // check if type of returnValue is NTSTATUS
            if (returnValue is NTSTATUS) {
                NTSTATUS status = (NTSTATUS) returnValue;

                if (status.IsError() || status.IsWarning()) {
                    if (filter.HasFlag(PInvokeCaptureFilters.ErrorCode)) debugInfo.ErrorCode = (int) status;
                    if (filter.HasFlag(PInvokeCaptureFilters.ErrorDescription)) debugInfo.ErrorDescription = PInvokeDebugger.TranslateError((int) returnValue, ModuleManager.NtDll);
                    debugInfo.IsWarning = status.IsWarning();
                    debugInfo.IsError = status.IsError();
                }
            } else {
                if (returnValue == errorReturnValue && returnValue != null) {
                    int errorCode = Marshal.GetLastWin32Error();
                    if (filter.HasFlag(PInvokeCaptureFilters.ErrorCode)) debugInfo.ErrorCode = errorCode;
                    if (filter.HasFlag(PInvokeCaptureFilters.ErrorDescription)) debugInfo.ErrorDescription = PInvokeDebugger.TranslateError(errorCode);
                    debugInfo.IsError = true;
                }
            }

            return debugInfo;
        }

        private static PInvokeDebugInfo SetupDebugInfo(PInvokeCaptureFilters filter, string moduleName, string pinvokeName, string callerName, object returnValue, params object[] args) {
            string moduleInfo = filter.HasFlag(PInvokeCaptureFilters.ModuleName) ? moduleName : InfoNotTraced;
            string pinvokeInfo = filter.HasFlag(PInvokeCaptureFilters.PInvokeName) ? pinvokeName : InfoNotTraced;
            string callerInfo = filter.HasFlag(PInvokeCaptureFilters.CallerName) ? callerName : InfoNotTraced;
            object returnValueInfo = filter.HasFlag(PInvokeCaptureFilters.ReturnValue) ? returnValue : InfoNotTraced;

            PInvokeDebugInfo debugInfo = new PInvokeDebugInfo {
                ModuleName = moduleInfo,
                PInvokeName = pinvokeInfo,
                CallerName = callerInfo,
                ReturnValue = returnValueInfo
            };
            
            if (filter.HasFlag(PInvokeCaptureFilters.Parameters)) {
                if (args == null) throw new ArgumentNullException(nameof(args));
                if (args.Length % 2 != 0) throw new ArgumentException(SR.GetString("SR_InvalidParameterArgsLength"));

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                for (int i = 0; i < args.Length; i += 2) {
                    string paramName = (string) args[i];
                    object paramValue = args[i + 1];
 
                    parameters[paramName] = paramValue;
                }

                debugInfo.Parameters = parameters;
            }

            return debugInfo;
        }
    }
}