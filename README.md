# AirbnbWebapi
Airbnb WebAPI
Welcome to the Airbnb WebAPI project! This backend component serves as the API for the Airbnb application. It is built using C# .NET Core and provides endpoints for managing users, roles, authentication, customer data, and other functionalities required for the Airbnb platform.

## Overview
This application serves as the backend for the Airbnb platform, providing RESTful API endpoints for interacting with various resources including users, roles, customer data, and authentication.

## Technologies Used
- C# .NET Core: A cross-platform, open-source framework for building modern, cloud-based applications.
- Entity Framework Core: An Object-Relational Mapping (ORM) framework that simplifies database interaction in .NET applications.
- ASP.NET Core Identity: Provides user authentication and authorization functionality.
- JWT Authentication: JSON Web Tokens are used for secure authentication.
- Swagger: Used for generating API documentation and interactive API documentation (Swagger UI) for ASP.NET Core applications.
- SQLite: A lightweight, file-based SQL database engine used for storing application data.

## API Management
### Roles Management
- GET http://localhost:5080/api/RolesC: Retrieve all roles.
- GET http://localhost:5080/api/RolesC/{roleId}: Retrieve a specific role by ID.
- POST http://localhost:5080/api/RolesC: Create a new role.
- PUT http://localhost:5080/api/RolesC: Update an existing role.
- DELETE http://localhost:5080/api/RolesC/{roleId}: Delete a role by ID.
- POST http://localhost:5080/api/RolesC/assign-role-to-user: Assign a role to a user.
### User Authentication and Registration:
- POST http://localhost:5080/api/Account/Register: User Register.
- POST http://localhost:5080/api/Account/Login: User authentication.

### Customer Operations:
- GET http://localhost:5080/api/customer: Retrieve all customer data.
- GET http://localhost:5080/api/customer/{customerId}: Retrieve a specific customer by ID.
- POST http://localhost:5080/api/customer: Create a new customer.
- PUT http://localhost:5080/api/customer/{customerId}: Update an existing customer.
- DELETE http://localhost:5080/api/customer/{customerId}: Delete a customer by ID.
#### These endpoints allow clients to interact with the Airbnb WebAPI and perform various operations related to roles, user authentication, and customer management.

## Packages Used
#### The following packages and libraries are used in this project:

- Microsoft.AspNetCore.Identity
   - Provides functionality for managing users, roles, and authentication in ASP.NET Core applications.

- Microsoft.EntityFrameworkCore
   - Entity Framework Core is an Object-Relational Mapping (ORM) framework that simplifies database interaction in .NET applications.

- Airbnb.Models
   - This is likely a custom namespace for your application's data models or entities.

- Microsoft.AspNetCore.Authentication.JwtBearer
   - Enables JWT (JSON Web Token) authentication for ASP.NET Core applications. It allows you to secure your API endpoints using JWT tokens.

- Microsoft.IdentityModel.Tokens
   - Provides classes and utilities for working with security tokens, including JWT tokens.

- System.Text
   - Provides classes and utilities for working with text encoding and decoding, which is used for handling strings and byte arrays.

- Swashbuckle.AspNetCore.Swagger
   - Used for generating API documentation and interactive API documentation (Swagger UI) for ASP.NET Core applications.

- Microsoft.Extensions.DependencyInjection
   - Provides classes and utilities for configuring and managing dependency injection in ASP.NET Core applications.

-Microsoft.Extensions.Configuration
   - Provides functionality for configuring and accessing application settings and configuration values in ASP.NET Core applications.

- Microsoft.AspNetCore.Builder
   - Provides classes for building the request processing pipeline in ASP.NET Core applications.

- Microsoft.AspNetCore.Http
   - Provides classes and utilities for working with HTTP requests and responses in ASP.NET Core applications.

#### These packages provide the necessary functionality for building a secure and scalable WebAPI application in C# .NET Core.

## Setup Instructions
To set up the application locally, follow these steps:

Clone the repository to your local machine:

- git clone https://github.com/Gaurang58/AirbnbWebapi.git
Navigate to the project directory:

- cd AirbnbWebapi
Install dependencies:

- dotnet restore
Configure the Database Connection:

- Ensure that you have a valid connection string for your database in the appsettings.json file.
  
- Run Migrations:
   - dotnet ef database update
Build the project:
   - dotnet build
Run the application:
   - dotnet run

## Deployment

The Airbnb WebAPI project has been successfully deployed on Microsoft Azure.

Link for the deployed application:

https://airbnb20240306014720.azurewebsites.net

Testing link for application:

https://airbnb20240306014720.azurewebsites.net/weatherforecast

This link allows you to interact with the live version of the application, including testing endpoints and exploring functionality.



## Additional Notes
This project is intended as a starting point for building more complex WebAPIs. Feel free to extend and customize it according to your project requirements.
Ensure to handle security, validation, and error handling appropriately when building production-ready APIs.
Explore additional features and middleware available in ASP.NET Core to enhance the functionality and performance of your WebAPI.
