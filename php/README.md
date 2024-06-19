# kata-ia php

Ce projet utilise PHPUnit pour les tests unitaires. Suivez les étapes ci-dessous pour installer PHPUnit via Composer et exécuter les tests.

## Prérequis

- PHP (version 7.4 ou supérieure)
- Composer (outil de gestion des dépendances pour PHP) install

## Installation

1. Clonez le dépôt :

    ```bash
    git clone https://github.com/Conrardy/kata-ia.git
    cd kata-ia/php
    ```

2. Installez les dépendances :

    ```bash
    composer install
    ```

3. Dans le terminal, naviguez jusqu'au répertoire du projet et exécutez la commande suivante pour installer PHPUnit globalement et/ou localement:

    ```bash
    composer global require phpunit/phpunit
    ```

    ```bash
    composer require --dev phpunit/phpunit
    ```

### Run test in terminal

```bash
phpunit
```

## PHP Intelephense

1. Ouvrez Visual Studio Code.

2. Cliquez sur l'icône des extensions dans la barre latérale à gauche (ou utilisez le raccourci `Ctrl+Shift+X`).

3. Dans la barre de recherche des extensions, tapez `PHP Intelephense`.

4. Cliquez sur le bouton `Installer` pour installer l'extension.
