using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManosCris : MonoBehaviour
{
    private Animator animator;

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
        if (primaryHandTriggerLTouch)
            animator.SetInteger("Choose", 1);
        else if (primaryHandTriggerRTouch)
            animator.SetInteger("Choose", 2);
    }
}
