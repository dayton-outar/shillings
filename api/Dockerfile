FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

ENV HARPOON_DB_DB stocks
ENV HARPOON_DB_HST localhost
ENV HARPOON_DB_PRT 1433
ENV HARPOON_DB_USR sa
ENV SHILLINGS_DOMAIN https://shillings.info
ENV HARPOON_DOMAIN https://api.shillings.info
ENV HARPOON_DB_PWD Password77

COPY ./Harpoon/bin/Debug/net6.0 ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Harpoon.dll"]