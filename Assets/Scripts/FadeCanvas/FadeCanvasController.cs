using UnityEngine;

public class FadeCanvasController : MonoBehaviour
{
    public enum FadeAnimatorParameter
    {
        FadeInWhite,
        FadeOutWhite,
        FadeInBlack,
        FadeOutBlack
    }

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetFadeTo(FadeAnimatorParameter fadeAnimatorParameter)
    {
        animator.SetTrigger(fadeAnimatorParameter.ToString());
    }
}
