using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add callbacks for sounds and stuff
public class Draggable : MonoBehaviour
{
    public static float SNAP_RANGE = 0.5f;

    private DraggableSlot? previousSlot = null;

    // TODO: Refactor to enum state, add a state for animated snapping
    private bool isDragged = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SnapToSlot(DraggableSlot? slot)
    {
        var slotToSnapTo = slot ?? previousSlot;
        if (slotToSnapTo != null)
        {
            transform.position = slot.GetPosition();
        }
    }

    public void OnMouseDrag()
    {
        setDragged(true);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    private void setDragged(bool isDragged)
    {
        this.isDragged = isDragged;

        if (this.isDragged == false)
        {
            var result = Physics2D.OverlapCircle(transform.position, SNAP_RANGE);
            var nearestPoint = player.transform.position.NearestOf
            //var closestSlot = gameObject.
            //snapToSlot
        }
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
