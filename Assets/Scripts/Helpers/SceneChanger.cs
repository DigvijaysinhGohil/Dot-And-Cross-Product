using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    [SerializeField] private SceneTransitionEffect transition;

    public void LoadScene(string sceneName) {
        transition.OnTweenComplete.AddListener(() => SceneManager.LoadScene(sceneName));
        transition.TransitionIn();
        
    }

    public void LoadSceneAsync(string sceneName) {
        transition.OnTweenComplete.AddListener(() => SceneManager.LoadSceneAsync(sceneName));
        transition.TransitionIn();
    }
}