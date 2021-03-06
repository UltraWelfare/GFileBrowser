﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using GFB;
public class GComponent : MonoBehaviour {

    GBase holder;
    Type type;
    public Type Type { get { return type; } }
    UINavigator ui;
    public GBase Holder { get { return holder; } }


    public void Load(GBase b) { 
        this.holder = b;
        type = b.GetType();
        ReloadUI();
    }

    public void ReloadUI(bool reloadText = true, bool reloadTexture = true) {
        if (reloadText) {
            if (type == typeof(GDrive)) {
                GetComponentInChildren<Text>().text = Holder.Path;
            } else {
                GetComponentInChildren<Text>().text = Holder.Name;
            }
        }

        if (reloadTexture) {
            if (type == typeof(GFile)) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.fileTexture;
            } else if (type == typeof(GFolder)) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.folderTexture;
            } else if (type == typeof(GDrive)) {
                GetComponentInChildren<RawImage>().texture = GFileBrowser.Resources.driveTexture;
            }
        }
    }
}
