using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GFB;

public class UIClickListener : MonoBehaviour, IPointerClickHandler {

    List<KeyValuePair<Type, Action>> Listeners 
        = new List<KeyValuePair<Type, Action>>();

    public void AddListener(Type buttonType, Action listener) {
        Listeners.Add(new KeyValuePair<Type, Action>(buttonType, listener));
    }

    public void OnPointerClick(PointerEventData eventData) {
        Listeners.ForEach(item => {
            if (item.Key.EqualsToUIType(eventData.button)) { item.Value(); }
        });
    }

    public enum Type {
        LeftClick,
        RightClick
    }
}