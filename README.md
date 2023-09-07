
# Note-API

A robust `.NET 7` application designed to manage notes. The application is backed by a PostgreSQL database running in Docker and comes with built-in Google Analytics support.

## Features

- **Database**: Utilizes PostgreSQL as its primary data store.
- **Docker Support**: The PostgreSQL database runs within a Docker container for easy setup and portability.
- **Google Analytics**: Integrated with Google Analytics to monitor and analyze application usage.
- **Entity Framework**: Leverages the power of Entity Framework for ORM capabilities.
- **Database Migrations**: Uses EF migrations to create and evolve the database schema.
- **Swagger UI**: Provides an interactive API documentation and testing interface.

## Prerequisites

- `.NET SDK 7.0` or later
- `Docker` & `Docker Compose`
- Google Analytics account (optional, if you want to monitor app usage)

## Setup and Running

### Database Setup

1. Navigate to the project root directory.
2. Run the following command to start the PostgreSQL container:
   ```bash
   docker run --name postgres-fabio-interview -p 5432:5432 -e POSTGRES_PASSWORD=mysecretpassword -d postgres
   ```

### Running the Application

1. Navigate to the project root directory.
2. Restore the necessary NuGet packages:
   ```bash
   dotnet restore
   ```

3. Apply the database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Once the application starts, you can access the Swagger UI at:
   ```
   https://localhost:7215/swagger/index.html
   ```

## Google Analytics Integration

To integrate Google Analytics, you'll need to configure your tracking code in the application settings.

## Contributing

If you find any issues or have suggestions, please open an issue in the repository.

## License

This project is licensed under the MIT License. Refer to `LICENSE` file for more details.
