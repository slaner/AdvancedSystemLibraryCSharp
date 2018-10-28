using System;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// Event handler for PInvoke capture event.
    /// </summary>
    /// <param name="debugInfo">An instance of <see cref="PInvokeDebugInfo" /> which contains captured PInvoke call information.</param>
    public delegate void PInvokeCapturedEventHandler(PInvokeDebugInfo debugInfo);
}