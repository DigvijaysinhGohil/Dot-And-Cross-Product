using UnityEngine;

public class DragHandler : MonoBehaviour {
    public bool isDragging;

    private Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    private void OnMouseDown() {
        isDragging = true;
    }

    private void OnMouseUp() {
        isDragging = false;
    }

    private void Update() {
        HandleDrag();
    }

    private void HandleDrag() {
        if (!isDragging) {
            return;
        }

        Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0f;

        transform.position = newPos;
    }
}
