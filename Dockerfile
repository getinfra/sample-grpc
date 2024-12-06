# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:9.0-noble AS build
ARG APP_VER=0.0.0
ARG TARGETARCH
WORKDIR /source

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore

# RUN apk add node

RUN dotnet publish --no-restore -c Release -o /app /p:Version=${APP_VER}


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-noble-chiseled

# RUN apk add --no-cache \
#     icu-data-full \
#     icu-libs

EXPOSE 8081
ENV ASPNETCORE_URLS http://*:8081
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "getinfra.samples.grpc.dll"]
