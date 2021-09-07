using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] float pickupEffectScaleModifier;
    [SerializeField] float pickupEffectDuration;

    public static event Action<object> pickupTaken;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Constants.PLAYER_TAG))
        {
            if (gameObject.tag.Equals(Constants.PICKUP_GREEN_DIAMOND_TAG))
            {
                print("Player picked up " + gameObject.tag);
                GreenDiamondPickup greenDiamondPickup = new GreenDiamondPickup(pickupEffectScaleModifier, pickupEffectDuration);
                pickupTaken?.Invoke(greenDiamondPickup);
            } else if (gameObject.tag.Equals(Constants.PICKUP_HEART_TAG))
            {
                print("Player picked up " + gameObject.tag);
                HeartLifePickup heartLifePickup = new HeartLifePickup((int)pickupEffectScaleModifier);
                pickupTaken?.Invoke(heartLifePickup);
            }
            Destroy(gameObject);
        }
    }
}
