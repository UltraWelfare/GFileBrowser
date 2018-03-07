using UnityEngine;
using System.Collections;
public class GFile
{

    private string path;
    private string name;

    public string Name { get { return name; } }

    public GFile(string path)
    {
        this.path = path;
        name = Utilities.splitNamePath(this.path);
    }

}

