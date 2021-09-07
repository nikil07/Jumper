using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDiamondPickup
{
    private float pickupEffectScaleModifier = 0.5f;
    private float pickupEffectDuration = 3f;

    public float getpickupEffectScaleModifier() {
        return pickupEffectScaleModifier;
    }

    public float getpickupEffectDuration()
    {
        return pickupEffectDuration;
    }

    public GreenDiamondPickup(float scaleModifier, float duration) {
        pickupEffectScaleModifier = scaleModifier;
        pickupEffectDuration = duration;
    }
}
