# Narrations Jouables 2026

Semestre printemps 2026  
Pratiques artistiques, [Collège of Humanities][1], [EPFL][2]  
[Alexia Mathieu][3] et [Raphaël Muñoz][4]  

[1]: https://www.epfl.ch/schools/cdh/
[2]: https://epfl.ch
[3]: https://www.hesge.ch/head/formations-recherche/master-en-media-design "Master Media Design"
[4]: https://aprobado.ch "Aprobado Studio"

## Contenu

Ce repo contient des assets et scripts pour vous aider à créer votre projet de *Walking Simulator*.
Le dossier *Starter Assets* est une copie mise à jour pour Unity 6.3 de **Starter Assets: Character Controllers | URP** https://assetstore.unity.com/packages/essentials/starter-assets-character-controllers-urp-267961

## 1. Création de votre projet Unity
1. Créez votre Unity ID : https://login.unity.com/en/sign-in
2. Installez Unity Hub : https://unity.com/download
3. Depuis le menu **Installs** du Hub, installez Unity 6.3 LTS
4. Depuis le menu **Projects** du Hub, créez un projet **Unity Universal 3D** (URP) et ouvrez le.
5. Ouvrez le Package Manager via le menu **Window > Package Management > Package Manager**
6. Dans la liste **Unity Registry**...
	- Installez Cinemachine : com.unity.cinemachine
	- Installez Terrain Tools : com.unity.terrain-tools
7. En haut à gauche de la fenêtre, cliquez sur **+ > Install package from git URL...**
8. Indiquez l'URL ```https://github.com/aprobado/narrations-jouables-2026```

## 2. Installation de l'environnement d'exemple
1. Ouvrez la page du Unity Store : https://assetstore.unity.com/packages/3d/environments/unity-terrain-urp-demo-scene-213197
2. Cliquez **Add to My Assets**
3. Cliquez à nouveau sur le bouton qui devrait afficher **Open in Unity**. Vous pouvez aussi ouvrir le **Package Manager** et sélectionner **My Assets** dans le menu de gauche, vous trouverez l'Asset Unity Terrain URP Demo dans la liste.
4. Sous le titre à droite, cliquez **Download**, puis, une fois le téléchargement terminé, **Import**.

## 3. Utilisation de la scène de démo
1. Ouvrez la scène *TerrainDemoScene* dans **Assets > TerrainDemoScene_URP > Scenes**
2. Supprimez ces GameObjects :
	- Main Camera
	- VirtualCameras
	- Timelines
3. Sélectionnez **EventSystem** et dans l'inspector, dans **Standalone Input Module**, cliquez **Replace with InputSystemUIInputModule**
4. Sauvegardez la scène.

## 4. Ajout du First Person Controller
1. Dans l'onglet **Project**, naviguez dans **Packages > Narrations Jouables 2026 > Starter Assets > Runtime > FirstPersonController > Prefabs**
7. Glissez-déposez **NestedParent_Unpack** dans votre scène.
8. Faites un clic-droit sur le GameObject **NestedParent_Unpack**, et sélectionnez **Prefab > Unpack**
9. Pour définir la position de départ, déplacez le GameObject **PlayerCapsule**.
10. Lancez le PlayMode pour vérifier que tout fonctionne.