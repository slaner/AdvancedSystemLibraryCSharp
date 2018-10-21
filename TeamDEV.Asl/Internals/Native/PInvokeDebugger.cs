using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.Internals.Native {
    /// <summary>
    /// 
    /// </summary>
    public static class PInvokeDebugger {
        public const string PInvokeCallPrefix = "PInvoke_";


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
    }
}