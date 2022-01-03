using UnityEngine;

public class CapsuleFieldOfView : MonoBehaviour {
    private bool inFieldOfVision = false;

    [SerializeField] private float rotationDamping = .5f;
    [SerializeField] private AnimationCurve rotationCurve = AnimationCurve.Linear(0, 0, 1, 1);

    [Space, SerializeField] private float threshold = .8f;
    [SerializeField] private Transform ball;

    [Space, SerializeField] private SpriteRenderer lineOfSight;
    [SerializeField] private Color inSightColor = Color.red;
    [SerializeField] private Color NotInSightColor = Color.green;

    public bool InFieldOfVision {
        get {
            return inFieldOfVision;
        }
        set {
            if (inFieldOfVision == value)
                return;
            
            inFieldOfVision = value;
            ChangeFieldOfViewColor(inFieldOfVision ? inSightColor : NotInSightColor);
        }
    }

    private void OnEnable() {
        Rotate();
    }

    private void OnDisable() {
        LeanTween.cancel(gameObject);
    }

    private void Update() {
        CheckIfBallInFieldOfView();
    }

    private void CheckIfBallInFieldOfView() {
        Vector3 directionToBall = ball.transform.position - transform.position;

        float dotProduct = Vector3.Dot(transform.forward.normalized,
            directionToBall.normalized);

        InFieldOfVision = dotProduct >= threshold;
    }

    private void ChangeFieldOfViewColor(Color color) {
        float time = .5f;
        LeanTween.value(gameObject, newColor => {
                lineOfSight.color = newColor;
            }, lineOfSight.color, color, time)
            .setEase(rotationCurve);
    }

    private void Rotate() {
        int angle = Random.Range(0, 360);
        Vector3 rotation = Vector3.up * angle;

        LeanTween.rotateLocal(gameObject, rotation, rotationDamping)
            .setEase(rotationCurve)
            .setOnComplete(Rotate);
    }
}