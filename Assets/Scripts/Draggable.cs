using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add callbacks for sounds and stuff
public class Draggable : MonoBehaviour
{
    private DraggableSlot? previousSlot = null;

    // TODO: Refactor to enum state, add a state for animated snapping
    private bool isDragged = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void snapToSlot(DraggableSlot? slot)
    {
        var slotToSnapTo = slot ?? previousSlot;
        if (slotToSnapTo is not null)
        {
            transform.position = slot.GetPosition();
        }
    }

    public void OnMouseDrag()
    {
        setDragged(true);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;
    }

    private void setDragged(bool isDragged)
    {
        this.isDragged = isDragged;

    }

    public void OnMouseDown()
    {
        setDragged(true);
    }

    public void OnMouseUp()
    {
        setDragged(false);
    }

    public void OnMouseExit()
    {
        setDragged(false);
    }
}
