using System;
using System.Collections.Generic;

using TeamDEV.Asl.Extensions;
using TeamDEV.Asl.PInvoke.Enumerations;
using TeamDEV.Asl.PInvoke.Modules;
using TeamDEV.Asl.PInvoke.Structures;
using TeamDEV.Asl.SystemManagements.Process;

namespace TeamDEV.Asl.PInvoke {
    public static class NativeHelper {
        public static ProcessEntry[] GetProcessEntries() {
            IntPtr hSnapshot = Kernel32.CreateToolhelp32Snapshot(SnapshotFlags.Process, 0);
            if (hSnapshot.IsZero()) return null;

            ProcessEntry32 pe32 = default(ProcessEntry32);
            pe32.dwSize = (uint) ProcessEntry32.Size;
            
            if (!Kernel32.Process32First(hSnapshot, ref pe32)) {
                Kernel32.CloseHandle(hSnapshot);
                return null;
            }

            List<ProcessEntry> processEntries = new List<ProcessEntry>();
            do {
                processEntries.Add(new ProcessEntry(pe32));
            } while (Kernel32.Process32Next(hSnapshot, ref pe32));

            Kernel32.CloseHandle(hSnapshot);
            return processEntries.ToArray();
        }
    }
}