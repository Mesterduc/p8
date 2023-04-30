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
    public float smoothTime = 1f;
    private float speed = 0.001f;




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


    public void MoveToSelection(Vector3 target)
    {
        Vector3 targetPos = new Vector3(target.x, target.y, 0);
        float distance = Vector3.Distance(transform.position, targetPos);
        float duration = (distance / speed)*100;
        float t = 0;

        while (t < duration) {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPos, t / duration);
        }

        transform.position = targetPos;

        // Vector3 velocity = Vector3.zero;
        // transform.position = targetPos;
    }


}