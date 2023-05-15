using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 150;
    private float resetPosition = -50f; // X position at which the object will reset
    private float resetPoint = -100f; // X position at which the object will be moved back to the starting position
    private float startPosition; // X position of the initial spawn point

    private void Start()
    {
        startPosition = transform.position.x;
    }

    private void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // Check if the object has passed the reset point
        if (transform.position.x < resetPoint)
        {
            // Move the object back to the starting position
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}