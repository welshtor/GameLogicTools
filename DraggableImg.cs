using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DraggableImg : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 originalPos;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    internal bool locked;
    internal bool destroyed = false;

    // Handling for Replacing Other Images
    internal GameObject OtherDraggable;
    internal bool TouchingDraggable;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Entered");

        if (collision.tag == "ValidUIDrop")
        {
            this.transform.position = collision.transform.position;

            locked = true;

            //Debug.Log("Image Placed");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "DraggableImage")
        {
            //Debug.Log("Touching Image");

            TouchingDraggable = true;

            locked = false;

            OtherDraggable = collision.gameObject;

        }

        if (collision.tag == "ValidUIDrop")
        {
            this.transform.position = collision.transform.position;

            locked = true;

            //Debug.Log("Image Placed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        locked = false;
        TouchingDraggable = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!locked)
        {

            this.transform.position = Input.mousePosition;

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (TouchingDraggable)
        {
            Destroy(OtherDraggable);
            // locked Ensures that that the Image replaces the old image without deleting selected Image
            locked = true;
        }

        if (!locked)
        {
            destroyed = true;
            transform.position = originalPos;
            Destroy(this.gameObject);
            
        }
    }
}

