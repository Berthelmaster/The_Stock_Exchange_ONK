FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY Dist /app

WORKDIR /app

ENTRYPOINT ["dotnet", "StockShareProvider.dll"]