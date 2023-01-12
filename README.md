# Övning för studiegrupper

I denna övning ska ni tillsammans i era studiegrupper försöka återskapa en applikation som har två användargränssnitt.

Ett konsollbaserat och ett grafiskt. Ni kan återanvända det som finns i detta repo.
Båda dessa ska arbeta emot samma databas meed samma kod.

En sådan applikation finns här i detta repo. För att köra GUI/Console välj det ni vill starta som "Start up Project".

## Steg 1

Analysera och försök att tillsammans förstå hur applikationen i detta repo fungerar.
Skriv eller rita, hjälp varandra förstå.

```
DataAccess library:n hade ansvaret för kommunication med data basen; metoder som "GetAll", "Add" osv. implementerades i PersonManager classen som hade sin blueprint från IRepository. Beskerivningen av hur en Person dokument skulle se ut beskrevs av data modellen "Person". 

Projekten "ConsoleClient" och "GuiClient" inject:ade "DataAccess". På så sätt bara med en ***using*** kunde man ha tillgång till databasen.    
```

## Steg 2

I exempelkoden används Person som datamodell. Ni ska göra detta för följande data:

```
Car
    string Model
    string Make
    string Color
    int HorsePowers
```

Återskapa en applikation med samma struktur som exempelapplikationen för Car.

## Steg 3 (Extra)

Utöka datamodellen så att bilmärke(Make), färg(Color) är i separata collections.

## Lämna in ett projekt per studiegrupp

Väljer man som grupp att avsluta efter steg 1 så lämnar man in sin gemensamma analys istället.


## Lycka till!
