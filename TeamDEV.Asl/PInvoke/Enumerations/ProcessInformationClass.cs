﻿namespace TeamDEV.Asl.PInvoke.Enumerations {
    public enum ProcessInformationClass {
        ProcessBasicInformation, // 0, q: PROCESS_BASIC_INFORMATION, PROCESS_EXTENDED_BASIC_INFORMATION
	    ProcessQuotaLimits, // qs: QUOTA_LIMITS, QUOTA_LIMITS_EX
	    ProcessIoCounters, // q: IO_COUNTERS
	    ProcessVmCounters, // q: VM_COUNTERS, VM_COUNTERS_EX
	    ProcessTimes, // q: KERNEL_USER_TIMES
	    ProcessBasePriority, // s: KPRIORITY
	    ProcessRaisePriority, // s: ULONG
	    ProcessDebugPort, // q: HANDLE
	    ProcessExceptionPort, // s: HANDLE
	    ProcessAccessToken, // s: PROCESS_ACCESS_TOKEN
	    ProcessLdtInformation, // 10
	    ProcessLdtSize,
	    ProcessDefaultHardErrorMode, // qs: ULONG
	    ProcessIoPortHandlers,
	    ProcessPooledUsageAndLimits, // q: POOLED_USAGE_AND_LIMITS
	    ProcessWorkingSetWatch, // q: PROCESS_WS_WATCH_INFORMATION[]; s: void
	    ProcessUserModeIOPL,
	    ProcessEnableAlignmentFaultFixup, // s: BOOLEAN
	    ProcessPriorityClass, // qs: PROCESS_PRIORITY_CLASS
	    ProcessWx86Information,
	    ProcessHandleCount, // 20, q: ULONG, PROCESS_HANDLE_INFORMATION
	    ProcessAffinityMask, // s: KAFFINITY
	    ProcessPriorityBoost, // qs: ULONG
	    ProcessDeviceMap,
	    ProcessSessionInformation, // q: PROCESS_SESSION_INFORMATION
	    ProcessForegroundInformation, // s: PROCESS_FOREGROUND_BACKGROUND (BOOLEAN)
	    ProcessWow64Information, // q: ULONG_PTR
	    ProcessImageFileName, // q: UNICODE_STRING
	    ProcessLUIDDeviceMapsEnabled, // q: ULONG
	    ProcessBreakOnTermination, // qs: ULONG
	    ProcessDebugObjectHandle, // 30, q: HANDLE
	    ProcessDebugFlags, // qs: ULONG
	    ProcessHandleTracing, // q: PROCESS_HANDLE_TRACING_QUERY; s: size 0 disables, otherwise enables
	    ProcessIoPriority, // qs: ULONG
	    ProcessExecuteFlags, // qs: ULONG
	    ProcessResourceManagement,
	    ProcessCookie, // q: ULONG
	    ProcessImageInformation, // q: SECTION_IMAGE_INFORMATION
	    ProcessCycleTime, // q: PROCESS_CYCLE_TIME_INFORMATION
	    ProcessPagePriority, // q: ULONG
	    ProcessInstrumentationCallback, // 40
	    ProcessThreadStackAllocation, // qs: PROCESS_STACK_ALLOCATION_INFORMATION
	    ProcessWorkingSetWatchEx, // q: PROCESS_WS_WATCH_INFORMATION_EX[]
	    ProcessImageFileNameWin32, // q: UNICODE_STRING
	    ProcessImageFileMapping, // q: HANDLE (input)
	    ProcessAffinityUpdateMode, // qs: PROCESS_AFFINITY_UPDATE_MODE
	    ProcessMemoryAllocationMode, // qs: PROCESS_MEMORY_ALLOCATION_MODE
	    ProcessGroupInformation, // q: USHORT[]
	    ProcessTokenVirtualizationEnabled, // s: ULONG
	    ProcessConsoleHostProcess, // q: ULONG_PTR
	    ProcessWindowInformation, // 50, q: PROCESS_WINDOW_INFORMATION
	    ProcessHandleInformation, // q: PROCESS_HANDLE_SNAPSHOT_INFORMATION // since WIN8
	    ProcessMitigationPolicy, // qs: PROCESS_MITIGATION_POLICY_INFORMATION
	    ProcessDynamicFunctionTableInformation,
	    ProcessHandleCheckingMode,
	    MaxProcessInfoClass
    }
}