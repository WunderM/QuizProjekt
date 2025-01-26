# Projektbeteiligte
Maurice Wunder
Moritz Gershoff
Kanat Arngold


# QuizProjekt
Projekt für das Fach Software Engineering


# Datenbank
Die Datenbank gegen welches das Projekt läuft, ist eine Supabase datenbank
Datenbank Kennwort: quiz

Datenbank mit folgenden Befehlen angelegt: 

dotnet ef migrations add InitialCreate
dotnet ef database update

# Backend (REST-API)
Der Server welcher das Backend wiederspiegelt liegt im Ordner Backend

Der Server ist wie folgt zu Starten: 
1. öffnen des Backend Ordner in Visual Studio Code 
2. Terminal öffnen
3. dotnet clean QuizPlatform_API.sln
4. dotnet build QuizPlatform_API.sln
5. dotnet run QuizPlatform_API.sln

Damit ist der Server gestartet und wir können mittels des Clients Anfragen an diesen Stellen

# Frontend (Client)
Der Client welcher das Frontend wiederspiegelt liegt im Ordner SoftwareEngineering

Der Client ist wie folgt zu Starten: 
1. öffnen des SoftwareEngineering Ordner in Visual Studio Code 
2. Terminal öffnen
3. dotnet clean 
4. dotnet build 
5. dotnet run 

# Infos zum Testen
Zum Testen haben wir die Möglichkeit Uns einzuloggen (Username: Maurice, Password: Maurice) oder als Gast zu spielen 
Sollte man sich einloggen wird auch der Highscore gespeichert
Aktuell sind Daten nur für die Kategorie Allgemeinwissen vorhanden




