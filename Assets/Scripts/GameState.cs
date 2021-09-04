using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private int totalLives = 1;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverPopup;
    [SerializeField] GameObject floatingJoyStick;
    [SerializeField] TMP_Text depthFallenText;
    [SerializeField] TMP_Text timePlayedText;

    public static event Action increaseDifficulty;
    public static event Action gameOver;

    private Player player;
    private int totalPlatformsPassed = 0;
    private int platformHits = 0;
    int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        points = (int)player.transform.position.y;
        Platform.platformPassed += incrementPlatformsPassed;
        Player.playerHitPlatform += playerHitPlatform;
        Pickup.pickupTaken += handlePickups;
    }

    private void OnDestroy()
    {
        Platform.platformPassed -= incrementPlatformsPassed;
        Player.playerHitPlatform -= playerHitPlatform;
        Pickup.pickupTaken -= handlePickups;
    }

    private void handlePickups(string pickup) { 
        
    }

    // Update is called once per frame
    void Update()
    {
        //updateScoreText();
    }

    public void restartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void updateScoreText() {
        //points = -(int)player.transform.position.y;
        points = totalPlatformsPassed;
        scoreText.SetText(points + "");
    }

    private void playerHitPlatform() {
        platformHits++;
        Debug.Log("GameState : Player hit platform " + platformHits + " times");
        if (platformHits == totalLives)
        {
            showGameOver();
        }
    }

    private void showGameOver() {
        gameOverPopup.SetActive(true);
        floatingJoyStick.SetActive(false);
        depthFallenText.SetText("You fell "+ getDepthFallen() + " meters");
        timePlayedText.SetText(getTimeElapsed() + " seconds"); // needs better handling
        updateStatsData();
        gameOver?.Invoke();
        Time.timeScale = 0;
    }

    private void updateStatsData() {
        PlayerPrefsStorage.setHighScore(getDepthFallen());
        PlayerPrefsStorage.setLongestTime(getTimeElapsed());
        PlayerPrefsStorage.setHighestPlatforms(totalPlatformsPassed);
        PlayerPrefsStorage.setTotalPlatformsPassed(totalPlatformsPassed);
        PlayerPrefsStorage.setTotalPlatformsHit(platformHits);
    }

    public void goToHomeScreen() {
        Time.timeScale = 1;
        StartCoroutine(goToHomeScreenDelayed(0));
    }

    IEnumerator goToHomeScreenDelayed(int scene) {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    private int getTimeElapsed() {
        // Time shouldnt count when standing on platform
        int timeElapsed = 0;
        timeElapsed = (int)Time.timeSinceLevelLoad;
        return timeElapsed;
    }

    private int getDepthFallen() {
        int depth = -(int)player.transform.position.y;
        return depth;
    }

    private void incrementPlatformsPassed() {
        totalPlatformsPassed++;
        updateScoreText();
    }

    public int getTotalPlatformsPassed() {
        return totalPlatformsPassed;
    }
}