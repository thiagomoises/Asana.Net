# Asana.Net
![Nuget](https://img.shields.io/badge/nuget-1.0.0-blue)

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package Asana.Net 
dotnet add package Asana.Net.DependencyInjection
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install Asana.Net 
nuget install Asana.Net.DependencyInjection
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package Asana.Net 
Install-Package Asana.Net.DependencyInjection
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Asana.Net".
5. Click on the Asana.Net package, select the appropriate version in the
   right-tab and click *Install*.



## Usage
This section contains some example of a basic usage of the library.

Exists 2 way to instance a AsanaApiClient. Using factory and using Dependency Injection

> We recommend the you use DI, but we understand that there're cases the is'nt possible use DI

### Factory

``` c# 
IAsanaApiClient client = AsanaApiClientFactory.Create("<your api key>");
```

### Dependency Injection

#### Setting apiKey on AppSettings

`appSettings.json`

``` json
{
    "apiKey": "<your api key>"
}
```

``` c#
services.AddAsanaApiClient(Configuration);
```

#### Setting apiKey manualy

``` c# 
services.AddAsanaApiClient(options=> options.ApiKey = "<your api key>");
```

or 

``` c#
AsanaApiOptions options = new AsanaApiOptions { ApiKey = "<your api key>" };
services.AddAsanaApiClient(options);
```
