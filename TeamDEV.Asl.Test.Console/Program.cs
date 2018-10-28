using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke;

namespace TeamDEV.Asl.Test.Console {
    class Program {
        static void Main(string[] args) {
            PInvokeDebugger.TraceListener.Writer = System.Console.Out;
            PInvokeDebugger.PInvokeCaptured += OnPInvokeCaptured;
            TeamDEV.Asl.Process
            while (true) {

            }
        }
        private static void OnPInvokeCaptured(PInvokeDebugInfo debugInfo) {
            PInvokeDebugger.TraceListener.WriteLine($"Module Name: {debugInfo.ModuleName}");
        }
    }
}
