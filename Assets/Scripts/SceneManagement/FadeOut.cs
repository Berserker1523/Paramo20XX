using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private FadeCanvasController.FadeAnimatorParameter fadeAnimatorParameter;
    private FadeCanvasController fadeCanvasController;

    void Awake()
    {
        fadeCanvasController = GameObject.FindGameObjectWithTag(GameTags.FadeCanvas.ToString()).GetComponent<FadeCanvasController>();
        fadeCanvasController.SetFadeTo(fadeAnimatorParameter);
    }
}
