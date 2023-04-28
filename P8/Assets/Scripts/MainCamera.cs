using System;
using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    public float moveSpeed = 5f; // hvor hurtigt kameraet bevæger sig
    public Vector2 mapSize = new Vector2(20f, 20f);
    public float zoomSpeed = 0.1f; // Hvor hurtigt den zoomer
    public float minZoom = 1f; // Min zoom level
    public float maxZoom = 5f; // Max zoom level
    [SerializeField] public GameObject modal;
    private Boolean isHidden = true;


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
        

        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider == true)
        {
            modal.SetActive(isHidden);
            isHidden = !isHidden;
        }
   }
    }
}