using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesSignal : MonoBehaviour
{
    private float radius = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(GameTags.Zombie.ToString()))
        {
            Vector3 positionZombie = other.transform.position;
            Vector3 zombiePlayer = positionZombie - gameObject.transform.position;
            Vector3 vectorPlayer = gameObject.transform.right;
            float angle = Vector3.Angle(vectorPlayer, zombiePlayer);
            float y = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            Debug.Log($" x {x}");
            Debug.Log($" y {y}");
        }
    }
}
