FROM microsoft/dotnet:latest

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN ["dotnet", "ef", "migrations", "add", "InitialMigration"]
RUN ["dotnet", "ef", "database", "update"]

EXPOSE 5000

ENTRYPOINT ["dotnet", "run"]