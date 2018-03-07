using UnityEngine;
using UnityEngine.UI;
public class GComponent : MonoBehaviour {

    GBase holder;
    Type t;
	public void Load(GBase b, Type t) {
        this.t = t;
        this.holder = b;
        ReloadUI();
    }

    public void ReloadUI(bool reloadText = true, bool reloadTexture = true) {
        if(reloadText) { GetComponentInChildren<Text>().text = holder.Name; }
        if(reloadTexture) {
            if(t == Type.File) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.fileSprite;
                Debug.Log("asd");
            } else {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.folderSprite;
            }
         }
    }
    
    public enum Type {
        File,
        Folder
    }
}
