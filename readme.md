# lineten_adapters_inbevtex

A custom in bound adapter for InBev. The request will come from their VTex System.

## Prerequisites

- dotnet cli

## Database Migrations

Change directory to `src\lineten_adapters_inbevtex.Data`

`dotnet ef migrations add "your migration name"`

`dotnet ef database update`

`dotnet ef migrations remove -f`

If you want to change database provider - i.e from MySql to something else, first make sure you remove references to `.UseMySql(..)` and swap to your preferred provider, then remove all files from the `Migrations` including the snapshot and recreate the initial migration using the first command above

## Additional projects

E.g. If you wish to add a UI project to this repository, create another director in the root called `ui` and place you `Docker` file in there.

Modify the `docker-compose.yml` file to build that docker file as appropriate

If you have additional back end services that you'd like to host, create those new back end projects in the `src` folder.

## Docker images

run `docker-compose up` in the root folder to start the application.

Instruct you CI pipeline to use the `Dockerfile.tests` file to allow extraction of test results and code coverage.

From the root folder run:

`docker build src -f src/lineten_adapters_inbevtex.Api/Dockerfile.tests`

You can also run:

`docker build src -f src/lineten_adapters_inbevtex.Api/Dockerfile`

to skip tests and just build the image.
