using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraAround : MonoBehaviour
{
    Transform camera_Pos;

    float currentTime;
    float maxTime = 0.2f;

    float panSpeed = 100f;
    // Start is called before the first frame update
    void Awake()
    {
        camera_Pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //while holding down right click and dragging move the camera towards opposite position
        if (Input.GetMouseButton(1))
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            // translates to the opposite direction of mouse position.
            transform.Translate(-newPosition);
        }


        if (Camera.main.orthographicSize - (0.2f * Input.mouseScrollDelta.y) > 3 && Camera.main.orthographicSize - (0.2f * Input.mouseScrollDelta.y) < 10)
        {
            Camera.main.orthographicSize -= (0.2f * Input.mouseScrollDelta.y);
        }
    }
}
