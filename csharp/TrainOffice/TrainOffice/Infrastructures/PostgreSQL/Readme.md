### Exemple Complet de migration

   ```sh
   cd C:\Workspace\kata-ia\csharp\TrainOffice\Infrastructures\PostGreSQL\
   ```

Créer une migration :

   ```sh
   dotnet ef migrations add InitialCreate
   ```

   ```sh
   dotnet ef migrations add InitialCreate --output-dir 'C:\Workspace\kata-ia\csharp\TrainOffice\Infrastructures\PostGreSQL\Migrations'
   ```

Appliquer la migration :

   ```sh
   dotnet ef database update
   ```

Vérifier les migrations :

   ```sh
   dotnet ef migrations list
   ```
