![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/at0dd/tesla-api/.github/workflows/dotnet.yml?branch=main)
![Release Version](https://img.shields.io/github/v/release/at0dd/tesla-api)
![Nuget Version](https://img.shields.io/nuget/v/tesla-api)
![Nuget Downloads](https://img.shields.io/nuget/dt/tesla-api)

# C# Tesla API Client

This is an unofficial .NET client for the Tesla Owner API, the JSON API used by the Tesla Android and iOS apps. It covers vehicle data, vehicle commands and energy sites (Powerwall and solar).

> **Important:** Tesla doesn't support the Owner API, and it can change without notice. Most vehicles reject commands sent through it, such as unlocking or starting climate, with a 403 ("Tesla Vehicle Command Protocol required"), because Tesla has required signed commands since 2024. Pre-2021 Model S and X are the documented exception. Community projects report that reading vehicle and energy site data still works.

[Tim Dorr API Documentation](https://tesla-api.timdorr.com/)

[API Documentation GitHub](https://github.com/timdorr/tesla-api)

# Installation

## .NET CLI
```ps1
dotnet add package 'Tesla-API'
```

# Setup

## Dependency Injection

When registering your services, call the method below to allow all required services to be dependency injected.
```c#
services.AddTeslaApi();
```

# Usage

Every method takes the `HttpClient` to send the request with. Set a `User-Agent` header that identifies your application, and an `Authorization` header with your access token.

## Authenticating with Tesla

Follow the OAuth process [documented by Tim Dorr](https://tesla-api.timdorr.com/api-basics/authentication) to get an access token. The [TeslaAuth](https://github.com/tomhollander/TeslaAuth/) package implements it in .NET. Use `RefreshTokenAsync` to get a new access token when the current one expires.

# Example Code

```c#
public class TeslaService
{
    private readonly ITeslaAPI _teslaAPI;
    private readonly HttpClient _client = new HttpClient();

    public TeslaService(ITeslaAPI teslaAPI, string accessToken)
    {
        _teslaAPI = teslaAPI;
        _client.DefaultRequestHeaders.Add("User-Agent", "MyApplication");
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
    }

    /// <summary>
    /// Get all vehicles in the user's account.
    /// </summary>
    public Task<List<Vehicle>> GetVehiclesAsync()
    {
        return _teslaAPI.GetAllVehiclesAsync(_client);
    }

    /// <summary>
    /// Get a vehicle's charge, climate, drive and vehicle state.
    /// </summary>
    public Task<VehicleData> GetVehicleDataAsync(string vehicleID)
    {
        return _teslaAPI.GetVehicleDataAsync(_client, vehicleID);
    }
}
```

# Tests

Run the tests with `dotnet test --solution TeslaAPI.sln`. They use [TUnit](https://tunit.dev).

No test calls the Tesla API, so they need no Tesla account or access token. Each test sends its request through a stub `HttpMessageHandler`, then checks the URL, method and body, or parses a canned response. Responses recorded from the real API live in `tests/responses`. CI runs the tests on every push and pull request.
