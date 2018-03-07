using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GComponent : MonoBehaviour, IPointerClickHandler {

    GBase holder;
    Type t;
    UINavigator ui;
    
	public void Load(GBase b, Type t, UINavigator ui) {
        this.t = t;
        this.holder = b;
        this.ui = ui;
        ReloadUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ui.onBasePanelClick(holder, t);
    }

    public void ReloadUI(bool reloadText = true, bool reloadTexture = true) {
        if(reloadText) { GetComponentInChildren<Text>().text = holder.Name; }
        if(reloadTexture) {
            if(t == Type.File) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.fileSprite;
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
