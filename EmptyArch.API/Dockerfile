FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["EmptyArch.API/EmptyArch.API.csproj", "EmptyArch.API/"]
RUN dotnet restore "EmptyArch.API/EmptyArch.API.csproj"
COPY . .
WORKDIR "/src/EmptyArch.API"
RUN dotnet build "EmptyArch.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmptyArch.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmptyArch.API.dll"]