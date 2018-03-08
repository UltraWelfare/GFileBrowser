using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GComponent : MonoBehaviour, IPointerClickHandler {

    GBase holder;
    Type t;
    UINavigator ui;
    public GBase Holder { get { return holder; } }

    public void Load(GBase b, Type t, UINavigator ui) {
        this.t = t;
        this.holder = b;
        this.ui = ui;
        ReloadUI();
    }

    public void OnPointerClick(PointerEventData eventData) {
        ui.onBasePanelClick(this, t);
    }

    public void ReloadUI(bool reloadText = true, bool reloadTexture = true) {
        if (reloadText) {
            if (t == Type.Drive) {
                GetComponentInChildren<Text>().text = Holder.Path;
            } else {
                GetComponentInChildren<Text>().text = Holder.Name;
            }
        }

        if (reloadTexture) {
            if (t == Type.File) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.fileTexture;
            } else if (t == Type.Folder) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.folderTexture;
            } else if (t == Type.Drive) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.driveTexture;
            }
        }
    }

    public enum Type {
        File,
        Folder,
        Drive,
        Null
    }
}
