using UnityEngine;
using GFB;
public class UIWindowMoveable : MonoBehaviour {

    public GameObject canvas;
    bool isDragging = false;
    Vector2 previousPos;

    public void setCanvas(GameObject canvas) {
        this.canvas = canvas;
    }

    public void StartDragging() {
        previousPos = Utilities.CalculateCanvasMousePos(canvas);
        isDragging = true;
    }

    public void StopDragging() {
        isDragging = false;
    }

    public void Update() {
        if (isDragging) {
            onDragging();
        }
    }

    private void onDragging() {
        Vector2 worldPoint = Utilities.CalculateCanvasMousePos(canvas);
        GetComponent<RectTransform>().anchoredPosition += (worldPoint - previousPos);
        previousPos = worldPoint;
    }
}