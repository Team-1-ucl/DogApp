README for Projektet
# Vores Program: DogApp

Vores program, DogApp, er bygget med en multilag-arkitektur for at sikre modularitet, skalerbarhed og vedligeholdelse. Dette designmønster gør det muligt for os at isolere forskellige dele af applikationen, hvilket gør det lettere at opdatere, teste og udvide uden at påvirke andre dele af systemet. 

# Arkitektur og Komponenter
## Shared:
**Formål:** Indeholder delte entiteter, som kan bruges af forskellige lag i applikationen.

## Data:
**Formål:** Indeholder database konfiguration.

## Repository:
**Formål:** Implementerer repository pattern, som adskiller forretningslogik og dataadgangslogik.

## Services:
**Formål:** Indeholder forretningslogik og tjenestemæssige operationer.

## API:
**Formål:** Dette lag fungerer som mellemled mellem vores front-end og back-end systemer. Det muliggør skalerbarhed ved at tillade forskellige klienter at interagere med vores data gennem HTTP-anmodninger.

## Test:
**Formål:** Indeholder enhedstests og integrationstests for at sikre, at alle dele af applikationen fungerer korrekt.

## Web:
**Formål:** Host og servering af Blazor-applikationen.

## Dokumentation 
**Formål** Dokumentation dækker både high level og low level design, hvilket sikrer en forståelse af systemet fra overordnede strukturer til detaljerede implementeringer.

# Opsummering
Ved at benytte en multilag-arkitektur med klare adskillelser mellem forskellige ansvarsområder og ved at implementere repository pattern, har vi skabt et robust og skalerbart system. Blazor som front-end teknologi giver os mulighed for at levere en moderne og responsiv brugeroplevelse, mens vores API sikrer, at applikationen kan skaleres og integreres med andre systemer.Dokumentationen understøtter både high level og low level design, hvilket sikrer en forståelse af systemet for både udviklere og interessenter.


  




