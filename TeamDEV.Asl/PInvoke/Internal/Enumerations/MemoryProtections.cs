using System;

namespace TeamDEV.Asl.PInvoke.Internals.Enumerations {
    [Flags]
    public enum MemoryProtections : uint {
        NoAccess = 0x1,
        ReadOnly = 0x2,
        ReadWrite = 0x4,
        WriteCopy = 0x8,
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        Guard = 0x100,
        NoCache = 0x200,
        WriteCombine = 0x400
    }
}