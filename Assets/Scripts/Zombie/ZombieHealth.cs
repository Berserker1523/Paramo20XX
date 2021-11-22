using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private float health = 1.5f;
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
