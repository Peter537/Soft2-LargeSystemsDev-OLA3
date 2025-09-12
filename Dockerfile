FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CoreMoviePlayer/CoreMoviePlayer.csproj", "CoreMoviePlayer/"]
RUN dotnet restore "CoreMoviePlayer/CoreMoviePlayer.csproj"
COPY . .
WORKDIR "/src/CoreMoviePlayer"
RUN dotnet build "CoreMoviePlayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreMoviePlayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreMoviePlayer.dll"]