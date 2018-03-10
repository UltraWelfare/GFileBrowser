using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class UINavigator {
    GameObject fb;
    Button backButton, doneButton, redirectButton;
    InputField pathField;
    BrowserFile brf;
    BrowserDrive brd;
    Color32 selectedColor = new Color32(0, 0, 255, 100);
    Color32 normalColor = new Color32(255, 255, 255, 100);
    Text errorDisplayText;

    public UINavigator(GameObject fileBrowserRoot) {
        this.fb = fileBrowserRoot;
        pathField = fb.transform.Find("PathField").GetComponent<InputField>();
        errorDisplayText = fb.transform.Find("ErrorDisplayText").GetComponent<Text>();
        setupButtons();
    }

    public void PassBrowser(BrowserFile browserFile, BrowserDrive browserDrive) {
        this.brf = browserFile;
        this.brd = browserDrive;
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

    public void UpdatePathField(string path) {
        pathField.text = path;
    }

    void setupButtons() {
        backButton = fb.transform.Find("BackButton").GetComponent<Button>();
        doneButton = fb.transform.Find("DoneButton").GetComponent<Button>();
        redirectButton = fb.transform.Find("RedirectButton").GetComponent<Button>();
        backButton.GetComponent<Button>().onClick.AddListener(onBack);
        doneButton.GetComponent<Button>().onClick.AddListener(onDone);
        redirectButton.GetComponent<Button>().onClick.AddListener(onRedirect);
    }

    //----UI Responses----//

    void setSelected(GComponent gComponent, bool selected) {
        if (selected) {
            gComponent.gameObject.GetComponent<Image>().color = selectedColor;
        } else {
            gComponent.gameObject.GetComponent<Image>().color = normalColor;
        }
    }

    //----Button Calls----//

    void onBack() {
        brf.GoBack();
    }

    void onDone() {
        GFileBrowser.onFileSelected(brf.CurrentSelectedFile);
        GFileBrowser.HideDialog();
    }

    void onRedirect() {
        brf.Reload(pathField.text);
    }

    //----Other UI Calls----//

    public void onBasePanelClick(GComponent g) {
        if (g.Type == typeof(GFolder)) {
            onFolderClicked(g);
        } else if (g.Type == typeof(GFile)) {
            onFileClicked(g);
        } else if (g.Type == typeof(GDrive)) {
            onDriveClicked(g);
        }
    }

    private void onDriveClicked(GComponent g) {
        brf.Reload(g.Holder.Path, true);
    }

    private void onFolderClicked(GComponent g) {
        brf.Reload(g.Holder.Path, true);
    }

    private void onFileClicked(GComponent g) {
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
}

