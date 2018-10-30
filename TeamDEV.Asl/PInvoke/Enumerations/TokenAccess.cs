using System;

namespace TeamDEV.Asl.PInvoke.Enumerations {
    [Flags]
    public enum TokenAccess {
        AssignPrimary = 0x1,
        Duplicate = 0x2,
        Impersonate = 0x4,
        Query = 0x8,
        QuerySource = 0x10,
        AdjustPrivileges = 0x20,
        AdjustGroups = 0x40,
        AdjustDefault = 0x80,
        AdjustSessionId = 0x100,
        Read = 0x20008,
        Write = 0x20000 | 0x80 | 0x40 | 0x20,
        Execute = 0x20000 | 0x4
    }
}