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
        if (other.tag.Equals(GameTags.PlayerZone.ToString()))
        {
            Vector3 vectorPlayer = other.transform.position; 
            Vector3 zombiePlayer = gameObject.transform.position- vectorPlayer;
            Vector3 positionZombie = gameObject.transform.right;
            float angle = Vector3.Angle(positionZombie, zombiePlayer);
            float y = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            Debug.Log($" x {x}, y {y}");
        }
    }
}
