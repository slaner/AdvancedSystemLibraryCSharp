using System;

using TeamDEV.Asl.PInvoke.Modules;

namespace TeamDEV.Asl.PInvoke {
    public static class ModuleManager {
        public static readonly IntPtr NtDll;

        static ModuleManager() {
            NtDll = Kernel32.PInvoke_GetModuleHandle(Ntdll.ModuleName);
        }
    }
}