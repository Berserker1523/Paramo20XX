using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [SerializeField] private OVRInput.Controller controller;
    [SerializeField] private ParticleSystem water;

    private bool indexTrigger;
    private RaycastHit hit;
    private GameObject hitGameObject;
    private int zombieLayerMask = (1 << (int)GameLayers.ZombieBody) | (1 << (int)GameLayers.ZombieHump);

    private bool aimVibrationEnabled;
    private bool hitByZombieVibrationEnabled;

    private void Update()
    {
        OVRInput.Update();
        indexTrigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller);
        if (indexTrigger)
        {
            water.Play();
            if(!aimVibrationEnabled && !hitByZombieVibrationEnabled)
                EnableVibration(0.25f);
        }
        else
        {
            water.Stop();
            if (!aimVibrationEnabled && !hitByZombieVibrationEnabled)
                DisableVibration();
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, zombieLayerMask))
        {
            if (hit.collider.gameObject != hitGameObject)
            {
                hitGameObject = hit.collider.gameObject;
                if (hitByZombieVibrationEnabled)
                    return;
                if ((1 << hitGameObject.layer & 1 << (int)GameLayers.ZombieHump) != 0)
                {
                    EnableAimVibration(1f);
                    Invoke("DisableAimVibration", 0.3f);
                }
                else
                {
                    EnableAimVibration(0.5f);
                    Invoke("DisableAimVibration", 0.2f);
                }
            }
        }
        else
        {
            hitGameObject = null;
            if (hitByZombieVibrationEnabled)
                return;
            DisableVibration();
        }
    }

    public void EnableHitByZombieVibration(float value)
    {
        hitByZombieVibrationEnabled = true;
        EnableVibration(value);
    }

    public void DisableHitByZombieVibration()
    {
        hitByZombieVibrationEnabled = false;
        DisableVibration();
    }

    private void EnableAimVibration(float value)
    {
        aimVibrationEnabled = true;
        EnableVibration(value);
    }

    private void DisableAimVibration()
    {
        aimVibrationEnabled = false;
        DisableVibration();
    }

    private void EnableVibration(float value)
    {
        OVRInput.SetControllerVibration(value, value, controller);
    }

    private void DisableVibration()
    {
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
