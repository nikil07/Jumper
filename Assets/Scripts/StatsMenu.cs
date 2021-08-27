using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text maxPlatformsText;
    [SerializeField] TMP_Text longestTimeText;
    [SerializeField] TMP_Text totalPlatformsPassedText;
    [SerializeField] TMP_Text totalPlatformsHitText;

    private void Start()
    {
        GameState.gameOver += updateStatsScreen;
    }

    private void OnEnable()
    {
        updateStatsScreen();
    }

    private void OnDestroy()
    {
        GameState.gameOver -= updateStatsScreen;
    }

    private void updateStatsScreen() {
        print("updating all texts");
        setHighScoreText();
        setHighestPlatformsText();
        setLongestTimeText();
        setTotalPlatformsHitText();
        setTotalPlatformsPassedText();
    }

    private void setHighScoreText() {
        highScoreText.SetText(PlayerPrefsStorage.getHighScore().ToString());
    }
    private void setHighestPlatformsText()
    {
        maxPlatformsText.SetText(PlayerPrefsStorage.getHighestPlatforms().ToString());
    }
    private void setLongestTimeText()
    {
        longestTimeText.SetText(PlayerPrefsStorage.getLongestTime().ToString());
    }
    private void setTotalPlatformsHitText()
    {
        totalPlatformsHitText.SetText(PlayerPrefsStorage.getTotalPlatformsHit().ToString());
    }
    private void setTotalPlatformsPassedText()
    {
        totalPlatformsPassedText.SetText(PlayerPrefsStorage.getTotalPlatformsPassed().ToString());
    }
}
