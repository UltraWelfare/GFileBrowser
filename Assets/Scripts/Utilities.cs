using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;

namespace GFB {
    public static class Utilities {
        public static readonly float panelHeight = 35.9f;
        public static readonly float spacingY = 2.03f;

        /// <summary>
        /// Used to calculate the height of the scrollview depending on the prefab measurements.
        /// </summary>
        public static float calculateHeight(int count) {
            return (panelHeight + spacingY) * count;
        }

        /// <summary>
        /// Given a filepath it will return the name of the file.
        /// </summary>
        public static string splitNamePath(string path) {
            int pos = path.LastIndexOf("/") + 1;
            return path.Substring(pos, path.Length - pos);
        }

        /// <summary>
        /// Orders alphabetically a list of strings
        /// </summary>
        public static List<string> orderAlphabetically(this List<string> ls) {
            return ls.OrderBy(str => str).ToList();
        }

        /// <summary>
        /// Replaces all backslashes with frontslashes.
        /// </summary>
        public static string fixSlashes(this string str) {
            return str.Replace("\\", "/");
        }

        /// <summary>
        /// Check if the UIClickListener type is the same as a PointerEventData inputbutton
        /// </summary>
        public static bool EqualsToUIType(this UIClickListener.Type t, PointerEventData.InputButton ib) {
            if (ib == PointerEventData.InputButton.Left && t == UIClickListener.Type.LeftClick) { return true; }
            if (ib == PointerEventData.InputButton.Right && t == UIClickListener.Type.RightClick) { return true; }
            return false;
        }

        public static Vector2 CalculateCanvasMousePos(GameObject canvas) {
            Vector2 res;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out res);
            return res;
        }
    }
}

