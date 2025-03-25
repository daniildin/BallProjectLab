using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    Timer timer = new Timer();
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.duration = 5.0f;
        timer.run();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.finished)
        {
            float elapsedTime = Time.time - startTime;
            Debug.Log($"Time ran: {elapsedTime} seconds");
            timer.run();
            startTime = Time.time;

         
        }
    }
}
