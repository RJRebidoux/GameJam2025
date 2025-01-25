using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    // References
    public Transform[] waypoints; // List of points the camera moves between
    public float speed = 2f; // Speed of the camera
    public Transform player; // Reference to the player

    private int currentIndex = 0;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player's y position
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = player.position.y; 
        transform.position = cameraPosition;

        // Move the camera between waypoints
        Vector3 targetPosition = waypoints[currentIndex].position;
        Debug.Log("Target Position: " + targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
       


        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            // If the platform has reached the target position, switch to the next point
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //transform.position.x = collision.transform.position.x;
            //transform.position.y = collision.transform.position.y;
        }
    }

}
