using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GFB {
    /// <summary>
    /// Responsible for updating the contents of the Drive View.
    /// </summary>
    public class BrowserDrive : Browser {
        public BrowserDrive(Transform contentView, GameObject prefab, MainController controller) : base(contentView, prefab, controller) { }
        /// <summary>
        /// Reloads the drive view contents.
        /// </summary>
        public override void Reload() {
            try {
                List<GBase> drives = SystemCalls.returnDrives();
                Clear();
                inst(drives, (b, go) => {
                    go.GetComponent<GComponent>().Load(b);
                    go.GetComponent<UIClickListener>().AddListener(UIClickListener.Type.LeftClick, () => {
                        controller.getUI.onDriveClicked(go.GetComponent<GComponent>());
                    });
                });
                recalculateContentSize(drives.Count);
            } catch (Exception e) {
                controller.getUI.DisplayError(e);
            }
        }
    }
}