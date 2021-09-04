using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsGenerator : MonoBehaviour
{
    [SerializeField] int[] randomRangeForSpawning;
    [SerializeField] int[] platformsCriteriaRange = {15,30};
    [SerializeField] int[] timePassedCriteriaRange = { 5, 10 };

    int platformSpawnHeight;
    ObjectRandomizer randomizer;
    private float elapsedTime = 0;
    private Vector3 spawnPoint, previousSpawnPoint;
    private GameState gameState;
    private Player player;

    private int platformsPassed = 0;
    private int platformsCriteria;
    private int timePassed = 0;
    private int timePassedCriteria;

    private bool criteriaMet = false;


    // Start is called before the first frame update
    void Start()
    {
        randomizer = GetComponent<ObjectRandomizer>();
        gameState = FindObjectOfType<GameState>();
        player = FindObjectOfType<Player>();
        Player.increaseDifficulty += updateDifficultyPrams;
        setSpawnDistance();
        updatePlatformCriteria();
        updateTimePassedCriteria();
    }

    private void setSpawnDistance()
    {
        platformSpawnHeight = Random.Range(randomRangeForSpawning[0], randomRangeForSpawning[1]);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = (int)Time.fixedTime;
        //platformsPassed = gameState.getTotalPlatformsPassed();
        //if (elapsedTime % 2 <= Mathf.Epsilon) 
        if(canSpawnPickup())
        {
            GameObject prefab = (GameObject)randomizer.RandomObject();
            print(prefab.transform.name);

            spawnPoint = new Vector3(getRandomX(), getRandomY((int)previousSpawnPoint.y), 1);
            //print(spawnPoint);
            GameObject platform = Instantiate(prefab, spawnPoint, Quaternion.identity, transform);
            previousSpawnPoint = platform.transform.position;
        } 
    }

    /*private bool canSpawnPickup() {
        if (platformsPassed >= platformsCriteria)
        {
            previousSpawnPoint = new Vector3(getRandomX(), player.transform.position.y, 1);
            criteriaMet = true;
            updatePlatformCriteria();
            return criteriaMet;
        }
        else {
            criteriaMet = false;
            return criteriaMet;
        }
    }*/

    private bool canSpawnPickup()
    {

        if (timePassed >= timePassedCriteria)
        {
            previousSpawnPoint = new Vector3(getRandomX(), player.transform.position.y, 1);
            criteriaMet = true;
            updatePlatformCriteria();
            updateTimePassedCriteria();
            return criteriaMet;
        }
        else
        {
            criteriaMet = false;
            return criteriaMet;
        }
    }

    private void updateDifficultyPrams()
    {
        platformSpawnHeight--;
    }

    private float getRandomX()
    {
        return Random.Range(-7, 9);
    }

    private float getRandomY(int previousY)
    {
        return Random.Range(previousY + platformSpawnHeight, previousY + platformSpawnHeight + 3);
    }

    private void updatePlatformCriteria() {
        platformsCriteria = Random.Range(platformsCriteriaRange[0] + platformsPassed, platformsCriteriaRange[1] + platformsPassed);
    }
    private void updateTimePassedCriteria()
    {
        timePassedCriteria = Random.Range(timePassedCriteriaRange[0] + timePassed, timePassedCriteriaRange[1] + timePassed);
    }

}
