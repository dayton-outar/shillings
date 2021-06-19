FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY ./build ./
EXPOSE 5000
EXPOSE 5001
ENV ASPNETCORE_URLS http://0.0.0.0:5000
ENTRYPOINT ["dotnet", "Harpoon.dll"]