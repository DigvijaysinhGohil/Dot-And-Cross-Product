using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class SceneTransitionEffect : MonoBehaviour {
    private float circleWidth;
    
    private RectTransform circleRect;

    [Space, SerializeField] private float time = .5f;

    [HideInInspector] public bool useDelay;
    [HideInInspector] public float delay;

    [HideInInspector] public bool overrideWithCurve;
    [HideInInspector] public LeanTweenType easeType = LeanTweenType.easeOutCubic;
    [HideInInspector] public AnimationCurve easeCurve = AnimationCurve.Linear(0, 0, 1, 1);

    [HideInInspector] public UnityEvent OnTweenComplete;

    private void Awake() {
        circleRect = GetComponent<RectTransform>();
        circleWidth = circleRect.rect.size.x;
    }

    private void OnEnable() {
        TransitionOut();
    }

    public void TransitionIn() {
        LTDescr tween = LeanTween.value(gameObject, value => {
            circleRect.anchoredPosition = Vector2.right * value;
        }, circleWidth, 0, time);

        if (useDelay) {
            tween.setDelay(delay);
        }

        if (overrideWithCurve) {
            tween.setEase(easeCurve);
        }
        else {
            tween.setEase(easeType);
        }

        tween.setOnComplete(() => OnTweenComplete?.Invoke());
    }

    public void TransitionOut() {
        LTDescr tween = LeanTween.value(gameObject, value => {
            circleRect.anchoredPosition = Vector2.right * value;
        }, 0, -circleWidth, time);

        if (overrideWithCurve) {
            tween.setEase(easeCurve);
        }
        else {
            tween.setEase(easeType);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneTransitionEffect))]
public class SceneTransitionEffectEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        SceneTransitionEffect controller = target as SceneTransitionEffect;

        EditorGUILayout.Space(5);
        controller.useDelay = GUILayout.Toggle(controller.useDelay, "Use delay");

        if (controller.useDelay) {
            controller.delay = EditorGUILayout.FloatField("Delay", controller.delay);
        }

        EditorGUILayout.Space(1);
        controller.overrideWithCurve = GUILayout.Toggle(controller.overrideWithCurve, "Override with curve");

        EditorGUILayout.Space(1);

        if (controller.overrideWithCurve) {
            controller.easeCurve = EditorGUILayout.CurveField("Spawn curve", controller.easeCurve);
        }
        else {
            controller.easeType = (LeanTweenType) EditorGUILayout.EnumPopup("Ease type", controller.easeType);
        }

        EditorGUILayout.Space(5);
        SerializedProperty spawnEvent = serializedObject.FindProperty("OnTweenComplete");
        EditorGUILayout.PropertyField(spawnEvent);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif