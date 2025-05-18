# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia arquivos da solução e restaura dependências
COPY *.sln .
COPY FastFood.Domain/FastFood.Domain.csproj ./FastFood.Domain/
COPY FastFood.Application/FastFood.Application.csproj ./FastFood.Application/
COPY FastFood.Infrastructure/FastFood.Infrastructure.csproj ./FastFood.Infrastructure/
COPY FastFood.Tests/FastFood.Tests.csproj ./FastFood.Tests/
COPY FastFood.Api/FastFood.Api.csproj ./FastFood.Api/

RUN dotnet restore

# Copia o restante do código e compila
COPY . .
WORKDIR /src/FastFood.Api
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FastFood.Api.dll"]
