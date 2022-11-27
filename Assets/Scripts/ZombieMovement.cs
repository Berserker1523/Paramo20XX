using UnityEngine;
using UnityEngine.AI;
public class ZombieMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(GameTags.PlayerZone.ToString());
        navMeshAgent.SetDestination(player.transform.position);
        animator = GameObject.FindGameObjectWithTag(GameTags.Zombie.ToString()).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(GameTags.PlayerZone.ToString()))
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("Ataca", true);
        }
    }
}
