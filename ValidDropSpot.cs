using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ValidDropSpot : MonoBehaviour, IDropHandler 
{
    internal string[] Zones = {"DraggableUrban", "DraggableRural", "DraggableSuburban"} ;
    public string ZoneOnSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "DraggableImage")
        {
            Debug.Log("Image In Slot");

           if(collision.name == "DraggableUrban(Clone)")
            {
                ZoneOnSlot = Zones[0];

                Debug.Log("UrbanZone");
            }

           if(collision.name == "DraggableRural(Clone)")
            {
                ZoneOnSlot = Zones[1];

                Debug.Log("RuralZone");
            }

           if(collision.name == "DraggableSuburban(Clone)")
            {
                ZoneOnSlot = Zones[2];

                Debug.Log("SuburbanZone");
            }

        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
 