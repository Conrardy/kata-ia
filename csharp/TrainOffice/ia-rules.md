# IA rules

## Rule 1: Add terminal command line when to add file

Provide the command line to add a file each time you ask me to add a new file
example :

On windows

``` powershell
New-Item -Path "C:\path\to\directory\file.txt" -ItemType File -Force
```

on mac or linux

``` bash
mkdir -p /path/to/directory && touch /path/to/directory/file.txt
```

## Rule 2: use File Scoped Namespaces

save an indentation level by using File Scoped Namespaces in c#

old way :

``` csharp
namespace Name
{
    using B;
    class C
    {
    }
}
```

File Scoped Namespaces way :

``` csharp
namespace Name;
using B;
class C
{
}
```

## Rule 2: use Primary constructors
