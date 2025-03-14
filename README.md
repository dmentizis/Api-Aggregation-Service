# APIAggregationSolution

## Description
A scalable and efficient system that fetches data from various sources, aggregates it, and delivers it through a single API interface built in .NET 9.0.

## 1. Pre-requisites
In order to run this project, you need to install .NET version 9.0
https://dotnet.microsoft.com/en-us/download/dotnet/9.0
### 2. Configuration
In order for this solution run run properly, only the External API keys are required to be configured in the appsettings.json file. <br />
This repository contains API keys that have been already configured by the author. These api keys have been extracted from the services using disposable email addresses, so feel free to use them as you wish. <br /> <br />
Relative Path for the appsettings.json file: \APIAggregationSolution\API\appsettings.json. <br /> <br >
In case you want to append this project's functionality, you can get your own API keys from the integrated services' websites. <br > 
NewsApi: https://newsapi.org/ <br >
OpenWeatherMap: https://openweathermap.org/ <br >
OpenLibrary: https://openlibrary.org/developers/api
### 3. Endpoint Documentation
The endpoint documentation for this project has been entirely done on Swagger. <br /> <br />
A Swagger Page has been integrated inside the API project in order to implement dynamic documentation. <br /> <br />
Just make sure that the "launchBrowser" setting from the "launchSettings.json" file is set to "true" for whichever profile you are using to launch the API, and a browser window will pop up containing the Swagger documentaion page.
### 4. ProjectStructure
The API project has been designed with the Clean Architecture and SOLID principles in mind. <br /> <br />
The Project Consists of four separate layers:<br /> <br />
Objects: This is basically the equivilent to the "Domain" that is commonly implemented in Clean Architecture. In this layer, are implemented "Entity" objects that are the Business Logic entities and Data Transfer Objects (DTOs) which are
responsible for the data transfer between the application's layers and it's external intefaces (endpoint controllers and external service integrations). <br /> <br />
Services: Here the Integration with the external API Services is implemented <br /> <br />
BusinessLogic: This layer is responsible for all the logical processes and computations as well as it is responsible for transforming the DTOs to Entities and vise versa. 
This layer works also as an interface between the "Services" and the "Controllers" layers. <br /> <br />
Controllers: This is basically the application's interface for users to use and to integrate it's functionalities with other systems.
