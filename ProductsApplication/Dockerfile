FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5147

ENV ASPNETCORE_URLS=http://+:5147

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/ProductsApplication.csproj", "./"]
RUN dotnet restore "./ProductsApplication.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ProductsApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsApplication.dll"]
