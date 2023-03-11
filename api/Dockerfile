FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./Harpoon/bin/Debug/net6.0/publish ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "Harpoon.dll"]