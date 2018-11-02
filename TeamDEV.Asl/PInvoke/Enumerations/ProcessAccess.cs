using System;

namespace TeamDEV.Asl.PInvoke.Enumerations {
    [Flags]
    public enum ProcessAccess : uint {
        Terminate = 0x1,
        CreateThread = 0x2,
        SetSessionId = 0x4,
        VmOperation = 0x8,
        VmRead = 0x10,
        VmWrite = 0x20,
        DuplicateHandle = 0x40,
        CreateProcess = 0x80,
        SetQuota = 0x100,
        SetInformation = 0x200,
        QueryInformation = 0x400,
        SuspendResume = 0x800,
        QueryLimitedInformation = 0x1000,
        AllAccessInXPOrLower = AccessMask.StandardRightsRequired | AccessMask.Synchronize | 0xfff,
        AllAccessInVistaOrHigher = AccessMask.StandardRightsRequired | AccessMask.Synchronize | 0xffff,
        MaximumAllowed = 0x2000000
    }
}