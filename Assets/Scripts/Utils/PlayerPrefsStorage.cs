using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStorage
{
    public static void resetAllData() {
        PlayerPrefs.DeleteAll();
    }

    public static void setHighScore(int highScore) {
        PlayerPrefs.SetInt(Constants.PLAYER_HIGHSCORE_PLAYERPREF_KEY, highScore > getHighScore() ? highScore : getHighScore()); // Replace with highscore if its > previous one
    }

    public static int getHighScore() {
        return PlayerPrefs.GetInt(Constants.PLAYER_HIGHSCORE_PLAYERPREF_KEY,0);
    }

    public static void setHighestPlatforms(int highestPlatforms) {
        PlayerPrefs.SetInt(Constants.PLAYER_HIGHEST_PLATFORMS_PASSED_PLAYERPREF_KEY, highestPlatforms > getHighestPlatforms() ? highestPlatforms : getHighestPlatforms()); // Replace with highestPlatforms if its > previous one
    }

    public static int getHighestPlatforms() {
        return PlayerPrefs.GetInt(Constants.PLAYER_HIGHEST_PLATFORMS_PASSED_PLAYERPREF_KEY, 0);
    }

    public static void setLongestTime(int longestTime)
    {
        setTotalTime(longestTime);
        PlayerPrefs.SetInt(Constants.PLAYER_LONGEST_TIME_PLAYERPREF_KEY, longestTime > getLongestTime() ? longestTime : getLongestTime()); // Replace with longestTime if its > previous one
    }

    public static int getLongestTime()
    {
        return PlayerPrefs.GetInt(Constants.PLAYER_LONGEST_TIME_PLAYERPREF_KEY, 0);
    }

    public static void setTotalTime(int currentTime)
    {
        PlayerPrefs.SetInt(Constants.PLAYER_TOTAL_TIME_PLAYERPREF_KEY, currentTime + getTotalTime() ); // Replace with longestTime if its > previous one
    }

    public static int getTotalTime()
    {
        return PlayerPrefs.GetInt(Constants.PLAYER_TOTAL_TIME_PLAYERPREF_KEY, 0);
    }

    public static void setTotalPlatformsPassed(int totalPlatformsPassed)
    {
        //PlayerPrefs.SetInt(Constants.PLAYER_TOTAL_PLATFORMS_PASSED_PLAYERPREF_KEY, totalPlatformsPassed > getTotalPlatformsPassed() ? totalPlatformsPassed : getTotalPlatformsPassed()); // Replace with totalPlatformsPassed if its > previous one
        PlayerPrefs.SetInt(Constants.PLAYER_TOTAL_PLATFORMS_PASSED_PLAYERPREF_KEY, totalPlatformsPassed + getTotalPlatformsPassed()); // Replace with totalPlatformsPassed if its > previous one
    }

    public static int getTotalPlatformsPassed()
    {
        return PlayerPrefs.GetInt(Constants.PLAYER_TOTAL_PLATFORMS_PASSED_PLAYERPREF_KEY, 0);
    }

    public static void setTotalPlatformsHit(int totalPlatformsHit)
    {
        PlayerPrefs.SetInt(Constants.PLAYER_TOTAL_PLATFORMS_HIT_PLAYERPREF_KEY, totalPlatformsHit + getTotalPlatformsHit()); // Replace with totalPlatformsHit if its > previous one
    }

    public static int getTotalPlatformsHit()
    {
        return PlayerPrefs.GetInt(Constants.PLAYER_TOTAL_PLATFORMS_HIT_PLAYERPREF_KEY, 0);
    }

    public static void setPlatformWaitTimer(int waitTimer) {
        PlayerPrefs.SetInt(Constants.PLAYER_PLATFORM_HIT_TIMER_PLAYERPREF_KEY, waitTimer);
    }

    public static int getPlatformWaitTimer() {
        return PlayerPrefs.GetInt(Constants.PLAYER_PLATFORM_HIT_TIMER_PLAYERPREF_KEY, 1);
    }
}
