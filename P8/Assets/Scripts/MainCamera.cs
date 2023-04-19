using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float moveSpeed = 5f; // hvor hurtigt kameraet bevæger sig
    public Vector2 mapSize = new Vector2(20f, 20f);
    public float zoomSpeed = 0.1f; // Hvor hurtigt den zoomer
    public float minZoom = 1f; // Min zoom level
    public float maxZoom = 5f; // Max zoom level


    void Update()
    {
         // Få WASD eller piletaster ind i systemet
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 targetPos = transform.position + new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;

        // Lav boundaries til kameraet og flyt
        targetPos.x = Mathf.Clamp(targetPos.x, -mapSize.x / 2f, mapSize.x / 2f);
        targetPos.y = Mathf.Clamp(targetPos.y, -mapSize.y / 2f, mapSize.y / 2f);
        transform.position = targetPos;

        // Få input til systemet når du scroller
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Plus eller minus Scroll-værdien
        float newZoom = Camera.main.orthographicSize - zoomInput * zoomSpeed;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
        Camera.main.orthographicSize = newZoom;
    }
}