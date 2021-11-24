# COSC457-Group4

# Project Build Information
**First Release:**

Unity [Version 2019.4.1f1](https://unity3d.com/unity/qa/lts-releases?version=2019.4&page=4)
Modules: WebGL Build Support, Windows Build Support (Mono), Mac Build Support (IL2CPP)

**Refactored Version:**

Unity [Version 2021.3.23f1](https://unity3d.com/es/unity/whats-new/2020.3.23) with Modules: WebGL Build Support, Windows Build Support (Mono), Mac Build Support (IL2CPP)

Visual Studio Editor [Version 2.0.12](https://docs.unity3d.com/Packages/com.unity.ide.visualstudio@2.0/manual/index.html) (see update instructions below)

[Unity Manual](https://docs.unity3d.com/Manual/UnityManual.html)

## Update Unity Packages

### Visual Studio Editor Package - 2.0.12

If upon opening Unity, you see a warning in the Console about a new Visual Studio Editor Package version being available, do the following to update:

From Unity project, go to *Window* > *Package Manager*

In *Package Manager* window, go to *Unity Technologies* > *Visual Studio Editor*

Click the toggle on the left side to expand tab, go to *Update Available*

On the bottom right of the *Package Manager* window, click *Update to 2.0.12*

### Version Control - 1.15.4

From the same *Package Manager* window, go to *Version Control*

Click the toggle on the left side to expand tab, go to *Update Available*

On the bottom right of the *Package Manager* window, click *Update to 1.15.4*

### Test Framework - 1.1.30

From the same *Package Manager* window, go to *Test Framework*

Click the toggle on the left side to expand tab, go to *Update Available*

On the bottom right of the *Package Manager* window, click *Update to 1.1.30*

### Apply Updates

Save project then quit Unity. Go back to Unity Hub and reopen project. Console warnings should be gone.

### Create Cards (Scriptable objects)
1. Right click go to "Create", go down to the bottom of the menu and hover over "Cards" and then pick which type of card will be created
2. Click on the created object in the project menu and fill out all the empty varible spaces 
3. Then create a prefab of the repective card type and attach the created card to the prefab object in the " cardDisplay scirpt" and then play the game and you should ahve a card 
4. The card scripts are now in their own folder in the scripts section, no need to worry about the "cardMenu" script it just allows us to access the cards in the create assets menu
6. The card prefabs are also in their own folders
7. There is also a seperate folder called "cards" in the assets folder so when creating the scriptable object of cards. 
8. I am almost positvie that there is a way to create and add them to prefabs and all that from code im just not exactly sure how to do that yet. 
