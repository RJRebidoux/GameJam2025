using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    // References
    public Transform[] waypoints; // List of points the camera moves between
    public float speed = 2f; // Speed of the camera

    private int currentIndex = 0;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = waypoints[currentIndex].position;
        Debug.Log("Target Position: " + targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = collision.transform.position;
        }
    }

}
