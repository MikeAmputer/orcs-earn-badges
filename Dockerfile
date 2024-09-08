FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

COPY . ./
RUN dotnet publish ./Action/Action.csproj -c Release -o /app/out --no-self-contained

LABEL maintainer="Pavel Kravtsov <kravtsovpo@gmail.com>"
LABEL repository="https://github.com/MikeAmputer/orcs-earn-badges"
LABEL homepage="https://github.com/MikeAmputer/orcs-earn-badges"

LABEL com.github.actions.name="Orcs Have Issues Profile Badges"
LABEL com.github.actions.description="A GitHub action that tracks orcs-have-issues game achievements and adds badges to a profile readme."
LABEL com.github.actions.icon="award"
LABEL com.github.actions.color="red"

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT [ "dotnet", "Action.dll" ]