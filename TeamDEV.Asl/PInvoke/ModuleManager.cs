using System;
using TeamDEV.Asl.PInvoke.Internal.Methods;

namespace TeamDEV.Asl.PInvoke {
    public static class ModuleManager {
        public static readonly IntPtr NtDll;

        static ModuleManager() {
            NtDll = Kernel32.GetModuleHandle(Ntdll.ModuleName);
        }
    }
}