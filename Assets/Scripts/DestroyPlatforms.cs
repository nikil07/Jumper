using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    private float cameraY;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraY = player.transform.position.y + 30;
        transform.position = new Vector3(transform.position.x, cameraY, transform.position.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
            Destroy(collision.gameObject);
    }
}
