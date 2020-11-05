FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Programatica.AspNetCore31AppSkeleton/*.csproj ./Programatica.AspNetCore31AppSkeleton/
COPY Programatica.AspNetCore31AppSkeleton.Data/*.csproj ./Programatica.AspNetCore31AppSkeleton.Data/
COPY Programatica.AspNetCore31AppSkeleton.Data.Migrations/*.csproj ./Programatica.AspNetCore31AppSkeleton.Data.Migrations/
COPY Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap/*.csproj ./Programatica.AspNetCore31AppSkeleton.Data.Migrations.Bootstrap/ 

RUN dotnet restore 

# copy everything else and build app
COPY Programatica.AspNetCore31AppSkeleton/. ./Programatica.AspNetCore31AppSkeleton/
COPY Programatica.AspNetCore31AppSkeleton.Data/. ./Programatica.AspNetCore31AppSkeleton.Data/
COPY Programatica.AspNetCore31AppSkeleton.Data.Migrations/. ./Programatica.AspNetCore31AppSkeleton.Data.Migrations/ 

WORKDIR /app/Programatica.AspNetCore31AppSkeleton
RUN dotnet publish -c Release -o out 

FROM base AS final
WORKDIR /app 

COPY --from=build /app/Programatica.AspNetCore31AppSkeleton/out ./
ENTRYPOINT ["dotnet", "Programatica.AspNetCore31AppSkeleton.dll"]
