using UnityEngine;

public class DotAndCrossProducts : MonoBehaviour
{
    public Vector3 GetCrossProduct(Vector3 lhs, Vector3 rhs) {
        return Vector3.Cross(lhs, rhs);
    }

    public float GetDotProduct(Vector3 lhs, Vector3 rhs) {
        return Vector3.Dot(lhs, rhs);
    }
}
