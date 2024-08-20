using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Togglegameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(StoreStats.store_happiness <= 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void resetScene()
    {
        SceneManager.LoadScene(0);
    }
}
