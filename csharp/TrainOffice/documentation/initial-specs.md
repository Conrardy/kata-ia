**Besoin**

- Une interface web pour pouvoir réserver des places dans un train

**Restrictions techniques**

- Une interface web
- Une API (web)

**Règles** 

- Un train est composé de wagons (nombre inconnu)
- Pour un même train, le nombre de sièges par wagon N’est PAS forcément unique
- On ne peut pas remplir à plus de 70% un train
- On ne peut pas séparer les groupes dans plusieurs wagons
→ Sinon on indique que ce n’est pas possible
- Idéalement un wagon est rempli à 70% (mais on peut le remplir jusqu’à 100%) 
→ Essayer de remplir l’ensemble des wagons de manière uniforme
- Chaque train a un nom : alphanumérique plus le tiret (-), 50 caractères maximum
- Chaque wagon a une lettre
- Chaque siège du wagon est numéroté de de 1 à n et il est sufixé par la lettre du wagon
Ex. 1A, 2A, … 1B, 2A