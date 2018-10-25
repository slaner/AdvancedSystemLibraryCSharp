using System;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// Event handler for PInvoke trace event.
    /// </summary>
    /// <param name="debugInfo">An instance of <see cref="PInvokeDebugInfo" /> which contains traced PInvoke call information.</param>
    public delegate void PInvokeTraceEventHandler(PInvokeDebugInfo debugInfo);
}