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