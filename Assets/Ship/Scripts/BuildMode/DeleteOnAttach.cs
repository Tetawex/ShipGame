using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnAttach : MonoBehaviour
{
    private DraggableSlot draggableSlot;
    private AudioSource audioSource;

    private void Awake()
    {
        draggableSlot = GetComponent<DraggableSlot>();
        audioSource = GetComponent<AudioSource>();

        draggableSlot.OnDraggedOnto += DeleteOnDrag;
    }

    private void DeleteOnDrag(Draggable draggable)
    {
        audioSource.Play();
        draggableSlot.DetachDraggable(draggable);
        Destroy(draggable.gameObject);
    }
}
