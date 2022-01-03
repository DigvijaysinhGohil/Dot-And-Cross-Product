using UnityEngine;

public class LineHandler : MonoBehaviour {
    private LineRenderer lineRenderer;
    
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPositions(new[]{pointA.position, pointB.position});
    }

    private void LateUpdate() {
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);
    }
}
