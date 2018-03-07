using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UINavigator
{
    GameObject fb;
    Button backButton, doneButton, redirectButton;
    InputField pathField;
    Browser br;
    Color32 selectedColor = new Color32(0,0,255,100);
    Color32 normalColor = new Color32(255,255,255,100);

    public UINavigator(GameObject fileBrowserRoot) {
        this.fb = fileBrowserRoot;
        pathField = fb.transform.Find("PathField").GetComponent<InputField>();
        
    }
    
    public void InitCalls(Browser br) {
        this.br = br;
        setupButtons();
    }

    public void UpdatePathField(string path){
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
    void setSelected(GComponent gComponent, bool selected){
        if(selected){
            
            gComponent.gameObject.GetComponent<Image>().color = selectedColor;
        } else {
            gComponent.gameObject.GetComponent<Image>().color = normalColor;
        }
    }
    //----Button Calls----//

    void onBack() {
        br.GoBack();
    }
    
    void onDone() {
        GFileBrowser.onFileSelected(br.CurrentSelectedFile);
        GFileBrowser.HideDialog();
    }

    void onRedirect() {
        br.ReloadBrowser(pathField.text, true);
    }

    //----Other UI Calls----//

    public void onBasePanelClick(GComponent g, GComponent.Type t) {
        if(t == GComponent.Type.Folder){
            br.ReloadBrowser(g.Holder.Path);
        } else {
            if(g.Holder.Equals(br.CurrentSelectedFile)){
                setSelected(g, false);
                br.CurrentSelectedFile = null;
            } else {
                br.components.ForEach(c => {
                    if(!c.Equals(g)){
                        setSelected(c, false);
                    } else {
                        setSelected(c, true);
                        br.CurrentSelectedFile = (GFile)c.Holder;
                    }
                 });

            }
        }
    }
}

