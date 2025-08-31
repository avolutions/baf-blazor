# Avolutions BAF Blazor

[![NuGet Version](https://img.shields.io/nuget/v/Avolutions.Baf.Blazor)](https://www.nuget.org/packages/Avolutions.Baf.Blazor)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Avolutions.Baf.Blazor)](https://www.nuget.org/packages/Avolutions.Baf.Blazor)

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
using Avolutions.Baf.Blazor.Modules.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register BAF Blazor with your DbContext
builder.Services.AddBafCore<ApplicationDbContext>()
  .AddBafBlazor();

var app = builder.Build();

// Initialize BAF Blazor
app.UseBafCore()
  .UseBafBlazor<App>();

app.Run();
```