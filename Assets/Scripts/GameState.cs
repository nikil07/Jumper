using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverPopup;
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
    }

    private void OnDestroy()
    {
        Platform.platformPassed -= incrementPlatformsPassed;
        Player.playerHitPlatform -= playerHitPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        updateScoreText();
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
        if (platformHits == 3)
        {
            showGameOver();
        }
    }

    private void showGameOver() {
        gameOverPopup.SetActive(true);
        depthFallenText.SetText("You fell "+ getDepthFallen() + " meters");
        timePlayedText.SetText(getTimeElapsed() + " seconds"); // needs better handling
        gameOver?.Invoke();
        Time.timeScale = 0;
    }

    public void goToHomeScreen() {
        StartCoroutine(goToHomeScreen(0));
    }

    IEnumerator goToHomeScreen(int scene) {
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
    }

    public int getTotalPlatformsPassed() {
        return totalPlatformsPassed;
    }
}