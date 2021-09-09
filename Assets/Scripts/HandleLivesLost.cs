using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLivesLost : MonoBehaviour
{
    [SerializeField] GameObject firstHeart;
    [SerializeField] GameObject secondHeart;
    [SerializeField] GameObject thirdHeart;

    private int pickupEffectScaleModifier;

    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player.playerHitPlatform += playerHitPlatform;
        Pickup.pickupTaken += handlePickups;
    }

    private void OnDestroy()
    {
        Player.playerHitPlatform -= playerHitPlatform;
        Pickup.pickupTaken -= handlePickups;
    }

    private void handlePickups(object pickup)
    {
        if (pickup.GetType() == typeof(HeartLifePickup))
        {
            pickupEffectScaleModifier = ((HeartLifePickup)pickup).getnumberOfExtraLives();
            print("pickupEffectScaleModifier = " + pickupEffectScaleModifier);
            for (int i = 1; i <=pickupEffectScaleModifier; i++) {
                count -= 1;
                addLives();
            }
            
        }
    }

    private void addLives()
    {
        switch (count)
        {
            case 1:
                //Destroy(thirdHeart);
                thirdHeart.SetActive(true);
                break;
            case 2:
                ///Destroy(secondHeart);
                secondHeart.SetActive(true);
                break;
            case 3:
                //Destroy(firstHeart);
                firstHeart.SetActive(true);
                break;
        }
    }

    private void playerHitPlatform() {
        switch (count) {
            case 1:
                //Destroy(thirdHeart);
                thirdHeart.SetActive(false);
                break;
            case 2:
                ///Destroy(secondHeart);
                secondHeart.SetActive(false);
                break;
            case 3:
                //Destroy(firstHeart);
                firstHeart.SetActive(false);
                break;
        }
        count++;
    }
}
