FROM mcr.microsoft.com/dotnet/sdk:5.0

RUN mkdir -p /usr/src
WORKDIR /usr/src

COPY Lusid.Sdk.sln /usr/src/
COPY Lusid.Sdk/Lusid.Sdk.csproj /usr/src/Lusid.Sdk/
COPY Lusid.Sdk.Tests/Lusid.Sdk.Tests.csproj /usr/src/Lusid.Sdk.Tests/
RUN dotnet restore Lusid.Sdk

ENV FBN_LUSID_API_URL ${FBN_LUSID_API_URL}

# ENTRYPOINT [ "/bin/bash" ]
ENTRYPOINT dotnet test -v n Lusid.Sdk.Tests