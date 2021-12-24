using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add callbacks for sounds and stuff
public class Draggable : MonoBehaviour
{
    public static float SNAP_RANGE = 0.5f;

    private Vector3 previousPosition;
    private DraggableSlot? previousSlot;

    // TODO: Refactor to enum state, add a state for animated snapping
    private bool isDragged = false;

    public void Start()
    {
        previousPosition = transform.position;
    }

    public void SnapToSlot(DraggableSlot? slot)
    {
        var slotToSnapTo = slot ?? previousSlot;

        if (slotToSnapTo == null)
        {
            transform.position = previousPosition;
            return;
        }

        var didAttach = slotToSnapTo.AttachDraggable(this);

        if (didAttach)
        {
            transform.position = slotToSnapTo.GetPosition();
            // transform.SetParent(slotToSnapTo.gameObject.transform);

            previousSlot = slotToSnapTo;
        }
        else
        {
            transform.position = previousPosition;
        }
    }
    public void OnMouseDrag()
    {
        //if (!isDragged)
        //{
        //    return;
        //}

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    private void setDragged(bool isDragged)
    {
        this.isDragged = isDragged;

        // Ugly way to display on top of other parts
        this.transform.position += new Vector3(0f, 0f, (this.isDragged ? -1 : 1) * 0.000001f);

        if (this.isDragged)
        {
            previousPosition = transform.position;
            previousSlot?.DetachDraggable(this);
        }
        else
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
            }
            else
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
}
