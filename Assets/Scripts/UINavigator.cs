using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.EventSystems;

namespace GFB {
    public class UINavigator {

        //----UI Components----//
        InputField pathField;
        Text errorDisplayText;

        //----Classes----//
        BrowserFile brf;
        BrowserDrive brd;

        //----Colors----/
        Color32 selectedColor = new Color32(0, 0, 255, 100);
        Color32 normalColor = new Color32(255, 255, 255, 100);

        public UINavigator(GameObject fb, BrowserFile browserFile, BrowserDrive browserDrive) {
            this.brf = browserFile;
            this.brd = browserDrive;
            pathField = fb.transform.Find("PathField").GetComponent<InputField>();
            errorDisplayText = fb.transform.Find("ErrorDisplayText").GetComponent<Text>();
        }

        //----UI Responses----//

        void setSelected(GComponent gComponent, bool selected) {
            if (selected) {
                gComponent.gameObject.GetComponent<Image>().color = selectedColor;
            } else {
                gComponent.gameObject.GetComponent<Image>().color = normalColor;
            }
        }

        public void UpdatePathField(string path) {
            pathField.text = path;
        }

        public void DisplayError(Exception e) {
            string tmp = "Unknown error : " + e.ToString();
            if (e is DirectoryNotFoundException) {
                tmp = "Path not found";
            } else if (e is UnauthorizedAccessException) {
                tmp = "You don't have permission to access this folder";
            } else if (e is ArgumentException) {
                tmp = "Path contains invalid characters";
            } else if (e is ArgumentNullException) {
                tmp = "Path is invalid (maybe empty?)";
            } else if (e is PathTooLongException) {
                tmp = "Path has exceed the system-defined maximum length";
            }
            errorDisplayText.text = tmp;
        }

        //----UI Calls----//

        public void onBack() {
            brf.GoBack();
        }

        public void onDone() {
            GFileBrowser.onFileSelected(brf.CurrentSelectedFile);
            GFileBrowser.HideDialog();
        }

        public void onRedirect() {
            brf.Reload(pathField.text, true);
        }

        public void onDriveClicked(GComponent g) {
            brf.Reload(g.Holder.Path, true);
        }

        public void onFolderLeftClicked(GComponent g) {
            brf.Reload(g.Holder.Path, true);
        }

        public void onFolderRightClicked(GComponent g) {

        }

        public void onFileLeftClicked(GComponent g) {
            if (g.Holder.Equals(brf.CurrentSelectedFile)) {
                setSelected(g, false);
                brf.CurrentSelectedFile = null;
            } else {
                brf.components.ForEach(c => {
                    if (!c.Equals(g)) {
                        setSelected(c, false);
                    } else {
                        setSelected(c, true);
                        brf.CurrentSelectedFile = (GFile)c.Holder;
                    }
                });

            }
        }

        public void onFileRightClicked(GComponent g) {

        }
    }
}

