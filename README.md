# Octopussimizer

Crawling through a web site to find all its pages and feel through each page with the tentacles of an octopus to perform page optimization by decreasing file size where necessary and making use of minifying and bundling tools.

## Requirements

So, the main idea for optimizing a page or, better yet, a web site is to,

 * Remove unused (or irrelevant) styles from the stylesheets linked by each page in order to decrease file size
 * Minify JavaScript (JS) files by removing as much white space as possible in order to decrease file size
 * Bundle CSS and JS files into one file each respectively so as to decrease roundtrips to the server

All the above should be in the core library of the software.

## Installation

...

## Usage

...

## Contributions

...

# Developer Notes

Credit to [How to Use .NET Core CLI to Create a Multi-Project Solution](https://www.skylinetechnologies.com/Blog/Skyline-Blog/February_2018/how-to-use-dot-net-core-cli-create-multi-project) by Ben Buhr

The -o parameter lets you specify the output directory (which will get created in case it doesn’t exist). Once that command finishes, navigate into the folder and then execute the following commands:

[dotnet sln](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln)

```bash
dotnet new sln -o Harpoon
```

```bash
dotnet new classlib -o api/O8Query
```

```bash
dotnet new webapi -o api/Harpoon
```

```bash
dotnet sln Harpoon.sln add api/Harpoon/Harpoon.csproj api/O8Query/O8Query.csproj
```

```bash
dotnet build O8Query/O8Query.csproj
```

```bash
dotnet run -p api/Harpoon.csproj
```

```bash
dotnet publish api/Harpoon.csproj -o ../build -c Release
```

[dotnet add package](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)

```bash
dotnet add package Newtonsoft.Json
```

```bash
dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0
```

```bash
dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
```

[dotnet add reference](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference)

```bash
dotnet add app/app.csproj reference lib/lib.csproj
```


## Using EF Core CLI

[Entity Framework Core tools reference - .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

[Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

[Create and Drop APIs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/ensure-created)