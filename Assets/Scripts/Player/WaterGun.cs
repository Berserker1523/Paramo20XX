using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [SerializeField] private OVRInput.Controller controller;
    [SerializeField] private ParticleSystem water;

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        bool primaryHandTrigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller);
        if (primaryHandTrigger)
            water.Play();
        else
            water.Stop();
    }
}
