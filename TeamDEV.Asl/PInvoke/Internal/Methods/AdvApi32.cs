using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.PInvoke.Internal.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class AdvApi32 {
        [DllImport("advapi32", CharSet = CharSet.Auto, EntryPoint = "GetTokenInformation")]
        internal static extern bool PInvoke_GetTokenInformation(IntPtr TokenHandle, TokenInformationClass InfoClass, IntPtr Info, int Size, out int InfoLength);
        [DllImport("advapi32", CharSet = CharSet.Auto, EntryPoint = "LookupAccountSid")]
        internal static extern bool PInvoke_LookupAccountSid(string lpSystemName, IntPtr Sid, string Name, out int cchName, string ReferencedDomainName, out int cchReferencedDomainName, out SidNameUse peUse);
        [DllImport("advapi32", CharSet = CharSet.Auto, EntryPoint = "OpenProcessToken")]
        internal static extern bool PInvoke_OpenProcessToken(IntPtr ProcessHandle, TokenAccess Access, out IntPtr TokenHandle);
        [DllImport("advapi32", CharSet = CharSet.Auto, EntryPoint = "LookupPrivilegeValue")]
        internal static extern bool PInvoke_LookupPrivilegeValue(string lpSystemName, string lpName, out Luid Luid);
        [DllImport("advapi32", CharSet = CharSet.Auto, EntryPoint = "AdjustTokenPrivileges")]
        internal static extern bool PInvoke_AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, out TokenPrivileges NewState, int BufferLength, out TokenPrivileges PreviousState, out int ReturnLength);
        [DllImport("advapi32", CharSet = CharSet.Auto, EntryPoint = "LookupPrivilegeName")]
        internal static extern bool PInvoke_LookupPrivilegeName(string lpSystemName, out Luid lpLuid, string lpName, out int cchName);
    }
}