FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY ./build ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "Harpoon.dll"]