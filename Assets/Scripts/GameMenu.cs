using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using EasyMobile;
using System;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject homeScreen;
    [SerializeField] GameObject statsScreen;
    [SerializeField] GameObject settingsScreen;

    [SerializeField] TMP_Text platformWaitTimeSliderText;
    [SerializeField] Slider platformWaitTimeSlider;

    // Start is called before the first frame update
    void Start()
    {
        platformWaitTimeSlider.value = PlayerPrefsStorage.getPlatformWaitTimer();
        platformWaitTimeSliderText.SetText(platformWaitTimeSlider.value + " Seconds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        StartCoroutine(startGameDelayed(1));
    }

    IEnumerator startGameDelayed(int scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    public void showStatsScreen(bool isOpen) {
        homeScreen.SetActive(!isOpen);
        statsScreen.SetActive(isOpen);
    }

    public void showSettingsScreen(bool isOpen)
    {
        homeScreen.SetActive(!isOpen);
        settingsScreen.SetActive(isOpen);
    }

    public void resetData() {
        PlayerPrefsStorage.resetAllData();
        FindObjectOfType<StatsMenu>().updateStatsScreen();
        NativeUI.ShowToast("Data cleared");
    }

    public void handlePlatformWaitTimeChanged(float waitTimer) {
        platformWaitTimeSliderText.SetText(platformWaitTimeSlider.value + " Seconds");
        PlayerPrefsStorage.setPlatformWaitTimer((int)waitTimer);
    }
}
