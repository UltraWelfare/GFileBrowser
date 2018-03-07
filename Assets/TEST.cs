using UnityEngine;
using System.Collections;
public class TEST : MonoBehaviour
{
    public GameObject canv;
    // Use this for initialization
    void Start()
    {

        GFileBrowser.Init(canv);
        GFileBrowser.ShowDialog("F:/");
        GFileBrowser.Navigate("C:/");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
