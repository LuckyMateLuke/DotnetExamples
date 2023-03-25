SET /P Naam=[Naam van de Migratie]

dotnet ef migrations remove  --startup-project ..\..\LuckyMateLuke.Examples\LuckyMateLuke.Examples.csproj  --context CustomDbContext