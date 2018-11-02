using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl {
    public abstract class SystemObject: IIdentifiable, ITerminatable {
        protected SystemObject(int id) {
            Id = id;
        }

        public int Id { get; }
        public virtual bool Terminate(int exitCode) {
            return false;
        }
    }
}