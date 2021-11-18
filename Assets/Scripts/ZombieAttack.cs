using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private GameObject player;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameTags.Player.ToString());
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals(GameTags.PlayerZone.ToString()))
        {
            if (time >= 2) 
            {
                time = 0;
                HurtPlayer();
            }
            
        }
    }
   

    private void HurtPlayer()
    {
        player.GetComponent<PlayerHealth>().Hurt();
    }
}
