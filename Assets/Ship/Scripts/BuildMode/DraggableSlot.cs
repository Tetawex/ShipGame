using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableSlot : MonoBehaviour
{
    private Draggable? attachedDraggable;

    public Action<Draggable> OnDraggedOnto;

    public Draggable? GetDraggable()
    {
        return attachedDraggable;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //eventData.pointerDrag = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    /*
     * true - did attach
     * false - did not attach
     */
    public bool AttachDraggable(Draggable draggable)
    {
        if (OnDraggedOnto != null)
        {
            OnDraggedOnto(draggable);
        }

        Debug.Log(attachedDraggable);
        if (attachedDraggable != null)
        {
            return false;
        }

        attachedDraggable = draggable;

        return true;
    }

    /*
     * true - did detach
     * false - did not detach
    */
    public bool DetachDraggable(Draggable draggable)
    {
        attachedDraggable = null;
        return true;

        if (attachedDraggable == draggable)
        {
            attachedDraggable = null;
            return true;
        }

        return false;
    }
}
