using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFB {
    public abstract class GBase {
        string path, name;

        public string Name { get { return name; } }
        public string Path { get { return path; } }

        /// <summary>
        /// GBase is the abstract class for GFile, GFolder, GDrive.
        /// Constructor gets a paramater p, which is the path.
        /// Note : The name of the file will be automatically extracted.
        /// </summary>
        public GBase(string p) {
            this.path = p;
            name = Utilities.splitNamePath(this.path);
        }
    }
}
