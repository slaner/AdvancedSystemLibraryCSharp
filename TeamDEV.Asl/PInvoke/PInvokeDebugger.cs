using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

using TeamDEV.Asl.Extensions;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Internal.Methods;

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
        /// Executed when PInvoke call was captured
        /// </summary>
        public static event PInvokeCapturedEventHandler PInvokeCaptured;

        /// <summary>
        /// 
        /// </summary>
        public static bool LoggingEnabled { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public static PInvokeCaptureFilters CaptureFilters { get; set; }

        public static TextWriterTraceListener TraceListener { get; } = new TextWriterTraceListener();

        static TextWriterTraceListener m_traceListener;
        public static void Trace() {
            m_traceListener = new TextWriterTraceListener();
            m_traceListener.Write("");
            m_traceListener.Writer.ToString();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="moduleHandle"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string TranslateError(int errorCode, IntPtr moduleHandle = default(IntPtr), params string[] args) {
            FormatMessageFlags flags = moduleHandle.IsZero() ? FormatMessageFlags.FromSystem : FormatMessageFlags.FromModule;

            if (args != null && !args.Length.IsZero()) flags |= FormatMessageFlags.ArgumentArray;
            else flags |= FormatMessageFlags.IgnoreInserts;

            StringBuilder sbDescription = new StringBuilder(0x400);
            int result = Kernel32.FormatMessage(
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

        internal static void SafeCapture(PInvokeDebugInfo debugInfo) {
            lock (threadLock) {
                PInvokeCaptured?.Invoke(debugInfo);
            }
        }
    }
}