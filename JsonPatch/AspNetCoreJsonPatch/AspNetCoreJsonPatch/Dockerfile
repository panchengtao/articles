FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY AspNetCoreJsonPatch/AspNetCoreJsonPatch.csproj AspNetCoreJsonPatch/
RUN dotnet restore AspNetCoreJsonPatch/AspNetCoreJsonPatch.csproj
COPY . .
WORKDIR /src/AspNetCoreJsonPatch
RUN dotnet build AspNetCoreJsonPatch.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AspNetCoreJsonPatch.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspNetCoreJsonPatch.dll"]
