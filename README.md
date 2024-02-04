![Logo](GymGenius/Assets/Logo.jpg)

# GymGenius
Bienvenue sur GymGenius, votre compagnon ultime pour la création de séances de sport personnalisées ! Cette application WPF vous permet de concevoir des séances d'entraînement adaptées à vos besoins, que vous soyez débutant ou expert en fitness. Avec GymGenius, la planification de vos sessions de gym n'a jamais été aussi simple et efficace.

## 🎯 Tester GymGenius
### Prérequis
- **GIT**
- **Windows**
### Méthode sans installation
1. **Cloner le dossier GitHub**
<br>Ouvrez un terminal à l'emplacement où vous voulez placer le dossier GymGenius :
```bash
  git clone https://github.com/AlexNbl27/GymGenius.git
```

2. **Ouvrir le dossier GymGenius créé à l'instant**
<br>Vous devriez voir dans ce dossier les fichiers/dossiers suivants :
<br>(Dossier) GymGenius
<br>(Fichier) .gitattributes
<br>(Fichier) .gitignore
<br>(Fichier) GymGenius.sln
<br>(Fichier) readme.md

3. **Ouvrir un terminal**

4. **Se déplacer vers le dossier contenant le .exe**
<br>L'exécutable se situe dans le dossier GymGenius/bin/Release/net8.0-windows.
<br> Vous pouvez taper cette commande dans le terminal pour le trouver :
```bash
  cd GymGenius/bin/Release/net8.0-windows
```
5. **Lancer l'exécutable**
<br>Une fenêtre va se lancer en tapant cette commande dans le terminal :
```bash
  .\GymGenius.exe
```
**Et voilà ! GymGenius est à vous ! 🥳**

## ✨ Fonctionnalités
Découvrez les fonctionnalités puissantes de GymGenius, conçues pour simplifier la création de vos séances d'entraînement. Explorez un ensemble complet d'outils qui vous permettront de personnaliser, planifier et suivre vos séances de sport de manière efficace et motivante :

- Accès à une liste d'exercices avec différentes difficultés, différents matériels, dans différentes configurations.
- Une option de filtrage utile pour trouver des exercices spécifiques à une partie du corps et adaptés à votre expérience.
- Des paramètres sympas pour personnaliser votre séance.
- Possibilité de sauvegarder sa séance dans son calendrier via le format ICS et de pouvoir à tout moment la réimporter dans l'application GymGenius.
- Possibilité de réaliser la séance directement sur l'application une fois créée ou lorsque qu'on l'importe.

## 👨‍💻 Méthode de développement
### Organisation des dossiers et des fichiers
Nous avons utilisé la structure de développement **MVVM** (Modèle Vue Vue-Modèle) pour ce projet. 
<br> Ainsi, nous avons décomposé nos fichiers tels que :
- **Models** : Le dossier *Models* regroupe l'ensemble des fichiers nous ayant permis de mettre en œuvre la programmation orientée objet (POO). On y retrouve notamment les classes abstraites et leurs enfants, la gestion de la machine à états ou encore la classe permettant de créer une séance de sport.
- **Views** : Le dossier *Views* regroupe toutes nos pages WPF et le code XAML qui leur est associé. La partie logique de ces fichiers a été séparée autant que possible pour assurer une maintenabilité optimale du code.
- **ViewModel** : Le dossier *ViewModel* regroupe tous les fichiers permettant de faire le lien entre nos classes du dossier Models et nos pages du dossier Views.

En plus de cela, d'autres dossiers viennent compléter ce trio pour permettre une compréhension du code simplifiée :
- **Controllers** : Le dossier *Controllers* regroupe tous les fichiers permettant une refactorisation maximale des autres fichiers. Nous retrouvons ainsi toutes les classes qui seront utilisées à plusieurs endroits dans le code comme, par exemple, *TimeController* qui permet de gérer efficacement l'affichage du temps (heures, minutes, secondes) ou encore *TimerController* qui permet de gérer efficacement l'utilisation des minuteurs.
- **Utils** : Le dossier *Utils* regroupe tous les fichiers annexes utiles au projet. C'est d'ailleurs dans ce dossier que se trouve le code qui permet l'export et l'import de notre séance au format ICS.
- **Assets** : Ce dossier contient les ressources du projet.

### Design Patterns
Nous avons utilisé 4 design patterns communs pour créer notre application :
- Le design **States** : Nous avons utilisé une machine à états pour gérer le déroulement d'une séance de sport. Les deux états sont Exercice et Repos et s'alternent dans une combinaison logique d'appels de fonctions.
- Le design **Observer** : Combiné à la machine à états, nous avons utilisé un système d'abonnement pour permettre l'itération de notre liste d'exercices en fonction de l'index actuel à chaque fois qu'on entre dans l'état Exercice.
- Le design **Abstract Factory** : Puisque ce projet était prévu pour nous faire progresser sur le polymorphisme, nous avons décidé de créer une base de données d'exercices en dur plutôt qu'une base de données externe au projet. Ainsi, nous avons créé une classe abstraite AExercise dont découlent ensuite tous nos exercices. À cela s'ajoute également une interface ISerie pour différencier les exercices qui se font en séries (ex. : les pompes) de ceux qui se font sur la durée (ex. : le gainage).
- Le design **Bridge** : Chaque exercice est associé à une liste de muscles qu'il fait travailler. Or, nous voulions filtrer nos exercices par partie du corps travaillée. Ainsi, chaque muscle (*AMuscle*) est lui-même associé à une partie du corps (*ABodyPart*).

## Auteurs

- [@AlexNbl27](https://github.com/AlexNbl27)
- [@AlexandreBudan](https://github.com/AlexandreBudan)
- [@manonbrz](https://github.com/manonbrz)
