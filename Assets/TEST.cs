using UnityEngine;
using System.Collections;
using GFB;
public class TEST : MonoBehaviour
{
    public GameObject canv;
    // Use this for initialization
    void Start()
    {
        GFileBrowser.Init(canv);
        GFileBrowser.ShowDialog("C:/");
        GFileBrowser.onFileSelected = onFile;
    }
    
    void onFile(GBase file){
        Debug.Log(file.Name);
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
