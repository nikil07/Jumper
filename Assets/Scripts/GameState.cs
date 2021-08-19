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
        points = -(int)player.transform.position.y;
        scoreText.SetText(points + "");
    }

    private void playerHitPlatform() {
        platformHits++;
        Debug.Log("GameState : Player hit platform " + platformHits + " times");
        if (platformHits == 3)
        {
            gameOverPopup.SetActive(true);
            gameOver?.Invoke();
            Time.timeScale = 0;
        }
    }

    private void incrementPlatformsPassed() {
        totalPlatformsPassed++;
    }

    public int getTotalPlatformsPassed() {
        return totalPlatformsPassed;
    }
}