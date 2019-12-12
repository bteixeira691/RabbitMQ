FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ReceverMQ/ReceverMQ.csproj", "ReceverMQ/"]
RUN dotnet restore "ReceverMQ/ReceverMQ.csproj"
COPY . .
WORKDIR "/src/ReceverMQ"
RUN dotnet build "ReceverMQ.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ReceverMQ.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ReceverMQ.dll"]