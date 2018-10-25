using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke;

namespace TeamDEV.Asl.Test.Console {
    class Program {
        static void Main(string[] args) {
            PInvokeDebugger.PInvokeTraced += OnPInvokeTraced;
            
        }

        private static void OnPInvokeTraced(PInvokeDebugInfo debugInfo) {

        }
    }
}
