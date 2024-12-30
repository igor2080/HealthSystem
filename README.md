# Health system

A system for diagnostics and health improvement recommendations using a person's biological indicators.

## Installation

### Prerequisites

This software requires .NET 8 to run, .Net 8 can be found here: 

[https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

Tested with SDK version 8.0.307 and runtime version 8.0.11

### Install steps

1. Clone or download the repository.
2. navigate to the folder that contains the solution file(.sln), it should be under HealthSystemProject\HealthSystem
3. Build the project:
```cmd
dotnet build
```
4. Create the database: If using visual studio, open up the package manager console and run the ``update-database`` command.
If using the .NET cli, installation of the EF core tools is required first. Installation instructions can be found [here](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Once the tools are installed, navigate to the same folder as in step 2 and run the ``dotnet ef database update`` command.
5. Publish the project:
```cmd
dotnet publish
```
Note: after publishing the project, the database does not get copied over in order to prevent overwrites, move the HealthSystem.db file to the publish directory manually.

6. Run the project: Navigate to the publish folder. By default, it should be ``HealthSystemProject\HealthSystem\bin\Release\net8.0\publish``. If the database file has not been moved yet, it should be placed under ``HealthSystemProject\HealthSystem\bin\Release\net8.0\publish\Data`` with the name HealthSystem.db. Either manually run the exe, or run the following command from the dotnet CLI:
```cmd
dotnet HealthSystem.dll
```
