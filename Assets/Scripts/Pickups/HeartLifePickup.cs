using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLifePickup
{
    private int numberOfExtraLives;
    

    public int getnumberOfExtraLives() {
        return numberOfExtraLives;
    }
    public HeartLifePickup(int numberOfExtraLives) {
        this.numberOfExtraLives = numberOfExtraLives;
    }
}
