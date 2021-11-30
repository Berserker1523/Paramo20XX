using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private Sprite liveEmpty;
    [SerializeField] private Sprite liveComplete;
    private GameObject[] lives;
    private int health = 3;

    private SceneChanger sceneChanger;
    private GameObject painUI;
    private WaterGun[] waterGuns;

    private void Start()
    {
        lives = GameObject.FindGameObjectsWithTag(GameTags.Live.ToString());
        sceneChanger = GameObject.FindGameObjectWithTag(GameTags.SceneChanger.ToString()).GetComponent<SceneChanger>();
        painUI = GameObject.FindGameObjectWithTag(GameTags.PainUI.ToString());
        waterGuns = FindObjectsOfType(typeof(WaterGun)) as WaterGun[];
    }
    public void Hurt()
    {
        health--;
        painUI.GetComponent<Image>().enabled = true;
        for(int i= 0; i < waterGuns.Length; i++)
        {
            waterGuns[i].EnableHitByZombieVibration(1f);
        }
        Invoke("StopPainUI", 0.3f);
        lives[health].GetComponent<Image>().sprite = liveEmpty;
        Debug.Log($"DOPunchPosition {transform.up.normalized * 0.1f}");
        lives[health].transform.DOPunchPosition(transform.up.normalized * 0.15f, 1);

        if (health == 0)
        {
            Debug.Log("Se murio :( ");
            sceneChanger.ChangeToScene(SceneChanger.SceneName.Message, FadeCanvasController.FadeAnimatorParameter.FadeInWhite);
        }
    }

    private void StopPainUI()
    {
        //Debug.Log($"StopPainUI");
        painUI.GetComponent<Image>().enabled = false;
        for (int i = 0; i < waterGuns.Length; i++)
        {
            waterGuns[i].DisableHitByZombieVibration();
        }
    }
}
