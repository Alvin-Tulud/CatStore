using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide_Menu : MonoBehaviour
{
    private bool hidden;
    private bool startsliding;
    private Transform menu_to_move;
    private Button menu_button;
    // Start is called before the first frame update
    void Start()
    {
        hidden = false;
        startsliding = false;
        menu_to_move = transform.parent;
        menu_button = GetComponent<Button>();
    }

    private void FixedUpdate()
    {
        
    }

    public void clickToMove() 
    { 
        hidden = !hidden;
        startsliding = true;
    }
}
