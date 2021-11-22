using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public enum SceneName
    {
        Dialogos,
        VidaNaturalCinematic1,
        DialogosFuturo,
        Apocalipsis,
        Message,
        Creditos
    }

    private FadeCanvasController fadeCanvasController;

    private void Start() =>
        fadeCanvasController = GameObject.FindGameObjectWithTag(GameTags.FadeCanvas.ToString()).GetComponent<FadeCanvasController>();

    public void ChangeToScene(SceneName sceneName, FadeCanvasController.FadeAnimatorParameter fadeAnimatorParameter) =>
        StartCoroutine(LoadScene(sceneName, fadeAnimatorParameter));

    private IEnumerator LoadScene(SceneName sceneName, FadeCanvasController.FadeAnimatorParameter fadeAnimatorParameter)
    {
        fadeCanvasController.SetFadeTo(fadeAnimatorParameter);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName.ToString());
    }
}
