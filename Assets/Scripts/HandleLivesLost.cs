using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLivesLost : MonoBehaviour
{
    [SerializeField] GameObject firstHeart;
    [SerializeField] GameObject secondHeart;
    [SerializeField] GameObject thirdHeart;

    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player.playerHitPlatform += playerHitPlatform;
    }

    private void OnDestroy()
    {
        Player.playerHitPlatform -= playerHitPlatform;
    }

    private void playerHitPlatform() {
        switch (count) {
            case 1:
                Destroy(thirdHeart);
                break;
            case 2:
                Destroy(secondHeart);
                break;
            case 3:
                Destroy(firstHeart);
                break;
        }
        count++;
    }
}
