using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// <summary>
        /// 
        /// </summary>
        public const string ModuleName = nameof(AdvApi32);

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

        public static bool GetTokenInformation(IntPtr TokenHandle, TokenInformationClass InfoClass, IntPtr Info, int Size, out int InfoLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_GetTokenInformation(TokenHandle, InfoClass, Info, Size, out InfoLength);
            
            bool returnValue = PInvoke_GetTokenInformation(TokenHandle, InfoClass, Info, Size, out InfoLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(GetTokenInformation),
                callerName,
                returnValue,
                false,
                nameof(TokenHandle), TokenHandle,
                nameof(InfoClass), InfoClass,
                nameof(Info), Info,
                nameof(Size), Size,
                nameof(InfoLength), InfoLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static bool LookupAccountSid(string lpSystemName, IntPtr Sid, string Name, out int cchName, string ReferencedDomainName, out int cchReferencedDomainName, out SidNameUse peUse, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_LookupAccountSid(lpSystemName, Sid, Name, out cchName, ReferencedDomainName, out cchReferencedDomainName, out peUse);
            
            bool returnValue = PInvoke_LookupAccountSid(lpSystemName, Sid, Name, out cchName, ReferencedDomainName, out cchReferencedDomainName, out peUse);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(LookupAccountSid),
                callerName,
                returnValue,
                false,
                nameof(lpSystemName), lpSystemName,
                nameof(Sid), Sid,
                nameof(Name), Name,
                nameof(cchName), cchName,
                nameof(ReferencedDomainName), ReferencedDomainName,
                nameof(cchReferencedDomainName), cchReferencedDomainName,
                nameof(peUse), peUse
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static bool OpenProcessToken(IntPtr ProcessHandle, TokenAccess Access, out IntPtr TokenHandle, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_OpenProcessToken(ProcessHandle, Access, out TokenHandle);
            
            bool returnValue = PInvoke_OpenProcessToken(ProcessHandle, Access, out TokenHandle);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(OpenProcessToken),
                callerName,
                returnValue,
                false,
                nameof(ProcessHandle), ProcessHandle,
                nameof(Access), Access,
                nameof(TokenHandle), TokenHandle
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static bool LookupPrivilegeValue(string lpSystemName, string lpName, out Luid Luid, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_LookupPrivilegeValue(lpSystemName, lpName, out Luid);

            bool returnValue = PInvoke_LookupPrivilegeValue(lpSystemName, lpName, out Luid);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(LookupPrivilegeValue),
                callerName,
                returnValue,
                false,
                nameof(lpSystemName), lpSystemName,
                nameof(lpName), lpName,
                nameof(Luid), Luid
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, out TokenPrivileges NewState, int BufferLength, out TokenPrivileges PreviousState, out int ReturnLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_AdjustTokenPrivileges(TokenHandle, DisableAllPrivileges, out NewState, BufferLength, out PreviousState, out ReturnLength);
            
            bool returnValue = PInvoke_AdjustTokenPrivileges(TokenHandle, DisableAllPrivileges, out NewState, BufferLength, out PreviousState, out ReturnLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(AdjustTokenPrivileges),
                callerName,
                returnValue,
                false,
                nameof(TokenHandle), TokenHandle,
                nameof(DisableAllPrivileges), DisableAllPrivileges,
                nameof(NewState), NewState,
                nameof(BufferLength), BufferLength,
                nameof(PreviousState), PreviousState,
                nameof(ReturnLength), ReturnLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        public static bool LookupPrivilegeName(string lpSystemName, out Luid lpLuid, string lpName, out int cchName, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_LookupPrivilegeName(lpSystemName, out lpLuid, lpName, out cchName);
            
            bool returnValue = PInvoke_LookupPrivilegeName(lpSystemName, out lpLuid, lpName, out cchName);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(LookupPrivilegeName),
                callerName,
                returnValue,
                false,
                nameof(lpSystemName), lpSystemName,
                nameof(lpLuid), lpLuid,
                nameof(lpName), lpName,
                nameof(cchName), cchName
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }


    }
}