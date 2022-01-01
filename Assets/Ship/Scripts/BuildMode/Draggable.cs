using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add callbacks for sounds and stuff
public class Draggable : MonoBehaviour
{
    public static float SNAP_RANGE = 0.5f;

    public Vector3 fallbackLocalPosition = new Vector3(0f, -2f, 0f);
    public Vector3 initialPosition;
    private DraggableSlot? previousSlot;

    // TODO: Refactor to enum state, add a state for animated snapping
    private bool isDragged = false;

    private Camera camera;

    public void Start()
    {
        initialPosition = transform.position;
        camera = FindObjectOfType<Camera>();
    }

    public void OnMouseDrag()
    {
        if (!isDragged)
        {
            return;
        }

        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    public void OnMouseDown()
    {
        SetDragged(true);
    }

    public void OnMouseUp()
    {
        SetDragged(false);
    }

    public void SnapToSlot(DraggableSlot? slot)
    {
        Debug.Log("Snapping to "+ slot);
        bool didAttach = tryAttach(slot);
        if (didAttach)
        {
            return;
        }

        didAttach = tryAttach(previousSlot);
        if (didAttach)
        {
            return;
        }

        //pizdec
        if (!didAttach)
        {
            transform.position = initialPosition;
        }
    }

    private bool tryAttach(DraggableSlot? slotToSnapTo) {
        if (slotToSnapTo == null)
        {
            return false;
        }

        var didAttach = slotToSnapTo.AttachDraggable(this);

        if (didAttach) 
        {
            var slotPosition = slotToSnapTo.GetPosition();
            transform.position = new Vector3(slotPosition.x, slotPosition.y, transform.position.z);
            // transform.SetParent(slotToSnapTo.gameObject.transform);

            previousSlot = slotToSnapTo;
        }
        return didAttach;
    }

    public void SetDragged(bool isDragged)
    {
        this.isDragged = isDragged;

        // Ugly way to display on top of other parts
        transform.position = new Vector3(transform.position.x, transform.position.y, (this.isDragged ? -1 : 1) * 0.000001f);

        if (this.isDragged)
        {
            //previousPosition = transform.position;
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
}
