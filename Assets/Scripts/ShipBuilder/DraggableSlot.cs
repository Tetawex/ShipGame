using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableSlot : MonoBehaviour
{
    private Draggable? attachedDraggable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        if (attachedDraggable == draggable)
        {
            attachedDraggable = null;
            return true;
        }

        return false;
    }
}
