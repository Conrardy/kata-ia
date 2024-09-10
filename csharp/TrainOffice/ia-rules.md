# IA rules

## Rule 1: Add terminal command line when to add file

Provide the command line to add a file each time you ask me to add a new file
example :

``` powershell
code path\to\my\file
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
