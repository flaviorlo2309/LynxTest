#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TemplateEntity/Livros_API.csproj", "TemplateEntity/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Infraestructure/Infraestructure.csproj", "Infraestructure/"]
RUN dotnet restore "TemplateEntity/Livros_API.csproj"
COPY . .
WORKDIR "/src/TemplateEntity"
RUN dotnet build "Livros_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Livros_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Change timezone to local time
ENV TZ=Brazil/East
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN apk add --no-cache tzdata


ENTRYPOINT ["dotnet", "Livros_API.dll"]