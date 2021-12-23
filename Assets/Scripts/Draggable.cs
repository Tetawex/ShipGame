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
            float closestSqrDistance = Mathf.Infinity;
            DraggableSlot? closestSlot = null;
            
            var overlaps = Physics2D.OverlapCircleAll(transform.position, SNAP_RANGE);

            foreach (var overlap in overlaps)
            {
                var slot = overlap.GetComponent<DraggableSlot>();
                if (slot != null)
                {
                    var sqrDistance = (transform.position - overlap.transform.position).sqrMagnitude;
                    if (sqrDistance < closestSqrDistance)
                    {
                        closestSlot = slot;
                        closestSqrDistance = sqrDistance;
                    }
                }
            }

            if (closestSlot != null)
            {
                SnapToSlot(closestSlot);
            } else
            {
                SnapToSlot(null);
            }
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
