# receipt-information-system
This is for management receipt information that company had and for store every receipt with steps

## Tools
.NET 8
PostgreSQL

## Schema Database
* Recipe (Parent Table)
* StepRecipe (Children 1 that had relation with Recipe and ParameterSteps)
* ParameterSteps (Children 2 that contains more detail about parameter each Step)

* ParameterType (Master data for ParameterSteps)

# Steps to run Project
## Download and Install .NET 8 SDK From
https://dotnet.microsoft.com/download/dotnet/8.0

## Clone this repository
## Create App Setting
Duplicate appsettings.Development.Json
Rename to appsettings.json
Update variable "DefaultConnection" with your PostgreSQL Credential

## Install dependencies
dotnet restore

## Run Database Migration
dotnet tool intsall --global dotnet-ef (if didnt have dotnet ef)
dotnet ef database update 

## Build and run project
dotnet build
dotnet run

## Access API
* Swagger UI: {url}/swagger 
* API Endpoints: {Url}/api

Find url configuration at properties/launchSettings.json