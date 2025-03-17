FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY PaymentCalculation.Base/*.csproj ./PaymentCalculation.Base/
COPY PaymentCalculation.CLI/*.csproj ./PaymentCalculation.CLI/
COPY *.sln ./
RUN dotnet restore

COPY PaymentCalculation.Base/. ./PaymentCalculation.Base/
COPY PaymentCalculation.CLI/. ./PaymentCalculation.CLI/

RUN dotnet publish PaymentCalculation.CLI -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "PaymentCalculation.CLI.dll"]