![MonetizAction](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/v0.0.4-English.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0 "Monetize Actions")

Experience a question-and-answer game where users can earn real money by predicting outcomes.

- When the **action happens**, the prize pool is distributed among all correct participants.
- If the **action doesn’t happen**, the winnings go to the company.

Every prediction is linked to real-time events from live TV shows or streaming, delivering an engaging and interactive way to play.

![Screens](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Random.jpg&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

#See in Action
- [Home](https://www.loom.com/embed/d858a2bc217949589847a1ec939a7737?sid=53a6d4a3-85f6-48bb-bb36-78688c76f941)
- [Lobby / Activities / Shopping](https://www.loom.com/embed/d388d4ef1c6749ec9037cdc3e21f4228?sid=500ea5ca-a927-415c-a8fd-1197a110dcd7)
- [Room](https://www.loom.com/embed/f0c3c06d8e5746b5918f6b64d1bce459?sid=37af9d16-f764-4df6-8b87-037cdf9685b0)
- [Purchase](https://www.loom.com/embed/90b9640f75614913b19abc5461ede37b?sid=637a7ba9-5531-418e-ac6c-283c1777f8c8)
- [Withdraw](https://www.loom.com/embed/ba618c66f298471d8430c16d12de8b65?sid=f7628e15-a663-44c1-909c-22c3c504ad77)
- [MailCatcher / Sign Up](https://www.loom.com/embed/86f3bfc3f26f4e48be81799987459c2f?sid=0e9d3c7b-65a3-4bdc-8237-aa88a125a844)

#Specifications
Communication will be based on restful concepts throught the JSON data, no extra execution proccess is allowed or used in this version (cron, broker, queue, interop, rpc...).

Everythins must be simpler and straight to the point, the main restriction is the cloud bill cost for the first version, that will be a MVP with incremental directions based on the business evolution.

Executions must follow the user interaction, no automatic execution is used due to the complexity inclusion at this moment.

![Deployment](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Architecture.jpg&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

Back end was build in .Net Core based on a simples architecture style of client / server following some vertical concepts on its dependencies.

C Sharp (C#) was the Asp.Net Core language to express every business requirements based on Object Orientation Programming style with small Functional concepts.

Front end was built in React Native + Expo due to the future releases and possible native app development, but the first release will be 100% web browser.

![Arena](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Room.jpg&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

Typescript is the main language for back end project, to express clearly every single line of the code and follow best principles for the industry, on this case function programming is the style used.

No boilerplate / library (tailwind, material, bootstrap…) is used, just simplest flexbox for CSS.

Focused on this MVP a monolith with a lowest cost on production providers (cloud, prem).

![Core Projects](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Core-Projects.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

#Backend
![API](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Api.webp&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

## Architecture
https://youtu.be/LvsvttbihEI

## Solution
![BE](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/BE-Solution.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

## Command
- Run the command
	- ``dotnet run / watch``
- Open the documentation
	- ``http://localhost:5171/swagger/index.html``
- Api base address
	- ``http://localhost:5171``
- Deploy
	- ``dotnet publish -c Release``
	- ``Visual Studio right click menu context``

#Frontend
![APP](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/App.webp&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

## Architecture
https://youtu.be/za1F8jSitmo

## Solution
![FE](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/FE-Solution.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

## Command
- Attach the production variables
	- ``SET ENV_FILE=.env``
	- ``SET ENV_FILE=.env.production``
- Run the command with cache cleared
	- ``npx expo start -c --web``
	- ``npx expo export --platform web``
- Open the application
	- ``http://localhost:8081``
- Folder to deploy
	- ``cd dist``

##Workflow
| Requirement | Startup | Conclusion |
|----------|:-------------:|------:|
| [Purchase](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Purchase-Use-Case.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0) | [Initialization](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Purchase-Initialization.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0) | [Settlement](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Purchase-Settle.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0) |
| [Withdraw](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Withdraw-Use-Case.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0) | [Initialization](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Withdraw-Initialization.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0) | [Bank Wire](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Withdraw-Wire.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0) |

#Data
![Entities](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Entities.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

##Definition 
![MAPS](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Map-files.webp&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

##Command
- Account
	- ``dotnet ef migrations add ______ --verbose --namespace Migrations.Account``
- Financial
	- ``dotnet ef migrations add ______ --verbose --namespace Migrations.Financial``
- Lobby
	- ``dotnet ef migrations add ______ --verbose --namespace Migrations.Lobby``
- Room
	- ``dotnet ef migrations add ______ --verbose --namespace Migrations.Room``

##Persisting
![MIGRATIONS](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Migrations.webp&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

- ``dotnet ef database update -- --environment=Development``
- ``dotnet ef database update -- --environment=Production``

#Quality
![QPS](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/QPS-Solution.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

##Command
- Development
	- ``npm run start-dev``
- Production
	- ``npm run start-prd``
	
##Som Test Cases
- [Sign in](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/QPS01-Test-Case.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)
- [Elements Availability](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/QPS02-Test-Case.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)
- [Content Restriction](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/QPS03-Test-Case.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0)

#Cloud / Premise
[Locaweb - Hospedagem GO](https://www.locaweb.com.br/hospedagem-de-sites-com-dominio-gratis)

_8 BRL | Monthly | SSL, DNS, Storage e Bandwidth (Unlimited)_

[MonsterAsp.Net - Premium](https://www.monsterasp.net)

_10,60 BRL | Monthly | EU, 512 Mb Memory, 25Gb Storage, 2 Gb for 5 MySql Databases, Bandwidth (Unlimited)_

#Etc
- [Interface and Experience](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/v0.0.9.pdf&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0&download=true)
- [Accronyms Spreadsheet](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Accronyms.pdf&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0&download=true)
- [Technical Conventions](https://dev.azure.com/monetizacao/c380ee07-2efe-4b78-9431-c446a5d39367/_apis/git/repositories/6c93098f-8895-4f84-999d-247543b3ecfb/items?path=/Company/Technical-Convention.pdf&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=main&resolveLfs=true&%24format=octetStream&api-version=5.0&download=true)

#About
I (gustavo_hen@hotmail.com) conceived, designed, developed, and researched the entire project during a freelancer contract, which serves as a Proof of Concept (PoC).

Version 1.0 with multilingual support ready, and I am sharing its source code for any purpose.