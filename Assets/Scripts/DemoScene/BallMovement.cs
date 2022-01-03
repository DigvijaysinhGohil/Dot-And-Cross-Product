using UnityEngine;

public class BallMovement : MonoBehaviour {
    private Vector2 movement;
    private Rigidbody rigidBody;

    [SerializeField] private float torque = 10f;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        MoveBall();
    }

    private void MoveBall() {
        float threshold = .2f;

        if (movement.sqrMagnitude > threshold) {
            Vector3 newTorque = Vector3.Cross(Vector3.up, new Vector3(movement.x, 0, movement.y).normalized);
            rigidBody.AddTorque(newTorque * torque * Time.fixedDeltaTime);
        }
    }
}
