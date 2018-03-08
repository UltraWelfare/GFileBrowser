using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GBase {
    string path, name;

    public string Name { get { return name; } }
    public string Path { get { return path; } }

    public GBase(string p) {
        this.path = p;
        name = Utilities.splitNamePath(this.path);
    }
}
