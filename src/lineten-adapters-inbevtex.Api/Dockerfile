#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["lineten_adapters_inbevtex.Api/lineten_adapters_inbevtex.Api.csproj", "lineten_adapters_inbevtex.Api/"]
RUN dotnet restore "lineten_adapters_inbevtex.Api/lineten_adapters_inbevtex.Api.csproj"
COPY . .
WORKDIR "/src/lineten_adapters_inbevtex.Api"
RUN dotnet build "lineten_adapters_inbevtex.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lineten_adapters_inbevtex.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lineten_adapters_inbevtex.Api.dll"]