FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SenderMQ/SenderMQ.csproj", "SenderMQ/"]
RUN dotnet restore "SenderMQ/SenderMQ.csproj"
COPY . .
WORKDIR "/src/SenderMQ"
RUN dotnet build "SenderMQ.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SenderMQ.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SenderMQ.dll"]