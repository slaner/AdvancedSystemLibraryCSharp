using System;

namespace TeamDEV.Asl.Internals.Native {
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum TraceFilters {
        /// <summary>
        /// 
        /// </summary>
        PInvokeName = 0x01,
        /// <summary>
        /// 
        /// </summary>
        ModuleName = 0x02,
        /// <summary>
        /// 
        /// </summary>
        CallerName = 0x04,
        /// <summary>
        /// 
        /// </summary>
        Parameters = 0x08,
        /// <summary>
        /// 
        /// </summary>
        ReturnValue = 0x10,
        /// <summary>
        /// 
        /// </summary>
        ErrorCode = 0x100,
        /// <summary>
        /// 
        /// </summary>
        ErrorDescription = 0x200,
        /// <summary>
        /// 
        /// </summary>
        Exception = 0x400,
        /// <summary>
        /// 
        /// </summary>
        StackTrace = 0x800,
    }
}