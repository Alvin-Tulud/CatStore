using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide_Menu : MonoBehaviour
{
    private bool hidden;
    private bool startsliding;
    private Transform menu_to_move;
    private Vector3 menu_init_pos;
    private Vector3 menu_final_pos;
    private Button menu_button;
    private Image arrow_to_flip;

    private float countUp;
    private const float maxCount = 50f;
    // Start is called before the first frame update
    void Awake()
    {
        hidden = false;
        startsliding = false;
        menu_to_move = transform.parent;
        menu_button = GetComponent<Button>();
        arrow_to_flip = transform.GetChild(0).GetComponent<Image>();

        menu_init_pos = new Vector3(0, 0, 0);
        menu_final_pos = new Vector3(-480, 0, 0);

        Debug.Log("init: " + menu_init_pos);
        Debug.Log("final: " + menu_final_pos);
    }

    private void FixedUpdate()
    {
        /*
        set button to not interactable when sliding
        if hidden true hide the menu slide it to left
            lerp on x axis for like 1 second maybe
            when done flip startsliding to false
        else slide it out to right
            lerp on x axis for 1 second
            when done flip startsliding to false
        */

        menu_button.interactable = !startsliding;
        if (hidden && startsliding)
        {
            arrow_to_flip.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            lerpFromTo(menu_init_pos, menu_final_pos);
        }
        else if (!hidden && startsliding)
        {
            arrow_to_flip.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            lerpFromTo(menu_final_pos, menu_init_pos);
        }
    }

    public void clickToMove() 
    { 
        hidden = !hidden;
        startsliding = true;

        countUp = 0f;
    }

    //lerps the menu over the time frame of 1 second
    private void lerpFromTo(Vector3 from, Vector3 to)
    {
        if (countUp <= maxCount)
        {
            menu_to_move.localPosition = new Vector3(Mathf.Lerp(from.x, to.x,countUp / maxCount), menu_init_pos.y, menu_init_pos.z);
            countUp++;
            //Debug.Log("from: " + from.x + ", to: " + to.x + ", current: " + menu_to_move.position.x);
        }
        else
        {
            startsliding = false;
        }
    }
}
