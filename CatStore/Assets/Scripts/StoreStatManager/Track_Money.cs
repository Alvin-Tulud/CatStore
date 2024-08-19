using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Track_Money : MonoBehaviour
{
    private TextMeshProUGUI money_amount;

    float currentTime;
    float maxTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        money_amount = GetComponent<TextMeshProUGUI>();

        currentTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - currentTime > maxTime)
        {
            currentTime = Time.fixedTime;
            money_amount.text = StoreStats.store_Money.ToString();
        }
    }
}
