using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float pickupEffectScaleModifier;
    private float pickupEffectDuration;


    public static event Action platformPassed;

    // Start is called before the first frame update
    void Start()
    {
        Pickup.pickupTaken += handlePickups;
    }

    private void OnDestroy()
    {
        Pickup.pickupTaken -= handlePickups;
    }

    private void handlePickups(object pickup)
    {
        if (pickup.GetType() == typeof(GreenDiamondPickup))
        {
            pickupEffectScaleModifier = ((GreenDiamondPickup)pickup).getpickupEffectScaleModifier();
            pickupEffectDuration = ((GreenDiamondPickup)pickup).getpickupEffectDuration();
            StartCoroutine( applyPickupEffect());
        }
    }

    IEnumerator applyPickupEffect()
    {
        transform.localScale = new Vector3(transform.localScale.x * pickupEffectScaleModifier, transform.localScale.y, transform.localScale.z);
        yield return new WaitForSeconds(pickupEffectDuration);
        transform.localScale = new Vector3(transform.localScale.x / pickupEffectScaleModifier, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            platformPassed?.Invoke();
            //StartCoroutine(destroySelf());
        }
    }

    IEnumerator destroySelf() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
