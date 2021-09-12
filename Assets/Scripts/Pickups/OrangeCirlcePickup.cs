using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCirclePickup
{
    private float pickupEffectDuration = 3f;
    public float getpickupEffectDuration()
    {
        return pickupEffectDuration;
    }

    public OrangeCirclePickup(float duration) {
        pickupEffectDuration = duration;
    }
}
