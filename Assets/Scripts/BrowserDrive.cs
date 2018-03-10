using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for updating the contents of the Drive View.
/// </summary>
public class BrowserDrive : Browser {
    public BrowserDrive(Transform contentView, GameObject prefab, UINavigator ui) : base(contentView, prefab, ui) { }
    /// <summary>
    /// Reloads the drive view contents.
    /// </summary>
    public override void Reload() {
        try {
            List<GBase> drives = EnvGrabber.returnDrives();
            Clear();
            inst(drives, (b, go) => {
                go.GetComponent<GComponent>().Load(b, ui);
            });
            recalculateContentSize(drives.Count);
        } catch (Exception e) {
            ui.DisplayError(e);
        }
    }
}