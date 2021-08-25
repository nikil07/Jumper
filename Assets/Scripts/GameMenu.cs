using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject homeScreen;
    [SerializeField] GameObject statsScreen;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
