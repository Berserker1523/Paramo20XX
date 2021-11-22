using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private Sprite liveEmpty;
    [SerializeField] private Sprite liveComplete;
    private GameObject[] lives;
    private int health = 3;

    private SceneChanger sceneChanger;
    private GameObject painUI;

    private void Start()
    {
        lives = GameObject.FindGameObjectsWithTag(GameTags.Live.ToString());
        sceneChanger = GameObject.FindGameObjectWithTag(GameTags.SceneChanger.ToString()).GetComponent<SceneChanger>();
        painUI = GameObject.FindGameObjectWithTag(GameTags.PainUI.ToString());
    }
    public void Hurt()
    {
        health--;
        painUI.GetComponent<Image>().enabled = true;
        Invoke("StopPainUI", 0.3f);
        lives[health].GetComponent<Image>().sprite = liveEmpty;

        if (health == 0)
        {
            Debug.Log("Se murio :( ");
            sceneChanger.ChangeToScene(SceneChanger.SceneName.Message, FadeCanvasController.FadeAnimatorParameter.FadeInWhite);
        }
    }

    private void StopPainUI()
    {
        Debug.Log($"StopPainUI");
        painUI.GetComponent<Image>().enabled = false;
    }
}
