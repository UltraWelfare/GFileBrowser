using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GFileComponent : MonoBehaviour
{
    GFile file;

    public void Load(GFile file)
    {
        this.file = file;
        reloadUIName();
    }

    void reloadUIName()
    {
        GetComponentInChildren<Text>().text = file.Name;
    }
    
}

