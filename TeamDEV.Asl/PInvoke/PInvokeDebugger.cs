using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.Extensions;
using TeamDEV.Asl.PInvoke.Internals.Enumerations;
using TeamDEV.Asl.PInvoke.Internals.Methods;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// 
    /// </summary>
    public static class PInvokeDebugger {
        /// <summary>
        /// 
        /// </summary>
        public const string PInvokeCallPrefix = "PInvoke_";

        static readonly object threadLock = new object();
        
        /// <summary>
        /// Executed when PInvoke call was traced
        /// </summary>
        public static event PInvokeTraceEventHandler PInvokeTraced;

        /// <summary>
        /// 
        /// </summary>
        public static bool LoggingEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static TraceFilters TraceFilters { get; set; }

        static TextWriterTraceListener m_traceListener;
        public static void Trace() {
            m_traceListener = new TextWriterTraceListener();
            m_traceListener.Write("");
            m_traceListener.Writer.ToString();
        }



        public static string TranslateError(int errorCode, IntPtr moduleHandle = default(IntPtr), params string[] args) {
            FormatMessageFlags flags = moduleHandle.IsZero() ? FormatMessageFlags.FromSystem : FormatMessageFlags.FromModule;

            if (args != null && !args.Length.IsZero()) flags |= FormatMessageFlags.ArgumentArray;
            else flags |= FormatMessageFlags.IgnoreInserts;

            StringBuilder sbDescription = new StringBuilder(0x400);
            int result = Kernel32.PInvoke_FormatMessage(
                flags,
                moduleHandle,
                errorCode,
                0x400 /* NEUTRAL LANGUAGE */,
                sbDescription,
                0x400 /* Size */,
                args);

            // if PInvoke fails, use Win32Exception to get error message
            if (result.IsZero()) {
                Win32Exception exception = new Win32Exception(Marshal.GetLastWin32Error());
                return exception.Message;
            }
            
            return sbDescription.ToString();
        }

        internal static void SafeTrace(PInvokeDebugInfo debugInfo) {
            lock (threadLock) {
                PInvokeTraced?.Invoke(debugInfo);
            }
        }
    }
}