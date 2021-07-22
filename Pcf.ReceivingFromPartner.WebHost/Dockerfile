FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Pcf.ReceivingFromPartner.WebHost/Pcf.ReceivingFromPartner.WebHost.csproj", "Pcf.ReceivingFromPartner.WebHost/"]
COPY ["Pcf.ReceivingFromPartner.Core/Pcf.ReceivingFromPartner.Core.csproj", "Pcf.ReceivingFromPartner.Core/"]
COPY ["Pcf.ReceivingFromPartner.DataAccess/Pcf.ReceivingFromPartner.DataAccess.csproj", "Pcf.ReceivingFromPartner.DataAccess/"]
COPY ["Pcf.ReceivingFromPartner.UnitTests/Pcf.ReceivingFromPartner.UnitTests.csproj", "Pcf.ReceivingFromPartner.UnitTests/"]
COPY ["Pcf.ReceivingFromPartner.Integration/Pcf.ReceivingFromPartner.Integration.csproj", "Pcf.ReceivingFromPartner.Integration/"]
RUN dotnet restore "Pcf.ReceivingFromPartner.WebHost/Pcf.ReceivingFromPartner.WebHost.csproj"
COPY . .
WORKDIR "/src/Pcf.ReceivingFromPartner.WebHost"
RUN dotnet build "Pcf.ReceivingFromPartner.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pcf.ReceivingFromPartner.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pcf.ReceivingFromPartner.WebHost.dll"]
