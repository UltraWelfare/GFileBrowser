using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UINavigator
{
    GameObject fb;
    Button backButton, doneButton, redirectButton;
    InputField pathField;
    Browser br;

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

    //----Button Calls----//

    void onBack() {
        br.GoBack();
    }
    
    void onDone() {

    }

    void onRedirect() {
        br.ReloadBrowser(pathField.text, true);
    }

    //----Other UI Calls----//

    public void onBasePanelClick(GBase f, GComponent.Type t) {
        if(t == GComponent.Type.Folder){
            br.ReloadBrowser(f.Path);
        }
    }
}

