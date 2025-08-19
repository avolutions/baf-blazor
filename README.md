# Avolutions BAF Blazor

Blazor component library for the Avolutions Business Application Framework (BAF).

## Installation

Install via [NuGet](https://www.nuget.org/packages/Avolutions.Baf.Blazor):

```bash
dotnet add package Avolutions.Baf.Blazor
```

## Quick Start

In your Program.cs, add BAF Blazor to the service collection and middleware pipeline.

```csharp
using Avolutions.Baf.Core.Modules.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register BAF Core with your DbContext
builder.Services.AddBafCore<ApplicationDbContext>()
  .AddBafBlazor();

var app = builder.Build();

// Initialize BAF Core
app.UseBafCore()
  .UseBafBlazor<App>();

app.Run();
```