using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//property of prince lucky santos used with his permission
public class PACCameraMovement : MonoBehaviour
{
    // For moving with the player
    //private GameObject player;

    // For keeping within the bounds of the game
    private Bounds floorBounds;
    private Bounds cameraBounds;
    public Camera playerCamera;

    float panSpeed = 100f;


    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        // Setup for the boundaries for the Camera
        floorBounds = GameObject.FindGameObjectWithTag("ProperFloor").GetComponent<SpriteRenderer>().bounds;
    }


    void LateUpdate()
    {
        var height = playerCamera.orthographicSize;
        var width = height * playerCamera.aspect;

        var minX = floorBounds.min.x + (0.1f * width);
        var maxX = floorBounds.max.x - (0.1f * width);

        var minY = floorBounds.min.y + (0.1f * height);
        var maxY = floorBounds.max.y - (0.1f * height);

        cameraBounds = new Bounds();

        cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
        );

        // Set new location within the bounds of the game
        var targetPosition = getWithinBounds(transform.position);

        // Backup Code to follow the player
        //var targetPosition = player.transform.position;
        //targetPosition.z = -10;

        transform.position = targetPosition;

        // Debug for the boundaries
        /*Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.min.x, floorBounds.min.y,0), Color.blue);
        Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.min.x, floorBounds.max.y, 0), Color.blue);
        Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.max.x, floorBounds.min.y, 0), Color.blue);
        Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.max.x, floorBounds.max.y, 0), Color.blue);
    
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.min.x, cameraBounds.min.y, 0), Color.red);
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.min.x, cameraBounds.max.y, 0), Color.red);
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.max.x, cameraBounds.min.y, 0), Color.red);
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.max.x, cameraBounds.max.y, 0), Color.red);*/

    }

    private Vector3 getWithinBounds(Vector3 positionInGame)
    {
        return new Vector3(
            Mathf.Clamp(positionInGame.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(positionInGame.y, cameraBounds.min.y, cameraBounds.max.y),
            -10
        );
    }
}
