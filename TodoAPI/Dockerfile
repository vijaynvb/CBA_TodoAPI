﻿# Use the official .NET 8 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET 8 runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "todoapi.dll"]

# Label the image
LABEL maintainer="vijaynvb"

# Set the image name
ARG IMAGE_NAME=vijaynvb/todoapi:latest
