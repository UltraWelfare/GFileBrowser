using UnityEngine;
using System.Collections;

public class GFolder
{

    private string path;
    private string name;

    public string Name { get { return name; } }

    public GFolder(string path)
    {
        this.path = path;
        name = Utilities.splitNamePath(this.path);
    }


}
