using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GFB;

public class UIClickListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    // public List<KeyValuePair<Type, Action>> OnClickListeners
    //     = new List<KeyValuePair<Type, Action>>();

    public List<KeyValuePair<Type, Action>> OnDownListeners
        = new List<KeyValuePair<Type, Action>>();

    public List<KeyValuePair<Type, Action>> OnUpListeners
        = new List<KeyValuePair<Type, Action>>();

    public void AddDownListener(Type t, Action action) {
        OnDownListeners.Add(new KeyValuePair<Type, Action>(t, action));
    }

    public void AddUpListener(Type t, Action action) {
        OnUpListeners.Add(new KeyValuePair<Type, Action>(t, action));
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDownListeners.ForEach(item => {
            if (item.Key.EqualsToUIType(eventData.button)) { item.Value(); }
        });
    }

    public void OnPointerUp(PointerEventData eventData) {
        OnUpListeners.ForEach(item => {
            if (item.Key.EqualsToUIType(eventData.button)) { item.Value(); }
        });
    }

    public enum Type {
        LeftClick,
        RightClick
    }
}