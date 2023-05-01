using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draganddrop : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
{
    Transform parentAfterDrag;
    private Draganddrop dragedItem;

    private void Start() {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // GameObject dropped = eventData.pointerDrag;
        // dragedItem = dropped.GetComponent<Draganddrop>();
        // Destroy(dragedItem);
        // dragedItem.parentAfterDrag = transform;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        Destroy(gameObject);
        // transform.SetParent(parentAfterDrag);
    }
}
