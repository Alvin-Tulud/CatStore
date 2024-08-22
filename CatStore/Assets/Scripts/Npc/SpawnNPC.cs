using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    float currentTime;
    float maxTime = 3.5f;
    float currentInterval;
    float spawnSpeedUpInterval = 10f;
    float maxTimeDecrement = 0.1f;

    public GameObject npc_to_spawn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.fixedTime;
        currentInterval = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - currentTime > maxTime)
        {
            spawnRandomSpot();
            currentTime = Time.fixedTime;
        }
        if (Time.time - currentInterval > spawnSpeedUpInterval)
        {
            if (maxTime - maxTimeDecrement > 0)
            {
                maxTime -= maxTimeDecrement;
            }
            currentInterval = Time.fixedTime;
        }
    }

    private void spawnRandomSpot()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("spawnpoint");
        int randpoint = Random.Range(0, points.Length);

        Instantiate(npc_to_spawn, points[randpoint].transform);
    }
}
