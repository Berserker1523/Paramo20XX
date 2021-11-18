using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private float health = 3f;
    private float hitTimer;
    public float HitTimer
    {
        get { return hitTimer; }
        set
        {
            hitTimer = value;
            Debug.Log(HitTimer);
            if (hitTimer > health)
                Destroy(gameObject);
        }
    }
}
