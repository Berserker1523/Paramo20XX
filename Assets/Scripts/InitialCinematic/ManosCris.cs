using UnityEngine;
using UnityEngine.SceneManagement;

public class ManosCris : MonoBehaviour
{
    private Animator animator;
    private bool a;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log(2);
        }
    }

    private void GoToApocalipsis()
    {
        SceneManager.LoadScene("DialogosFuturo");
    }
}
