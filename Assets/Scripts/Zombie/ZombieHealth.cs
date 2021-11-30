using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private float health = 1.5f;
    private float hitTimer;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag(GameTags.ScoreManager.ToString()).GetComponent<ScoreManager>();
        //Invoke("Test", 5);
    }

    /*private void Test()
    {
        scoreManager.AddScore();
        Destroy(gameObject);
    }*/

    public float HitTimer
    {
        get { return hitTimer; }
        set
        {
            hitTimer = value;
            //Debug.Log(HitTimer);
            if (hitTimer > health)
            {
                scoreManager.AddScore();
                Destroy(gameObject);
            }  
        }
    }
}
