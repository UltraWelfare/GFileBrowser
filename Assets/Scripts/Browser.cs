
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The abstract class Browser that updates contents on views.
/// </summary>
public abstract class Browser {
    GameObject prefab;
    RectTransform rectTransform;
    protected UINavigator ui;
    protected Transform contentView;

    public Browser(Transform contentView, GameObject prefab, UINavigator ui) {
        this.contentView = contentView;
        rectTransform = this.contentView.GetComponent<RectTransform>();
        this.ui = ui;
    }

    /// <summary>
    /// Reloads the contents. At least one function should be implemented.
    /// </summary>
    public abstract void Reload();
    public virtual void Reload(string path) { throw new NotSupportedException(); }
    public virtual void Reload(string path, bool addToStack) { throw new NotSupportedException(); }

    /// <summary>
    /// Destroys all the objects inside the content view.
    /// You can optionally pass a function that will give you in each iteration of the deletion, 
    /// the item that is going to be deleted.
    /// </summary>
    public void Clear(Action<Transform> fun = null) {
        for (int i = 0; i < contentView.childCount; i++) {
            Transform item = contentView.GetChild(i);
            if (fun != null) { fun(item); }
            UnityEngine.GameObject.Destroy(item.gameObject);
        }
    }

    /// <summary>
    /// Calculates the new content size and updates the rect transform for the correct height.
    /// </summary>
    protected void recalculateContentSize(int count) {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, Utilities.calculateHeight(count));
    }

    /// <summary>
    /// Instantiates GBase objects inside the content view.
    /// You can optionally pass a function that will give you the GBase and the GameObject that is created (after each iteration).
    /// </summary>
    protected void inst(List<GBase> ls, Action<GBase, GameObject> fun = null) {
        var newls = ls.OrderBy(item => item.Name).ToList();
        newls.ForEach(item => {
            GameObject f = GameObject.Instantiate(GFileBrowser.Resources.basePrefab, contentView, false);
            if (fun != null) { fun(item, f); }
        });
    }
}