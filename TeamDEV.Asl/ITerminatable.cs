using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl {
    /// <summary>
    /// 
    /// </summary>
    public interface ITerminatable {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exitCode"></param>
        /// <returns></returns>
        bool Terminate(int exitCode);
    }
}