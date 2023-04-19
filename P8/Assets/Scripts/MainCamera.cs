using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the camera move speed
    public Vector2 mapSize = new Vector2(20f, 20f);

    public float zoomSpeed = 0.1f; // Adjust this value to control the zoom speed
    public float minZoom = 1f; // Minimum zoom level
    public float maxZoom = 5f; // Maximum zoom level


    void Update()
    {
         // Get keyboard input for camera movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate camera target position
        Vector3 targetPos = transform.position + new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;

        // Clamp camera position to stay inside the map
        targetPos.x = Mathf.Clamp(targetPos.x, -mapSize.x / 2f, mapSize.x / 2f);
        targetPos.y = Mathf.Clamp(targetPos.y, -mapSize.y / 2f, mapSize.y / 2f);

        // Update camera position
        transform.position = targetPos;

        // Get zoom input
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate new zoom level
        float newZoom = Camera.main.orthographicSize - zoomInput * zoomSpeed;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        // Apply zoom to camera
        Camera.main.orthographicSize = newZoom;
    }
}