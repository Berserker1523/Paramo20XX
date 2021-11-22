using UnityEngine;

public class ManosCris : MonoBehaviour
{
    private Animator animator;
    private GameObject text;
    private bool a;
    private bool b;
    private float i = 0f;

    private SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Instructions");
        text.SetActive(false);
        animator = GetComponent<Animator>();
        sceneChanger = GameObject.FindGameObjectWithTag(GameTags.SceneChanger.ToString()).GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        i+=Time.deltaTime;
        //Debug.Log(i);
        if (i >= 15)
        {
            //Debug.Log("Entro");
            text.SetActive(true);
        }
        OVRInput.Update();
        bool primaryHandTriggerLTouch = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        bool primaryHandTriggerRTouch = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (primaryHandTriggerRTouch)
        {
            animator.SetInteger("Choose", 1);
            if(!a)
            {
                Invoke("GoToApocalipsis", 4);
                a = true;
            }
            Debug.Log(1);
        }
            
        else if (primaryHandTriggerLTouch)
        {
            animator.SetInteger("Choose", 2);
            if (!b)
            {
                Invoke("GoToCredits", 10);
                b = true;
            }
            Debug.Log(2);
        }
    }

    private void GoToApocalipsis()
    {
        sceneChanger.ChangeToScene(SceneChanger.SceneName.DialogosFuturo, FadeCanvasController.FadeAnimatorParameter.FadeInBlack);
    }

    private void GoToCredits()
    {
        sceneChanger.ChangeToScene(SceneChanger.SceneName.Creditos, FadeCanvasController.FadeAnimatorParameter.FadeInBlack);
    }
}
