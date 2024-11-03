# CUSTOMER BALANCE PLATFORM

A C# project that involves creating a simple application (API) for managing customer
records. This includes all CRUD operations on the CUstomer data.

## Key Attributes

Customer Repository:
Store customer details including name, description,
contact information, current balance and the last transaction date.

## Installation

### Prerequisites Installation

- Install .NET 6.0 SDK
  - `Download from: https://dotnet.microsoft.com/download/dotnet/6.0`

- Install SQL Server
  - `Download SQL Server Developer Edition from: https://www.microsoft.com/en-us/sql-server/sql-server-downloads`

### Project Setup

- Create new directory and navigate into it
  `mkdir CustomerBalancePlatform`
  `cd CustomerBalancePlatform`
  `dotnet new sln -n CustomerBalancePlatform` # Create solution

- Create new ASP.NET Core Web API project
  `dotnet new webapi -o CustomerBalancePlatform.Api`
  `dotnet sln add CustomerBalancePlatform.Api`

- Add Entity Framework in CustomerBalancePlatform.Api directory
  `cd CustomerBalancePlatform.Api`
  `dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0`
  `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0`
  `dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.0`
  `dotnet add package Swashbuckle.AspNetCore`

`
[
  {
    "customerNumber": "CUS10",
    "name": "John Doe",
    "description": null,
    "contactInfo": "johndoe@example.com",
    "currentBalance": 100.5,
    "lastTransactionDate": null
  }  
]
`

## Future Updates

- Audit Trail log to track updates and modification on Customer's data

## Database - SQL Server Instance

[image](Screenshot%202024-11-03%20at%206.10.18 AM.png)
