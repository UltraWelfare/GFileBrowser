# GFileBrowser
The free open-source FileBrowser for Unity is now available for download.
It uses the integrated UI System (from 5.1) and is fully customizable due to the use of prefabs.

# Installation
Clone the repository and take a look at the example project.
The most important part of the filebrowser is Resources/FileBrowser (Contains the prefabs and the textures) and the Scripts folder, so you might as well copy them to your current project and use them accordingly :)

# Usage
1. Add ```using GFB;``` at the top of your script.
2. Create a MonoBehaviour script and call ```GFileBrowser.Init(gameobject)``` where the gameobject should be your Canvas (or some child of your Canvas).
3. Create a callback function like this : 
```
void onFileSelected(GBase file) {
       // Do stuff here with file.Name and file.Path  
}
```
4. Assign the callback function to the GFileBrowser with ```GFileBrowser.onFileSelected = onFileSelected;```
5. Show the dialog with ```GFileBrowser.ShowDialog(root)``` where root is a string that indicates the first path that the user will see when the dialog shows up.
A good default value could be "C:\\".

GFileBrowser contains also some extra functions that might be useful to you such as
* ```AddToIgnore(string Name)``` Adds to the ignore list the name of the file-folder that you passed in the parameter so that it doesn't show up in the browser.
* ```Navigate(string Path)``` Navigates the browser to the parameter Path
* ```HideDialog()``` Hides the dialog (filebrowser) from the user at anytime.
* ```FileOrder``` enum that specifies the order in which the folders-files should appear in the browser.
Possible values are : FirstFolders, FirstFiles. The default is FirstFolders
