using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.PInvoke.Enumerations {
    internal enum WaitResult {
        Failed = -1,
        Object = 0,
        Abandoned = 0x80,
        TimeOut = 0x102,
    }
}