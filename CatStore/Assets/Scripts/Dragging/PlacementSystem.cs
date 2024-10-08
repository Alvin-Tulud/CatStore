using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    GameObject mouseIndicator;
    [SerializeField]
    private InputManager inputManager;

    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedmapPosition();
        mouseIndicator.transform.position = mousePosition;
    }
}
