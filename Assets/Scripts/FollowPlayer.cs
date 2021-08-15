using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Player player;
    private float cameraY;
    private bool hasMovedCamera = false;
    private float initialPositionY;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        initialPositionY = cameraY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMovedCamera) { 
            if (player.transform.position.y > cameraY)
            {
            cameraY = player.transform.position.y;
            hasMovedCamera = true;
            }
        }
        else
            cameraY = player.transform.position.y;

        transform.position = new Vector3(transform.position.x, cameraY, transform.position.z);

        if (transform.position.y <= initialPositionY)
            hasMovedCamera = false;
    }
}
