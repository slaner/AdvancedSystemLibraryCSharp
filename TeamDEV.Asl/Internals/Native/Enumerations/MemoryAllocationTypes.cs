using System;

namespace TeamDEV.Asl.Internals.Native.Enumerations {
    [Flags]
    public enum MemoryAllocationTypes : uint {
        Commit = 0x1000,
        Reserve = 0x2000,
        Decommit = 0x4000,
        Release = 0x8000,
        Free = 0x10000,
        Private = 0x20000,
        Mapped = 0x40000,
        Reset = 0x80000,
        TopDown = 0x100000,
        Physical = 0x400000,
        ResetUndo = 0x1000000,
        LargePages = 0x20000000,
        FourMBPages = 0x80000000
    }
}