FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

RUN apk add --no-cache bash curl procps unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

COPY ["src/Romarr.Api/Romarr.Api.csproj", "src/Romarr.Api/"]
COPY ["src/Romarr.Application/Romarr.Application.csproj", "src/Romarr.Application/"]
COPY ["src/Romarr.Domain/Romarr.Domain.csproj", "src/Romarr.Domain/"]
COPY ["src/Romarr.Contracts/Romarr.Contracts.csproj", "src/Romarr.Contracts/"]
COPY ["src/Romarr.Infrastructure/Romarr.Infrastructure.csproj", "src/Romarr.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]

WORKDIR /app
RUN dotnet restore "src/Romarr.Api/Romarr.Api.csproj"

COPY . .

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001

WORKDIR /app/src/Romarr.Api
ENTRYPOINT ["dotnet", "watch", "--project", "Romarr.Api.csproj", "--urls", "http://0.0.0.0:5001"]