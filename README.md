# CUSTOMER BALANCE PLATFORM

## Overview

The Customer Balance Platform API is a .NET Core API application designed to manage customer records. It provides CRUD operations for customer data, including the ability to retrieve customers with pagination, update records, and log actions via an audit trail. The API is documented with Swagger, making it easy to explore and test each endpoint.

## Features

- CRUD operations for customer records.
- Pagination support for listing customers.
- Audit trail for logging actions.
- API documentation and testing interface with Swagger.

## Prerequisites

- [.NET 6 or higher](https://dotnet.microsoft.com/download/dotnet)
- [Docker](https://docker.com) (for SQL Server setup)
- SQL Server 2019 or above (via Docker or standalone)

## Setup

1. Clone the Repository

  ```shell
  git clone https://github.com/Esekyi/CustomerBalancePlatform.git
  cd CustomerBalancePlatform
  ```

2. Set Up SQL Server with Docker
Run the following command to start SQL Server in a Docker container:

```bash
docker pull mcr.microsoft.com/azure-sql-edge
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=P@ssw0rd123' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
```

3. Configure the Database Connection

In `appsettings.json`, update the connection string to match your SQL Server setup:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=CustomerBalanceDB;User Id=sa;Password=P@ssw0rd123;"
}
```

4. Apply Database Migrations

Run the following command to create the database and apply migrations:

```bash
dotnet ef database update
```

5. Run the Application

Start the application with:

```bash
dotnet run
```

The API should be available at:

- <http://localhost:5090>
- <https://localhost:7046>

## API Documentation

Swagger UI is available to explore and test the API.

1. Open a browser and navigate to <http://localhost:5090>.
2. Use Swagger UI to test endpoints, view request and response formats, and see example data.

### API Endpoints

| Method     | Endpoint                           | Description                       |
| ---------- |:----------------------------------:| ---------------------------------:|
| GET        | /api/v1/customers                  | Get a paginated list of customers |
| GET        | /api/v1/customers/{customerNumber} | details of a specific customer    |
| POST       | /api/v1/customers                  |    Create a new customer          |
| PUT        | /api/v1/customers/{customerNumber} | Update an existing customer       |
| DELETE     | /api/v1/customers/{customerNumber} | Delete a customer                 |

### Example Request and Response

**POST** `/api/v1/customers`

**Request Body**:

```json
{
    "customerNumber": "CUS900",
    "name": "John Doe",
    "description": "Frequent buyer",
    "contactInfo": "johndoe@example.com",
    "currentBalance": 100.50
}
```

**Response**:

```json
{
    "customerNumber": "CUS900",
    "name": "John Doe",
    "description": "Frequent buyer",
    "contactInfo": "johndoe@example.com",
    "currentBalance": 100.50,
    "lastTransactionDate": null
}
```

### Testing and Validation

Using Swagger UI

1. Open Swagger UI at <http://localhost:5090>.
2. Click on each endpoint to expand it.
3. Use the "Try it out" feature to test CRUD operations.

## Future Updates

- Audit Trail log to track updates and modification on Customer's data

## Database - SQL Server Instance

![SQL Server Instamce image](Screenshot%202024-11-03%20at%206.10.18 AM.png)
