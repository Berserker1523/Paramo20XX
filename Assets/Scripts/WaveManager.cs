using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject zombie;

    private int numberOfZombiesToSpawnInEachGateThisRound = 1;
    private int numberOfZombiesToSpawnInThisRound;
    private int timeBetweenRounds = 10;
    private int currentRound = 1;
    private float waitTimeToSpawnAmongGates = 7f;
    private bool currentRoundFinished = false;

    private HordeManager hordeManager;
    private GameObject[] startPoints;

    private List<GameObject> instantiatedZombies = new List<GameObject>();

    void Start()
    {
        hordeManager = FindObjectOfType<HordeManager>();
        hordeManager.AddHorde();
        startPoints = GameObject.FindGameObjectsWithTag(GameTags.ZombieStartPoint.ToString());
        Invoke("SpawnZombies", 10);
        numberOfZombiesToSpawnInThisRound = numberOfZombiesToSpawnInEachGateThisRound * startPoints.Length;
    }

    private void Update()
    {
        if(currentRoundFinished && AllZombiesAreDead())
        {
            hordeManager.AddHorde();
            currentRound += 1;
            numberOfZombiesToSpawnInEachGateThisRound = currentRound;
            waitTimeToSpawnAmongGates = waitTimeToSpawnAmongGates - 1 < 2 ? 2 : waitTimeToSpawnAmongGates - 1;
            currentRoundFinished = false;
            numberOfZombiesToSpawnInThisRound = numberOfZombiesToSpawnInEachGateThisRound * startPoints.Length;
            Invoke("SpawnZombies", timeBetweenRounds);
        }
    }

    private void SpawnZombies()
    {
        if (numberOfZombiesToSpawnInThisRound <= 0)
        {
            currentRoundFinished = true;
            return;
        }

        StartCoroutine(ZombieSpawn());
    }

    int i;
    int k;
    int z;
    int j;

    private IEnumerator ZombieSpawn()
    {
        for (i = 0; i < startPoints.Length; i++)
        {
            k = Random.Range(0, startPoints.Length);
            z = Random.Range(1, numberOfZombiesToSpawnInEachGateThisRound + 1);
            for(j = 0; j < z; j++)
            {
                Vector3 gatePosition = startPoints[k].transform.position;
                instantiatedZombies.Add(Instantiate(zombie, new Vector3(Random.Range(gatePosition.x - 2f, gatePosition.x + 2f), gatePosition.y, Random.Range(gatePosition.z - 2f, gatePosition.z + 2f)), Quaternion.identity));
                numberOfZombiesToSpawnInThisRound--;
                if (numberOfZombiesToSpawnInThisRound <= 0)
                {
                    currentRoundFinished = true;
                    StopAllCoroutines();
                }
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(waitTimeToSpawnAmongGates);
        }
        Invoke("SpawnZombies", waitTimeToSpawnAmongGates);
    }

    private bool AllZombiesAreDead()
    {
        foreach(GameObject zombie in instantiatedZombies)
        {
            if (zombie != null)
                return false;
        }
        instantiatedZombies.Clear();
        return true;
    }
}
