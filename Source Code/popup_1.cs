using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup_1 : MonoBehaviour {
    float t=0;
    bool timerRun = true;
    public float waitTime = 750;
    // Use this for initialization
    void Timer()
    {
        t += 1;
        if (t > waitTime)
        {
            t = 0;
            timerRun = false;
            Object.Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        if (timerRun)
        {
            Timer();
        }
    }
}
