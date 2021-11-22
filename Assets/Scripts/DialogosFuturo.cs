using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DialogosFuturo : MonoBehaviour
{
    [SerializeField] private List<GameObject> texts;
    private float time;
    private int currentTextIndex;

    private SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        currentTextIndex = 0;
        time = 0.0f;
        HideTextsExcept(currentTextIndex);
        sceneChanger = GameObject.FindGameObjectWithTag(GameTags.SceneChanger.ToString()).GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        if (time >= 7.0f)
        {
            time = 0;
            currentTextIndex += 1;
            if (currentTextIndex < texts.Count)
            {
                HideTextsExcept(currentTextIndex);
            }
            else if (currentTextIndex == texts.Count)
            {
                HideTextsExcept(-1);
                sceneChanger.ChangeToScene(SceneChanger.SceneName.Apocalipsis, FadeCanvasController.FadeAnimatorParameter.FadeInWhite);
            }
        }
    }

    private void UpdateTime()
    {
        time += Time.deltaTime;
    }

    // Hide all texts excep the one in the position toShow, if toShow is -1 all texts will be hidden
    private void HideTextsExcept(int toShow)
    {
        if (toShow >= 0)
        {
            texts[toShow].SetActive(true);
            for (var i = 0; i < texts.Count; i++)
            {
                if (i != toShow)
                    texts[i].SetActive(false);
            }
        }
        else if (toShow == -1)
        {
            for (var i = 0; i < texts.Count; i++)
            {
                texts[i].SetActive(false);
            }
        }

    }
}
