# Advanced System Library
---
Branch: **`feature/pinvoke-building`**<br /><br />
[![Build Status](https://dev.azure.com/TeamDEVKR/Asl/_apis/build/status/Asl%20Build?branchName=feature/pinvoke-building)](https://dev.azure.com/TeamDEVKR/Asl/_build/latest?definitionId=2&branchName=feature/pinvoke-building)

[Advanced System Library](https://github.com/slaner/AdvancedSystemLibraryCSharp) is provide easy-access to system managing features for Windows Desktop. For example, you can access **PEB** of specific process, which `System.Diagnostics.Process`  class does not provides.

# Feature
Currently only few modules are supported and does not provide all APIs.
- Kernel32
- Ntdll
- PsApi
- Shell32 (Added since [`c460c86`](https://github.com/slaner/AdvancedSystemLibraryCSharp/commit/c460c865baa5a0b701a47bca4c96dee06a91de34))