using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Internal;

namespace TeamDEV.Asl.SystemManagements.Process {
    /// <summary>
    /// 
    /// </summary>
    public sealed class Process: IIdentifiable, ITerminatable {
        public static Process Invalid { get; }
        static Process() { Invalid = new Process();  }
        public Process() : this(-1) { }
        public Process(int id) {
            Id = id;
        }





        public int Id { get; }
        public bool IsTerminated { get; private set; }
        public bool IsValid => Id >= 0;

        public bool Terminate() {
            return Terminate(0);
        }
        public bool Terminate(int exitCode) {
            // TODO: Implement process termination
            if (!IsValid || IsTerminated) return false;

            return false;
        }
    }
}