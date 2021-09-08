FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV ARG1=default

WORKDIR /App
COPY ./bin/release/net5.0/publish/ .
COPY ./texts/ /

ENTRYPOINT ["dotnet", "WordSequenceFinder.dll"]
CMD ["/moby-dick.txt"]
