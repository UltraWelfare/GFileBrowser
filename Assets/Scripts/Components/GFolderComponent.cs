using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GFolderComponent : MonoBehaviour
{
    GFolder folder;

    public void Load(GFolder folder)
    {
        this.folder = folder;
        reloadUIName();
    }

    public void reloadUIName()
    {
        GetComponentInChildren<Text>().text = folder.Name;
    }
    
}

