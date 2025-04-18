FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Romarr.Api/Romarr.Api.csproj", "Romarr.Api/"]
COPY ["src/Romarr.Application/Romarr.Application.csproj", "Romarr.Application/"]
COPY ["src/Romarr.Domain/Romarr.Domain.csproj", "Romarr.Domain/"]
COPY ["src/Romarr.Contracts/Romarr.Contracts.csproj", "Romarr.Contracts/"]
COPY ["src/Romarr.Infrastructure/Romarr.Infrastructure.csproj", "Romarr.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "Romarr.Api/Romarr.Api.csproj"
COPY . ../
WORKDIR /src/Romarr.Api
RUN dotnet build "Romarr.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Romarr.Api.dll"]