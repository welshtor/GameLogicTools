using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableSpawn : MonoBehaviour
{
    private Vector3 originalPos;

    public GameObject DraggableImage;
    internal bool Instantiated = false;
    internal bool locked;

    internal GameObject OtherDraggable;
    internal bool TouchingDraggable;
    internal DraggableImg ImageManager;

    // Start is called before the first frame update
    void Start()
    {
       ImageManager = GameObject.FindGameObjectWithTag("DraggableImage").GetComponent<DraggableImg>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageManager.locked && Instantiated || ImageManager.destroyed )
        {
            Instantiated = false;
        }
        
    }

    public void SpawnDraggable()
    {
        
        if (!Instantiated)
        {
            Debug.Log("Trying to Spawn");

            // Only Execute Code if a draggable image isn't currently active
            Instantiated = true;

            GameObject draggable = Instantiate(DraggableImage, Input.mousePosition, Quaternion.identity);

            draggable.transform.parent = this.transform.parent.transform;

            //Scale the object once made 
            draggable.transform.localScale = new Vector3(1, 1, 1);
            //if(draggable.name == "DraggableUrbanTemplate")
            //{
            //    draggable. = GameObject.Find("DraggableUrbanTemplate").transform.localScale;

            //}

            //if (draggable.name == "DraggableRuralTemplate")
            //{
            //    draggable.transform.localScale = GameObject.Find("DraggableRuralTemplate").transform.localScale;

            //}

            //if (draggable.name == "DraggableSuburbanTemplate")
            //{
            //    draggable.transform.localScale = GameObject.Find("DraggableSuburbanTemplate").transform.localScale;

            //}

            // Set the Image manager to the Script attached to the draggable image
            ImageManager = draggable.gameObject.GetComponent<DraggableImg>();
            
            // MAY NOT NEED originalPos = Input.mousePosition;
        }

        //locked = ImageManager.locked;

        //if (!locked)
        //{


        //    DraggableImage.transform.position = Input.mousePosition;

        //}


    }


    // UNDER REVISION  (MAY NOT NEED) 

    //public void OnMouseUp()
    //{

    //    Debug.Log("Detecting Release of Mouse");
    //    // Set back to false to allow for another draggable image to be created
    //    Instantiated = false;


    //    if (ImageManager.TouchingDraggable)
    //    {
    //        Destroy(ImageManager.OtherDraggable);
    //        // locked Ensures that that the Image replaces the old image without deleting selected Image
    //        locked = true;
    //    }

    //    if (!locked)
    //    {

    //        transform.position = originalPos;
    //        Destroy(DraggableImage.gameObject);

    //    }
    //}

}
