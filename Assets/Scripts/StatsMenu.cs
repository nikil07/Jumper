using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text maxPlatformsText;
    [SerializeField] TMP_Text longestTimeText;
    [SerializeField] TMP_Text totalTimeText;
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
        setTotalTimeText();
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
        longestTimeText.SetText(secondsToString(PlayerPrefsStorage.getLongestTime()));
    }

    private void setTotalTimeText()
    {
        totalTimeText.SetText(secondsToString(PlayerPrefsStorage.getTotalTime()));
    }

    private string secondsToString(int seconds) {
        print("Seconds incoming " + seconds);
        if (seconds < 60)
        {
            return seconds + " seconds";
        }
        else {
            var minutes = seconds / 60;
            if (minutes < 60)
            {
                if(minutes >1)
                    return minutes + " minutes " + (seconds % 60) + " seconds";
                else
                    return minutes + " minute " + (seconds % 60) + " seconds";
            }  
            else {
                if (minutes / 60 > 1)
                {
                    if (minutes % 60 > 1)
                        return (minutes / 60) + " hours " + (minutes % 60) + " mins " + (seconds % 60) + " secs";
                    else
                        return (minutes / 60) + " hours " + (minutes % 60) + " minute " + (seconds % 60) + " secs";
                }
                else
                {
                    if(minutes % 60 > 1)
                        return (minutes / 60) + " hour " + (minutes % 60) + " mins " + (seconds % 60) + " secs";
                    else
                        return (minutes / 60) + " hour " + (minutes % 60) + " minute " + (seconds % 60) + " secs";
                }
            }
        }
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
