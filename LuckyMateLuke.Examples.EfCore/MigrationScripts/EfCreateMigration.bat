SET /P Naam=[Naam van de Migratie]

dotnet ef migrations add %Naam%  --project ..\LuckyMateLuke.Examples.EfCore.csproj  --startup-project ..\..\LuckyMateLuke.Examples\LuckyMateLuke.Examples.csproj  --context CustomDbContext -o ..\LuckyMateLuke.Examples.EfCore\Migrations