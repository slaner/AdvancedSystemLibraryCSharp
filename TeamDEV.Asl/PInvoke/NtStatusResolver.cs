using TeamDEV.Asl.PInvoke.Enumerations;

namespace TeamDEV.Asl.PInvoke {
    /// <summary>
    /// 
    /// </summary>
    public sealed class NtStatusResolver {
        public NtStatusResolver(NTSTATUS status) {
            uint statusValue = (uint) status;
            ushort high = (ushort) ((statusValue & 0xFFFF0000U) >> 16);

            SeverityCode = (SeverityCode) ((high & 0xC000) >> 14);
            CustomerCode = (byte) ((high & 0x2000) >> 13);
            FacilityCode = (FacilityCode) (high & 0x1FFF);
            StatusCode = (ushort) (statusValue & 0xFFFF);
        }

        /// <summary>
        /// 
        /// </summary>
        public SeverityCode SeverityCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte CustomerCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public FacilityCode FacilityCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public ushort StatusCode { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return $"Severity: {SeverityCode}, Facility: {FacilityCode}, Status: {StatusCode}";
        }
    }
}
