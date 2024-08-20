using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Track_Happiness : MonoBehaviour
{
    Slider happiness_meter;

    float currentTime;
    float maxTime = 0.5f;
    void Awake()
    {
        happiness_meter = GetComponent<Slider>();
        happiness_meter.maxValue = 100;
        happiness_meter.value = 100;

        currentTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - currentTime > maxTime)
        {
            currentTime = Time.fixedTime;
            happiness_meter.value = StoreStats.store_happiness;
        }
    }
}
