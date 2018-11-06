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