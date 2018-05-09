using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokDestroy : MonoBehaviour {
    int TimesHit = 0;
    public GameObject projectile;

    // Use this for initialization
   void OnTriggerEnter2D(Collider2D projectile)
    {
        TimesHit += 1;

        if (TimesHit == 2)
        {
            Destroy(gameObject);
        }
        
    }

}
