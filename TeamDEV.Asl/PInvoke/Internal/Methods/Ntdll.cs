using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.PInvoke.Internals.Methods {
    /// <summary>
    /// 
    /// </summary>
    static class Ntdll {
        /// <summary>
        /// 
        /// </summary>
        public const string ModuleName = nameof(Ntdll);

        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryInformationProcess")]
        internal static extern NTSTATUS PInvoke_NtQueryVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, MemoryInformationClass InfoClass, IntPtr Info, uint InfoLength, out uint ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtReadVirtualMemory")]
        internal static extern NTSTATUS PInvoke_NtReadVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, uint BufferSize, out uint BytesRead);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtWriteVirtualMemory")]
        internal static extern NTSTATUS PInvoke_NtWriteVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, uint BufferSize, out uint BytesWritten);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtProtectVirtualMemory")]
        internal static extern NTSTATUS PInvoke_NtProtectVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, uint Length, MemoryProtections NewProtection, out MemoryProtections OldProtection);

        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtClose")]
        internal static extern NTSTATUS PInvoke_NtClose(IntPtr Handle);

        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryObject")]
        internal static extern NTSTATUS PInvoke_NtQueryObject(IntPtr ObjectHandle, ObjectInformationClass ObjectInformationClass, IntPtr Info, uint InfoLength, out uint ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtDuplicateObject")]
        internal static extern NTSTATUS PInvoke_NtDuplicateObject(IntPtr SourceProcessHandle, IntPtr SourceHandle, IntPtr TargetProcessHandle, ref IntPtr TargetHandle, AccessMask DesiredAccess, uint Attributes, uint Options);

        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQuerySymbolicLinkObject")]
        internal static extern NTSTATUS PInvoke_NtQuerySymbolicLinkObject(IntPtr LinkHandle, IntPtr LinkTarget, out uint ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtOpenSymbolicLinkObject")]
        internal static extern NTSTATUS PInvoke_NtOpenSymbolicLinkObject(IntPtr LinkHandle, AccessMask Access, IntPtr ObjectAttributes);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtOpenProcess")]
        internal static extern NTSTATUS PInvoke_NtOpenProcess(ref IntPtr ProcessHandle, ProcessAccess Access, ref ObjectAttributes ObjectAttributes, ref ClientId Cid);

        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQuerySystemInformation")]
        internal static extern NTSTATUS PInvoke_NtQuerySystemInformation(SystemInformationClass InfoClass, IntPtr Info, uint InfoLength, out uint ReturnLength);
        [DllImport("ntdll", CharSet = CharSet.Auto, EntryPoint = "NtQueryInformationProcess")]
        internal static extern NTSTATUS PInvoke_NtQueryInformationProcess(IntPtr ProcessHandle, ProcessInformationClass InfoClass, IntPtr Info, uint InfoLength, out uint ReturnLength);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="BaseAddress"></param>
        /// <param name="InfoClass"></param>
        /// <param name="Info"></param>
        /// <param name="InfoLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtQueryVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, MemoryInformationClass InfoClass, IntPtr Info, uint InfoLength, out uint ReturnLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtQueryVirtualMemory(ProcessHandle, BaseAddress, InfoClass, Info, InfoLength, out ReturnLength);

            NTSTATUS returnValue = PInvoke_NtQueryVirtualMemory(ProcessHandle, BaseAddress, InfoClass, Info, InfoLength, out ReturnLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtQueryVirtualMemory),
                callerName,
                returnValue,
                nameof(ProcessHandle), ProcessHandle,
                nameof(BaseAddress), BaseAddress,
                nameof(InfoClass), InfoClass,
                nameof(Info), Info,
                nameof(InfoLength), InfoLength,
                nameof(ReturnLength), ReturnLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="BaseAddress"></param>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="BytesRead"></param>
        /// <returns></returns>
        public static NTSTATUS NtReadVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, uint BufferSize, out uint BytesRead, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtReadVirtualMemory(ProcessHandle, BaseAddress, Buffer, BufferSize, out BytesRead);

            NTSTATUS returnValue = PInvoke_NtReadVirtualMemory(ProcessHandle, BaseAddress, Buffer, BufferSize, out BytesRead);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtReadVirtualMemory),
                callerName,
                returnValue,
                nameof(ProcessHandle), ProcessHandle,
                nameof(BaseAddress), BaseAddress,
                nameof(Buffer), Buffer,
                nameof(BufferSize), BufferSize,
                nameof(BytesRead), BytesRead
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="BaseAddress"></param>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="BytesWritten"></param>
        /// <returns></returns>
        public static NTSTATUS NtWriteVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, IntPtr Buffer, uint BufferSize, out uint BytesWritten, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtWriteVirtualMemory(ProcessHandle, BaseAddress, Buffer, BufferSize, out BytesWritten);

            NTSTATUS returnValue = PInvoke_NtWriteVirtualMemory(ProcessHandle, BaseAddress, Buffer, BufferSize, out BytesWritten);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtWriteVirtualMemory),
                callerName,
                returnValue,
                nameof(ProcessHandle), ProcessHandle,
                nameof(BaseAddress), BaseAddress,
                nameof(Buffer), Buffer,
                nameof(BufferSize), BufferSize,
                nameof(BytesWritten), BytesWritten
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="BaseAddress"></param>
        /// <param name="Length"></param>
        /// <param name="NewProtection"></param>
        /// <param name="OldProtection"></param>
        /// <returns></returns>
        public static NTSTATUS NtProtectVirtualMemory(IntPtr ProcessHandle, IntPtr BaseAddress, uint Length, MemoryProtections NewProtection, out MemoryProtections OldProtection, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtProtectVirtualMemory(ProcessHandle, BaseAddress, Length, NewProtection, out OldProtection);

            NTSTATUS returnValue = PInvoke_NtProtectVirtualMemory(ProcessHandle, BaseAddress, Length, NewProtection, out OldProtection);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtProtectVirtualMemory),
                callerName,
                returnValue,
                nameof(ProcessHandle), ProcessHandle,
                nameof(BaseAddress), BaseAddress,
                nameof(Length), Length,
                nameof(NewProtection), NewProtection,
                nameof(OldProtection), OldProtection
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="BaseAddress"></param>
        /// <param name="InfoClass"></param>
        /// <param name="Info"></param>
        /// <param name="InfoLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtClose(IntPtr Handle, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtClose(Handle);

            NTSTATUS returnValue = PInvoke_NtClose(Handle);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtClose),
                callerName,
                returnValue,
                nameof(Handle), Handle
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectHandle"></param>
        /// <param name="ObjectInformationClass"></param>
        /// <param name="Info"></param>
        /// <param name="InfoLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtQueryObject(IntPtr ObjectHandle, ObjectInformationClass ObjectInformationClass, IntPtr Info, uint InfoLength, out uint ReturnLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtQueryObject(ObjectHandle, ObjectInformationClass, Info, InfoLength, out ReturnLength);

            NTSTATUS returnValue = PInvoke_NtQueryObject(ObjectHandle, ObjectInformationClass, Info, InfoLength, out ReturnLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtQueryObject),
                callerName,
                returnValue,
                nameof(ObjectHandle), ObjectHandle,
                nameof(ObjectInformationClass), ObjectInformationClass,
                nameof(Info), Info,
                nameof(InfoLength), InfoLength,
                nameof(ReturnLength), ReturnLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceProcessHandle"></param>
        /// <param name="SourceHandle"></param>
        /// <param name="TargetProcessHandle"></param>
        /// <param name="TargetHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="Attributes"></param>
        /// <param name="Options"></param>
        /// <returns></returns>
        public static NTSTATUS NtDuplicateObject(IntPtr SourceProcessHandle, IntPtr SourceHandle, IntPtr TargetProcessHandle, ref IntPtr TargetHandle, AccessMask DesiredAccess, uint Attributes, uint Options, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtDuplicateObject(SourceProcessHandle, SourceHandle, TargetProcessHandle, ref TargetHandle, DesiredAccess, Attributes, Options);

            NTSTATUS returnValue = PInvoke_NtDuplicateObject(SourceProcessHandle, SourceHandle, TargetProcessHandle, ref TargetHandle, DesiredAccess, Attributes, Options);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtDuplicateObject),
                callerName,
                returnValue,
                nameof(SourceProcessHandle), SourceProcessHandle,
                nameof(SourceHandle), SourceHandle,
                nameof(TargetProcessHandle),TargetProcessHandle,
                nameof(DesiredAccess), DesiredAccess,
                nameof(Attributes), Attributes,
                nameof(Options), Options
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LinkHandle"></param>
        /// <param name="LinkTarget"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtQuerySymbolicLinkObject(IntPtr LinkHandle, IntPtr LinkTarget, out uint ReturnLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtQuerySymbolicLinkObject(LinkHandle, LinkTarget, out ReturnLength);

            NTSTATUS returnValue = PInvoke_NtQuerySymbolicLinkObject(LinkHandle, LinkTarget, out ReturnLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtQuerySymbolicLinkObject),
                callerName,
                returnValue,
                nameof(LinkHandle), LinkHandle,
                nameof(LinkTarget), LinkTarget,
                nameof(ReturnLength), ReturnLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LinkHandle"></param>
        /// <param name="LinkTarget"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtOpenSymbolicLinkObject(IntPtr LinkHandle, AccessMask Access, IntPtr ObjectAttributes, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtOpenSymbolicLinkObject(LinkHandle, Access, ObjectAttributes);

            NTSTATUS returnValue = PInvoke_NtOpenSymbolicLinkObject(LinkHandle, Access, ObjectAttributes);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtOpenSymbolicLinkObject),
                callerName,
                returnValue,
                nameof(LinkHandle), LinkHandle,
                nameof(Access), Access,
                nameof(ObjectAttributes), ObjectAttributes
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="Access"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="Cid"></param>
        /// <returns></returns>
        public static NTSTATUS NtOpenProcess(ref IntPtr ProcessHandle, ProcessAccess Access, ref ObjectAttributes ObjectAttributes, ref ClientId Cid, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtOpenProcess(ref ProcessHandle, Access, ref ObjectAttributes, ref Cid);

            NTSTATUS returnValue = PInvoke_NtOpenProcess(ref ProcessHandle, Access, ref ObjectAttributes, ref Cid);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtOpenProcess),
                callerName,
                returnValue,
                nameof(ProcessHandle), ProcessHandle,
                nameof(Access), Access,
                nameof(ObjectAttributes), ObjectAttributes,
                nameof(Cid), Cid
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoClass"></param>
        /// <param name="Info"></param>
        /// <param name="InfoLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtQuerySystemInformation(SystemInformationClass InfoClass, IntPtr Info, uint InfoLength, out uint ReturnLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtQuerySystemInformation(InfoClass, Info, InfoLength, out ReturnLength);

            NTSTATUS returnValue = PInvoke_NtQuerySystemInformation(InfoClass, Info, InfoLength, out ReturnLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtQuerySystemInformation),
                callerName,
                returnValue,
                nameof(InfoClass), InfoClass,
                nameof(Info), Info,
                nameof(InfoLength), InfoLength,
                nameof(ReturnLength), ReturnLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="InfoClass"></param>
        /// <param name="Info"></param>
        /// <param name="InfoLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        public static NTSTATUS NtQueryInformationProcess(IntPtr ProcessHandle, ProcessInformationClass InfoClass, IntPtr Info, uint InfoLength, out uint ReturnLength, [CallerMemberName] string callerName = "") {
            if (!PInvokeDebugger.LoggingEnabled)
                return PInvoke_NtQueryInformationProcess(ProcessHandle, InfoClass, Info, InfoLength, out ReturnLength);

            NTSTATUS returnValue = PInvoke_NtQueryInformationProcess(ProcessHandle, InfoClass, Info, InfoLength, out ReturnLength);
            PInvokeDebugInfo debugInfo = PInvokeDebugInfo.TraceDebugInfo(
                ModuleName,
                nameof(NtQueryInformationProcess),
                callerName,
                returnValue,
                nameof(ProcessHandle), ProcessHandle,
                nameof(InfoClass), InfoClass,
                nameof(Info), Info,
                nameof(InfoLength), InfoLength,
                nameof(ReturnLength), ReturnLength
            );

            PInvokeDebugger.SafeCapture(debugInfo);
            return returnValue;
        }
    }
}