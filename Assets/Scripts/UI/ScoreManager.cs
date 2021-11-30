using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        Invoke("Asd", 2);
    }

    private void Asd()
    {
        AddScore();
        Invoke("Asd", 2);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = $"{score}";
        scoreText.transform.DOPunchPosition(transform.up.normalized * 0.05f, 0.5f);
    }
}
