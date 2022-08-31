#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY SupplierMicroservice.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

From mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "SupplierMicroservice.dll"]
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY Chat_App.csproj .
#RUN dotnet restore
#COPY . .
#RUN dotnet publish -c release -o /app
#
#From mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build /app .
#ENTRYPOINT ["dotnet", "Chat_App.dll"]