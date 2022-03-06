#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get install -f

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs

ENV BuildingDocker true

WORKDIR /src

RUN echo $(ls -1 /var/lib/docker/tmp/docker-builder.*/)

COPY ["DiscountCardApp/DiscountCardApp.csproj", "DiscountCardApp/"]
COPY ["DiscountCardApp.Application/DiscountCardApp.Application.csproj", "DiscountCardApp.Application/"]
COPY ["DiscountCardApp.Infrastructure/DiscountCardApp.Infrastructure.csproj", "DiscountCardApp.Infrastructure/"]
COPY ["DiscountCardApp.Domain/DiscountCardApp.Domain.csproj", "DiscountCardApp.Domain/"]
COPY ["DiscountCardApp.Common/DiscountCardApp.Common.csproj", "DiscountCardApp.Common/"]



RUN dotnet restore "DiscountCardApp/DiscountCardApp.csproj"
COPY . .
WORKDIR "/src/DiscountCardApp"
RUN dotnet build "DiscountCardApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscountCardApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT  ["dotnet", "DiscountCardApp.dll"]
#CMD ["dotnet", "DiscountCardApp.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet DiscountCardApp.dll