using UnityEngine;

public class CreditsToStart : MonoBehaviour
{
    private SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = GameObject.FindGameObjectWithTag(GameTags.SceneChanger.ToString()).GetComponent<SceneChanger>();
    }

    public void GoToStart()
    {
        sceneChanger.ChangeToScene(SceneChanger.SceneName.Dialogos, FadeCanvasController.FadeAnimatorParameter.FadeInBlack);
    }
}
