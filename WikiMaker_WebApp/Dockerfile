#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["WikiMaker_WebApp/WikiMaker_WebApp.csproj", "WikiMaker_WebApp/"]
RUN dotnet restore "WikiMaker_WebApp/WikiMaker_WebApp.csproj"
COPY . .
WORKDIR "/src/WikiMaker_WebApp"
RUN dotnet build "WikiMaker_WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WikiMaker_WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WikiMaker_WebApp.dll"]