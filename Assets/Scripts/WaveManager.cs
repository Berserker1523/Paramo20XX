using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int numberOfZombies = 1;
    private int timeBetweenSpawn = 15;
    private int round = 1;
    private GameObject[] startPoints;
    [SerializeField] private GameObject zombie;

    void Start()
    {
        startPoints = GameObject.FindGameObjectsWithTag(GameTags.ZombieStartPoint.ToString());
        Invoke("SpawnZombies", timeBetweenSpawn);
    } 

    private void SpawnZombies()
    {
        if (numberOfZombies <= 0)
        {
            round += 1;
            numberOfZombies = round;
        }
        
        for (int i = 0; i < startPoints.Length; i++)
            Instantiate(zombie, startPoints[i].transform.position, Quaternion.identity);

        numberOfZombies--;

        Invoke("SpawnZombies", timeBetweenSpawn);
    }
}
