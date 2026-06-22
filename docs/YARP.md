# YARP

Use **YARP** if you want a .NET-native gateway. Microsoft describes YARP as a customizable reverse proxy library for .NET. ([Microsoft Learn][1])

Basic architecture:

```text
Client / Mobile / Web
        |
        v
API Gateway
        |
        +--> Customer API
        +--> Job API
        +--> Payment API
        +--> Reporting API
```

Core gateway responsibilities:

```text
Authentication
Authorization
Routing
Rate limiting
Request/response logging
Header forwarding
Load balancing
Version routing
Central error handling
```

Minimal YARP setup:

```bash
dotnet new web -n ApiGateway
cd ApiGateway
dotnet add package Yarp.ReverseProxy
```

`Program.cs`

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.Run();
```

`appsettings.json`

```json
{
  "ReverseProxy": {
    "Routes": {
      "customer-route": {
        "ClusterId": "customer-api",
        "Match": {
          "Path": "/customers/{**catch-all}"
        }
      },
      "jobs-route": {
        "ClusterId": "jobs-api",
        "Match": {
          "Path": "/jobs/{**catch-all}"
        }
      }
    },
    "Clusters": {
      "customer-api": {
        "Destinations": {
          "destination1": {
            "Address": "https://localhost:7001/"
          }
        }
      },
      "jobs-api": {
        "Destinations": {
          "destination1": {
            "Address": "https://localhost:7002/"
          }
        }
      }
    }
  }
}
```

Then calls work like:

```text
https://gateway.com/customers/123  -> Customer API
https://gateway.com/jobs/456       -> Job API
```

For production, add:

```csharp
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapReverseProxy();
```

ASP.NET Core has built-in rate limiting middleware for controlling request volume. ([Microsoft Learn][2])

My recommendation:

For your case, use:

```text
YARP + ASP.NET Core Auth + Rate Limiting + Serilog/OpenTelemetry
```

Avoid building everything from scratch. Build only the rules specific to your business: routing, tenant rules, API keys, audit logs, and access control.

[1]: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/yarp/yarp-overview?view=aspnetcore-10.0&utm_source=chatgpt.com "Overview of YARP"
[2]: https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-10.0&utm_source=chatgpt.com "Rate limiting middleware in ASP.NET Core"
