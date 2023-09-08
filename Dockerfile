# Stage 1: Build the ASP.NET Core application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NotesApi.csproj", "NotesApi/"]
RUN dotnet restore "NotesApi/NotesApi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "NotesApi/NotesApi.csproj" -c Release -o /app/build

# Stage 2: Publish the ASP.NET Core application
FROM build AS publish
RUN dotnet publish "NotesApi/NotesApi.csproj" -c Release -o /app/publish

# Stage 3: Build the NGINX stage
FROM nginx:latest AS nginx

# Copy your NGINX configuration file to the appropriate location
COPY nginx.conf /etc/nginx/nginx.conf

# Stage 4: Create the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose the port for your ASP.NET Core application
EXPOSE 8080

# Start NGINX and your ASP.NET Core application
CMD ["nginx", "-g", "daemon off;"]