# listgit

### cli tool for list all mapped git (cloned) folders - works in Windows.
This CLI tool, developed in C# (C Sharp), is designed for Windows OS with planned support for Linux and Mac systems. It features an efficient and optimized algorithm for performing deep, recursive searches across all drives and directories on the entire computer. The tool leverages advanced file system to ensure high performance and accuracy in locating files and directories, making it an essential utility for comprehensive system searches

### it support 2 arguments

```
1. * (star) or specific folder
2. git remote repo info
```

## Example

> listgit

This searches entire computer for all git repo

> listgit * https://github.com/masthanoli/listgit.git

This searches entire computer for given git repo location (cloned)

> listgit d:\\src\\ https://github.com/masthanoli/listgit.git

This searches d:\\src\\ folder (recursive) for given git repo cloned location

> listgit d:\\src\\

This searches d:\\src\\ folder (recursive) all git cloned
