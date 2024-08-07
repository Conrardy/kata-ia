Ensemble du chat: https://chatgpt.com/share/e/ac806571-52f2-4de1-acbe-b50250e53e94

## 1. Envoi du contexte
Copier/Coller des specs initiales

## 2. Demande de proposition d'UI
Propose moi des suggestions pour l'interface utilisateur

## 3. Recadrage
je n'ai pas besoin de
- la barre de navigation
- d'option de recherche et de filtre
- de slider pour indiquer/saisir la taille de mon groupe. la taille du groupe se fera par une saisie d'un nombre. 
- la représentation graphique des wagons

Revoie ta proposition en fonction de mes précisions et donne moi le code HTML/CSS pour afficher cette page

## 4. Recadrage (bis)
dans l'interface: 
- on ne peut que sélectionner un train (selectbox) et donner le nombre de passagers pour la réservation (entre 1 et 500)
- on ne peut pas voir le nombre de sieges de chaque wagon
- on ne peut pas savoir combien il y a de wagons

## 5. Demande d'aide pour la création de l'API
Tu vas nous aider a faire le design de l'API. Elle sera codée en C#
J'ai besoin que:
- elle me permette d'alimenter la selectbox des trains
- elle me permette de traiter une demande de réservations (identifiant du train + nombre de places à réserver) en renvoyant le numéro de la réservation + la liste des sièges réservés si tout s'est bien passé ou une erreur en cas de non respect des règles

## 6. Recadrage sur le stockage des données
Les données des trains et des wagons seront stockées dans un tableau qui sera lui-meme dans une classe singleton. Je n'ai pas besoin de Entity Framework Core et de base de données

