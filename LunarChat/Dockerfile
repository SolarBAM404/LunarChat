FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["LunarChat/LunarChat.csproj", "LunarChat/"]
RUN dotnet restore "LunarChat/LunarChat.csproj"
COPY . .
WORKDIR "/src/LunarChat"
RUN dotnet build "LunarChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LunarChat.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LunarChat.dll"]
