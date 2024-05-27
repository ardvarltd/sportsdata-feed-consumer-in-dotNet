FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Sportsdata.Consumer.Feed/Sportsdata.Consumer.Feed.csproj", "Sportsdata.Consumer.Feed/"]
COPY ["Sportsdata.Consumer.Common/Sportsdata.Consumer.Common.csproj", "Sportsdata.Consumer.Common/"]
RUN dotnet restore "Sportsdata.Consumer.Feed/Sportsdata.Consumer.Feed.csproj"
COPY . .
WORKDIR "/src/Sportsdata.Consumer.Feed"
RUN dotnet build "Sportsdata.Consumer.Feed.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sportsdata.Consumer.Feed.csproj" -c Release -o /app/publish

ENV SETTINGS "asd"
ENV WORKER	"asda"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sportsdata.Consumer.Feed.dll"]