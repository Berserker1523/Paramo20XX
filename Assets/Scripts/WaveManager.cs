using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int numberOfZombies = 10;
    private int timeBetweenSpawn = 1;
    private GameObject[] startPoints;
    [SerializeField] private GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        startPoints = GameObject.FindGameObjectsWithTag(GameTags.ZombieStartPoint.ToString());
        Invoke("SpawnZombies", timeBetweenSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnZombies()
    {
       
        if (numberOfZombies <= 0)
            return;
        
        for (int i = 0; i < startPoints.Length; i++)
            Instantiate(zombie, startPoints[i].transform);

        numberOfZombies--;

        Invoke("SpawnZombies", timeBetweenSpawn);
    }
}
