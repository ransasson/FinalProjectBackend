#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base

# Install Python and required packages
RUN apt update && apt install -y python3 python3-pip
RUN pip3 install tensorflow numpy scikit-learn

# Add Python to PATH
ENV PATH="/usr/bin/python:${PATH}"

# Create a symbolic link from python to python3
RUN ln -s /usr/bin/python3 /usr/bin/python

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FinalProjectAPI/FinalProjectAPI.csproj", "FinalProjectAPI/"]
COPY ["FinalProjectService.API/FinalProjectService.API.csproj", "FinalProjectService.API/"]
COPY ["FinalProjectContract/FinalProjectContract.csproj", "FinalProjectContract/"]
RUN dotnet restore "FinalProjectAPI/FinalProjectAPI.csproj"
COPY . .
WORKDIR "/src/FinalProjectAPI"
RUN dotnet build "FinalProjectAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinalProjectAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinalProjectAPI.dll"]