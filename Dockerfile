FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["/NotesApi.csproj", "NotesApi/"]
RUN dotnet restore "NotesApi/NotesApi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "NotesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "NotesApi_v1.0.0.dll"]