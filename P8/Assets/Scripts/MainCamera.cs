using UnityEngine;

public class MainCamera : MonoBehaviour {
    // ------------------------------------- Phone touch -----------------------------------------------------
// tank værdi skal manual justeres 
    // Vector3 touchStart;
    // public float zoomOutMin = 1;
    // public float zoomOutMax = 8;
    // public float zoomHaste = 5;
    // private Camera camera1;
    //
    // // Update is called once per frame
    // private void Start() {
    //     camera1 = Camera.main;
    // }
    //
    // void Update () {
    //     if(Input.GetMouseButtonDown(0)){
    //         touchStart = camera1.ScreenToWorldPoint(Input.mousePosition);
    //     }
    //     if(Input.touchCount == 2){
    //         Touch touchZero = Input.GetTouch(0);
    //         Touch touchOne = Input.GetTouch(1);
    //
    //         Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
    //         Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
    //
    //         float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
    //         float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
    //
    //         float difference = currentMagnitude - prevMagnitude;
    //
    //         zoom(difference * zoomHaste);
    //     }else if(Input.GetMouseButton(0)){
    //         Vector3 direction = touchStart - camera1.ScreenToWorldPoint(Input.mousePosition);
    //         camera1.transform.position += direction;
    //     }
    //     zoom(Input.GetAxis("Mouse ScrollWheel"));
    // }
    //
    // void zoom(float increment){
    //     camera1.orthographicSize = Mathf.Clamp(camera1.orthographicSize - increment, zoomOutMin, zoomOutMax);
    // }

    // --------------------------------- Keyboard -----------------------------------------------------------------
    // tank værdi: moveSpeed = 500, mapSize x: 1000, y: 1000, zoomSpeed = 15, minZoom = 10, maxZoom = 500

    public float moveSpeed = 5f; // hvor hurtigt kameraet bevæger sig
    public Vector2 mapSize = new Vector2(20f, 20f);
    public float zoomSpeed = 0.1f; // Hvor hurtigt den zoomer
    public float minZoom = 1f; // Min zoom level
    public float maxZoom = 5f; // Max zoom level
    public float duration = 10;
    public float transitionTime = 1f;
    Vector3 targetPos = new Vector3(-1.529f, 5.332f, 0);

    void Update() {
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


        Vector3 newPosition = Vector3.Lerp(transform.position, targetPos, Time.deltaTime / transitionTime);
        transform.position = newPosition;

    }


    public void MoveToSelection(Vector3 target) {
        Vector3 targetPos = new Vector3(target.x, target.y, 0);
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPos, Time.deltaTime / transitionTime);
        transform.position = targetPos;
        }

        // Vector3 velocity = Vector3.zero;
        // transform.position = targetPos;
    }
