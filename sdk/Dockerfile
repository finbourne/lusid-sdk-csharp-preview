FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN mkdir -p /usr/src

COPY run.sh /usr/src/
COPY Lusid.Sdk.sln /usr/src/
COPY Lusid.Sdk/ /usr/src/Lusid.Sdk/
COPY LusidFeatureReporter/ /usr/src/LusidFeatureReporter/
COPY Lusid.Sdk.Tests/ /usr/src/Lusid.Sdk.Tests/


ENV FBN_LUSID_API_URL ${FBN_LUSID_API_URL}

RUN ["chmod", "+x", "/usr/src/run.sh"]
ENTRYPOINT ["./run.sh"]