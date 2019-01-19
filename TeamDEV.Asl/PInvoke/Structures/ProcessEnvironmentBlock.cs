using System;
using System.Runtime.InteropServices;

namespace TeamDEV.Asl.PInvoke.Structures {
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct BitField {
        public byte Value;

        public bool ImageUsesLargePages {
            get { return (Value & 0x01) != 0; }
        }
        public bool IsProtectedProcess {
            get { return (Value & 0x02) != 0; }
        }
        public bool IsImageDynamicallyRelocated {
            get { return (Value & 0x04) != 0; }
        }
        public bool SkipPatchingUser32Forwarders {
            get { return (Value & 0x08) != 0; }
        }
        public bool IsPackagedProcess {
            get { return (Value & 0x10) != 0; }
        }
        public bool IsAppContainer {
            get { return (Value & 0x20) != 0; }
        }
        public bool IsProtectedProcessLight {
            get { return (Value & 0x40) != 0; }
        }
        public bool IsLongPathAwareProcess {
            get { return (Value & 0x80) != 0; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TracingFlags {
        public uint Value;

        public bool HeapTracingEnabled {
            get { return (Value & 0x01) != 0; }
        }
        public bool CriticalSectionTracingEnabled {
            get { return (Value & 0x02) != 0; }
        }
        public bool LibraryLoaderTracingEnabled {
            get { return (Value & 0x04) != 0; }
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessEnvironmentBlock {
        public byte InheritedAddressSpace;
        public byte ReadImageFileExecOptions;
        public byte BeingDebugged;
        public BitField BitField;
        public IntPtr Mutant;
        public IntPtr ImageBaseAddress;
        public IntPtr Ldr;
        public IntPtr ProcessParameters;

        public IntPtr SubSystemData;
        public IntPtr ProcessHeap;
        public IntPtr FastPebLock;

        public IntPtr AtlThunkSListPtr;
        public IntPtr IFEOKey;
        
        public uint EnvironmentUpdateCount;

        public IntPtr KernelCallbackTable;

        public uint EventLogSection;
        public uint EventLog;

        public IntPtr ApiSetMap;

        public uint TlsExpansionCounter;
        public IntPtr TlsBitmap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x2)]
        public uint[] TlsBitmapBits;

        public IntPtr ReadOnlySharedMemoryBase;
        public IntPtr ReadOnlySharedMemoryHeap;
        public IntPtr ReadOnlyStaticServerData;

        public IntPtr AnsiCodePageData;
        public IntPtr OemCodePageData;
        public IntPtr UnicodeCaseTableData;

        public uint NumberOfProcessors;
        public uint NtGlobalFlag;

        public ulong CriticalSectionTimeout;

        public UIntPtr HeapSegmentReserve;
        public UIntPtr HeapSegmentCommit;
        public UIntPtr HeapDeCommitTotalFreeThreshold;
        public UIntPtr HeapDeCommitFreeBlockThreshold;

        public uint NumberOfHeaps;
        public uint MaximumNumberOfHeaps;
        public IntPtr ProcessHeaps;

        public IntPtr GdiSharedHandleTable;
        public IntPtr ProcessStarterHelper;
        public uint GdiDCAttributeList;

        public IntPtr LoaderLock;

        public uint OSMajorVersion;
        public uint OSMinorVersion;
        public ushort OSBuildNumber;
        public ushort OSCSDVersion;
        public uint OSPlatformId;
        public uint ImageSubSystem;
        public uint ImageSubSystemMajorVersion;
        public uint ImageSubSystemMinorVersion;
        public UIntPtr ActiveProcessAffinityMask;
        public GdiHandleBuffer GdiHandleBuffer;
        public IntPtr PostProcessInitRoutine;

        public IntPtr TlsExpansionBitmap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public uint[] TlsExpansionBitmapBits;

        public uint SessionId;

        public ulong AppCompatFlags;
        public ulong AppCompatFlagsUser;
        public IntPtr pShimData;
        public IntPtr AppCompatInfo; // APPCOMPAT_EXE_DATA

        public UnicodeString CSDVersion;

        public IntPtr ActivationContextData; // ACTIVATION_CONTEXT_DATA
        public IntPtr ProcessAssemblyStorageMap; // ASSEMBLY_STORAGE_MAP
        public IntPtr SystemDefaultActivationContextData; // ACTIVATION_CONTEXT_DATA
        public IntPtr SystemAssemblyStorageMap; // ASSEMBLY_STORAGE_MAP

        public UIntPtr MinimumStackCommit;

        public IntPtr FlsCallback;
        public ListEntry FlsListHead;
        public IntPtr FlsBitmap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] FlsBitmapBits;
        public uint FlsHighIndex;

        public IntPtr WerRegistrationData;
        public IntPtr WerShipAssertPtr;
        public IntPtr pContextData;
        public IntPtr pImageHeaderHash;

        public TracingFlags TracingFlags;
        public ulong CsrServerReadOnlySharedMemoryBase;

        public static int Size {
            get { return Marshal.SizeOf(typeof(ProcessEnvironmentBlock)); }
        }
    }
}