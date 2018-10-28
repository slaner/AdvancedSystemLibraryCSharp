using System;
using TeamDEV.Asl.PInvoke.Internals.Methods;

namespace TeamDEV.Asl.PInvoke {
    public static class ModuleManager {
        public static readonly IntPtr NtDll;

        static ModuleManager() {
            NtDll = Kernel32.GetModuleHandle(Ntdll.ModuleName);
        }
    }
}