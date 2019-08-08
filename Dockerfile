FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ./NetApp3/*.csproj ./NetApp3/
RUN dotnet restore

# copy everything else and build app
COPY NetApp3/. ./NetApp3/
WORKDIR /app/NetApp3
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/NetApp3/out ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
