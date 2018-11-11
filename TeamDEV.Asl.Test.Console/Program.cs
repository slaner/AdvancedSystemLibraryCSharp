using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.Test.Console {
    class Program {
        static void Main(string[] args) {
            PInvokeDebugger.LoggingEnabled = true;
            PInvokeDebugger.CaptureFilters = PInvokeCaptureFilters.CaptureAll;
            PInvokeDebugger.TraceListener.Writer = System.Console.Out;
            PInvokeDebugger.PInvokeCaptured += OnPInvokeCaptured;
            // var entries = NativeHelper.GetProcessEntries();
            // System.Console.WriteLine("Entries: {0}", entries.Length);

            // PEB TEST
            ProcessEnvironmentBlock peb;

            NativeHelper.GetProcessPEB(13472, out peb);

            System.Console.ReadKey(true);
        }
        private static void OnPInvokeCaptured(PInvokeDebugInfo debugInfo) {
            PInvokeDebugger.TraceListener.WriteLine($"Captured PInvoke Information");
            PInvokeDebugger.TraceListener.WriteLine($"  {debugInfo.ModuleName}::{debugInfo.PInvokeName}");
            PInvokeDebugger.TraceListener.WriteLine($"  Caller Name      : {debugInfo.CallerName}");
            PInvokeDebugger.TraceListener.WriteLine($"  Return Value     : {debugInfo.ReturnValue}");
            PInvokeDebugger.TraceListener.WriteLine($"  IsWarning        : {debugInfo.IsWarning}");
            PInvokeDebugger.TraceListener.WriteLine($"  IsError          : {debugInfo.IsError}");
            PInvokeDebugger.TraceListener.WriteLine($"  Error Code       : {debugInfo.ErrorCode}");
            PInvokeDebugger.TraceListener.WriteLine($"  Error Description: {debugInfo.ErrorDescription}");
            PInvokeDebugger.TraceListener.WriteLine($"  Parameters");
            foreach (var pair in debugInfo.Parameters) {
                PInvokeDebugger.TraceListener.WriteLine($"    {pair.Key}: {pair.Value}");
            }
            PInvokeDebugger.TraceListener.WriteLine("");
        }
    }
}
