using System;
using TeamDEV.Asl.PInvoke.Structures;

namespace TeamDEV.Asl.SystemManagements.Process {
    public class ProcessEntry {
        internal ProcessEntry(ProcessEntry32 pe32) {
            ImageName = pe32.szExeFile;
            Id = pe32.th32ProcessID;
            Usage = pe32.cntUsage;
            Threads = pe32.cntThreads;
            ParentId = pe32.th32ParentProcessID;
            ModuleId = pe32.th32ModuleID;
            DefaultHeapId = pe32.th32DefaultHeapID;
            PriorityClassBase = pe32.pcPriClassBase;
            Flags = pe32.dwFlags;
        }

        public string ImageName { get; }
        public uint Id { get; }
        public uint Usage { get; }
        public uint Threads { get; }
        public uint ParentId { get; }
        public uint ModuleId { get; }
        public IntPtr DefaultHeapId { get; }
        public uint PriorityClassBase { get; }
        public uint Flags { get; }
    }
}