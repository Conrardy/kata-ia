# Boilerplate

```sh
# 1. Créer un dossier pour la solution
mkdir TrainOffice
cd TrainOffice

# 2. Créer une solution
dotnet new sln -n TrainOffice

# 3. Créer un projet Web API
dotnet new webapi -n TrainOffice

# 4. Créer un projet de test
dotnet new xunit -n TrainOffice.Tests

# 5. Ajouter les projets à la solution
dotnet sln add TrainOffice/TrainOffice.csproj
dotnet sln add TrainOffice.Tests/TrainOffice.Tests.csproj

# 6. Ajouter une référence du projet de test au projet Web API
cd TrainOffice.Tests
dotnet add reference ../TrainOffice/TrainOffice.csproj
```

# Guide d'installation de .NET

## Prérequis

- Un système d'exploitation Windows, macOS ou Linux
- Accès à une ligne de commande ou un terminal

## Étapes d'installation

1. **Télécharger et installer .NET SDK :**

   Rendez-vous sur le site officiel de .NET et téléchargez le SDK correspondant à votre système d'exploitation : [Télécharger .NET](https://dotnet.microsoft.com/download)

2. **Vérifier l'installation :**

   Ouvrez une ligne de commande ou un terminal et exécutez la commande suivante pour vérifier que .NET est correctement installé :

   ```sh
   dotnet --version
   ```

## Installation de Docker

1. **Télécharger et installer Docker Desktop :**

   Rendez-vous sur le site officiel de Docker et téléchargez Docker Desktop correspondant à votre système d'exploitation : [Télécharger Docker Desktop](https://www.docker.com/products/docker-desktop)

2. **Installer Docker Desktop :**

   Suivez les instructions d'installation fournies sur le site de Docker.

3. **Vérifier l'installation :**

   Ouvrez une ligne de commande ou un terminal et exécutez la commande suivante pour vérifier que Docker est correctement installé :

   ```sh
   docker --version
   ```

   Lancer la base de données

   ```sh
   docker-compose up -d
   ```

## Migrations de Données avec Entity Framework Core

### Prérequis

1. **Installer les outils nécessaires :**

   Assurez-vous d'avoir installé l'outil `dotnet-ef` globalement. Vous pouvez l'installer en exécutant la commande suivante :

   ```sh
   dotnet tool install --global dotnet-ef 
   ```

### Exemple Complet de migration

   ```sh
   cd TrainOffice
   ```

Créer une migration :

   ```sh
   dotnet ef migrations add InitialCreate
   ```

   ```sh
   dotnet ef migrations add InitialCreate --output-dir Migrations/CustomPath
   ```
   


Appliquer la migration :

   ```sh
   dotnet ef database update
   ```

Vérifier les migrations :

   ```sh
   dotnet ef migrations list
   ```
