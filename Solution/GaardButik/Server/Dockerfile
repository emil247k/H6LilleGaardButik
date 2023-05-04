#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM postgres
ENV POSTGRES_DB gaardbutikDB
ENV POSTGRES_USER gaardbutik
ENV POSTGRES_PASSWORD gaardbutik123

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/GaardButik.Server.csproj", "Server/"]
COPY ["Client/GaardButik.Client.csproj", "Client/"]
COPY ["Shared/GaardButik.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/GaardButik.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "GaardButik.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GaardButik.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GaardButik.Server.dll"]