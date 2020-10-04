FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AdreaniExam/AdreaniExam.csproj", "AdreaniExam/"]
COPY ["AdreaniExam.DataTransferObjects/AdreaniExam.DataTransferObjects.csproj", "AdreaniExam.DataTransferObjects/"]
COPY ["AdreaniExam.DataTransferObjects.Factories/AdreaniExam.DataTransferObjects.Factories.csproj", "AdreaniExam.DataTransferObjects.Factories/"]
COPY ["AdreaniExam.Interactors/AdreaniExam.Interactors.csproj", "AdreaniExam.Interactors/"]
COPY ["AdreaniExam.Models/AdreaniExam.Models.csproj", "AdreaniExam.Models/"]
COPY ["AdreaniExam.Repositories/AdreaniExam.Repositories.csproj", "AdreaniExam.Repositories/"]
COPY ["AdreaniExam.Repositories.EntityFramework/AdreaniExam.Repositories.EntityFramework.csproj", "AdreaniExam.Repositories.EntityFramework/"]
RUN dotnet restore "AdreaniExam/AdreaniExam.csproj"
COPY . .
WORKDIR "/src/AdreaniExam"
RUN dotnet build "AdreaniExam.csproj" -c Debug -o /app/build
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

FROM build AS publish
RUN dotnet publish "AdreaniExam.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdreaniExam.dll"]

#TODO dockerizar geolocalizador service.