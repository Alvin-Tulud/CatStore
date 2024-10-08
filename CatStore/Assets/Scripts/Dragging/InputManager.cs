using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    private Vector3 lastPosition;

    [SerializeField]
    private LayerMask placementLayermask;

    public Vector3 GetSelectedmapPosition()
    {
        //Debug.Log("mousePos: " + Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, placementLayermask))
        {
            lastPosition = hit.point;
            Debug.Log("lastPos: " + lastPosition);
        }
        return lastPosition;
    }
}
