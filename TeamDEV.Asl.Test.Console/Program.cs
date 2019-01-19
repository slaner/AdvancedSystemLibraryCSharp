﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke;
using TeamDEV.Asl.PInvoke.Structures;
using TeamDEV.Asl.Utilities;

namespace TeamDEV.Asl.Test.Console {
    class Program {
        class test {
            public int aaf {
                get { return 0; }
                private set { }
            }
        }
        static void Main(string[] args) {
            PInvokeDebugger.LoggingEnabled = false;
            PInvokeDebugger.CaptureFilters = PInvokeCaptureFilters.CaptureAll;
            PInvokeDebugger.TraceListener.Writer = System.Console.Out;
            PInvokeDebugger.PInvokeCaptured += OnPInvokeCaptured;
            
            Process p = Process.GetCurrentProcess();

            // string p = "Hello";
            ProcessEnvironmentBlock peb;
            NativeHelper.GetProcessPEB(p.Id, out peb);
            ObjectInspector.Inspect(peb, ' ', 2);
            
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
