using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRangeMin = -7;
    public float spawnRangeMax = -1;
    private float startDelay = 5;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
      
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(spawnRangeMin, spawnRangeMax), transform.position.z);

            Instantiate(obstaclePrefab, spawnPos ,obstaclePrefab.transform.rotation);
        }
    }
}
