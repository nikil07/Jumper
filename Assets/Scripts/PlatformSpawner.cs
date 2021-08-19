using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject largerPlatformPrefab;
    [SerializeField] int platformSpawnHeight;

    private Player player;
    private float elapsedTime = 0;
    private Vector3 spawnPoint, previousSpawnPoint; 

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        previousSpawnPoint = new Vector3(getRandomX(), -12, 1);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.fixedTime;
        //if (elapsedTime % 2 == 0)
        {
            spawnPoint = new Vector3(getRandomX(), getRandomY((int)previousSpawnPoint.y),1);
            //print(spawnPoint);
            GameObject platform = Instantiate(platformPrefab, spawnPoint, Quaternion.identity,transform);
            previousSpawnPoint = platform.transform.position;
        }
    }

    private float getRandomX() {
        return Random.Range(-7, 9);
    }

    private float getRandomY(int previousY)
    {
        return Random.Range(previousY + platformSpawnHeight, previousY + platformSpawnHeight + 3);
    }
}
