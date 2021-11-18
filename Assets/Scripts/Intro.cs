using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private List<GameObject> texts;
    private float time;
    private int currentTextIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentTextIndex = 0;
        time = 0.0f;
        HideTextsExcept(currentTextIndex);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        if (time >= 3.0 )
        {
            time = 0;
            currentTextIndex += 1;
            if (currentTextIndex < texts.Count)
            {
                HideTextsExcept(currentTextIndex);
            }
        }
    }

    private void UpdateTime()
    {
        time += Time.deltaTime;
    }

    private void HideTextsExcept(int toShow)
    { 
        texts[toShow].SetActive(true);
        for (var i = 0; i < texts.Count; i++)
        {
            if(i != toShow)
                texts[i].SetActive(false);
        }
    }
}
