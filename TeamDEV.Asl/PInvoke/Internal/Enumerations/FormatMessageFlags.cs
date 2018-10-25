using System;

namespace TeamDEV.Asl.PInvoke.Internals.Enumerations {
    [Flags]
    public enum FormatMessageFlags {
        AllocateBuffer = 0x100,
        IgnoreInserts = 0x200,
        FromString = 0x400,
        FromModule = 0x800,
        FromSystem = 0x1000,
        ArgumentArray = 0x2000,
    }
}