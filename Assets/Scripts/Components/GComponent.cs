using UnityEngine;
using UnityEngine.UI;
public class GComponent : MonoBehaviour {

    GBase holder;

	public void Load(GBase b)
    {
        this.holder = b;
        ReloadUI();
    }

    public void ReloadUI()
    {
        GetComponentInChildren<Text>().text = holder.Name;
    }
}
