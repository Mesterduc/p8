using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draganddrop : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("drag");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
    }
}
