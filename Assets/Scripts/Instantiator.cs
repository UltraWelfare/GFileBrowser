using UnityEngine;

public class Instantiator
{

    public GameObject fb;
    public GameObject fileScrollView;
    public GameObject filePrefab, folderPrefab;

    UINavigator nav;
    public Instantiator(GameObject parent)
    {

        fb = GameObject.Instantiate(Resources.fileBrowserPrefab, parent.transform, false);
        fileScrollView = fb.transform.Find("FileScrollView").Find("Viewport").Find("Content").gameObject;
        fb.SetActive(false);

        nav = new UINavigator(this);

        filePrefab = Resources.filePrefab;
        folderPrefab = Resources.folderPrefab;
    }

    public void Show()
    {
        fb.SetActive(true);
    }

    public void Hide()
    {
        fb.SetActive(false);
    }

    public void File(GFile file)
    {
        GameObject f = GameObject.Instantiate(filePrefab, fileScrollView.transform, false);
        if (!f.GetComponent<GFileComponent>())
        {
            f.AddComponent<GFileComponent>();
        }
        f.GetComponent<GFileComponent>().Load(file);
    }

    public void Folder(GFolder folder)
    {
        GameObject f = GameObject.Instantiate(folderPrefab, fileScrollView.transform, false);
        if (!f.GetComponent<GFolderComponent>())
        {
            f.AddComponent<GFolderComponent>();
        }
        f.GetComponent<GFolderComponent>().Load(folder);
    }
}
