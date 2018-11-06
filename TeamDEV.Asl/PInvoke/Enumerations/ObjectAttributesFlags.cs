using System;
namespace TeamDEV.Asl.PInvoke.Enumerations {
    [Flags]
    public enum ObjectAttributesFlags: uint {
        Inherit = 0x00000002,
        Permanent = 0x00000010,
        Exclusive = 0x00000020,
        CaseInsensitive = 0x00000040,
        OpenIf = 0x00000080,
        OpenLink = 0x00000100,
        ValidAttributes = 0x000001F2,
    }
}