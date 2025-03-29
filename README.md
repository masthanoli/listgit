# listgit

### cli tool for list all mapped git (cloned) folders - works in Windows.
For instance, if you have cloned a Git repository to your local machine and subsequently forgotten its exact location, this tool enables you to identify the folder path efficiently. It can either retrieve the full directory path of the repository or determine which specific folder or drive the repository is mapped to, streamlining the process of managing and accessing local Git repositories,  This CLI tool, developed in C# (C Sharp), is designed for Windows OS with planned support for Linux and Mac systems. It features an efficient and optimized algorithm for performing deep, recursive searches across all drives and directories on the entire computer. The tool leverages advanced file system to ensure high performance and accuracy in locating files and directories, making it an essential utility for comprehensive system searches. it provides two primary functionalities

#### Repository Discovery: Given a partial or full repository name, the tool recursively searches the file system to identify directories containing .git subdirectories, indicating a Git repository. It leverages Windows file system APIs for rapid traversal and pattern matching.
#### Mapping Retrieval: Given a specific directory or drive path, the tool identifies all Git repositories located within that scope. This is useful for determining which repositories are mapped to a particular local storage location.

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
