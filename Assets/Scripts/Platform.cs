using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static event Action platformPassed; 

    // Start is called before the first frame update
    void Start()
    {
        
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
