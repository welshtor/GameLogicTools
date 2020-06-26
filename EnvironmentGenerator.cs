using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentGenerator : MonoBehaviour
{
    
    public ValidDropSpot validDrop1;
    public ValidDropSpot validDrop2;
    public ValidDropSpot validDrop3;
    public ValidDropSpot validDrop4;
    public ValidDropSpot validDrop5;
    public ValidDropSpot validDrop6;
    internal string validDrop1_Location;
    internal string validDrop2_Location;
    internal string validDrop3_Location;
    internal string validDrop4_Location;
    internal string validDrop5_Location;
    internal string validDrop6_Location;
    public GameObject [] Areas;
    internal Vector3 zone1_pos = new Vector3(103.5f, 0f, 200.8f);
    internal Vector3 zone2_pos = new Vector3(103.5f, 0f, 500.8f);
    internal Vector3 zone3_pos = new Vector3(103.5f, 0f, 800.8f);
    internal Vector3 zone4_pos = new Vector3(-296.5f, 0f, 200.8f);
    internal Vector3 zone5_pos = new Vector3(-296.5f, 0f, 500.8f);
    internal Vector3 zone6_pos = new Vector3(-296.5f, 0f, 800.8f);


    public void Start()
    {
        // Call to a inner script that initializes the ability to load new objects when loading 
        SceneManagerController.Initialize();
    }

    public void Update()
    {
        validDrop1_Location = validDrop1.ZoneOnSlot;
        validDrop2_Location = validDrop2.ZoneOnSlot;
        validDrop3_Location = validDrop3.ZoneOnSlot;
        validDrop4_Location = validDrop4.ZoneOnSlot;
        validDrop5_Location = validDrop5.ZoneOnSlot;
        validDrop6_Location = validDrop6.ZoneOnSlot;
    }

    public void GenerateEnvironment() 
    {
        // Zone 1's spawning types and locations 


        if (validDrop1_Location == "DraggableUrban")
        {
            Instantiate(Areas[0], zone1_pos, Quaternion.identity );
        }

        else if(validDrop1_Location == "DraggableRural")
        {
            Instantiate(Areas[1], zone1_pos, Quaternion.identity);
        }

        else if(validDrop1_Location == "DraggableSuburban")
        {
            Instantiate(Areas[2], zone1_pos, Quaternion.identity);
        }

        // Zone 2's spawning types and locations 


        if (validDrop2_Location == "DraggableUrban")
        {
            Instantiate(Areas[5], zone2_pos, Quaternion.identity);
        }

        else if (validDrop2_Location == "DraggableRural")
        {
            Instantiate(Areas[3], zone2_pos, Quaternion.identity);
        }

        else if (validDrop2_Location == "DraggableSuburban")
        {
            Instantiate(Areas[4], zone2_pos, Quaternion.identity);
        }

        // Zone 3's spawning types and locations 

        if (validDrop3_Location == "DraggableUrban")
        {
            Instantiate(Areas[7], zone3_pos, Quaternion.identity);
        }

        else if (validDrop3_Location == "DraggableRural")
        {
            Instantiate(Areas[8], zone3_pos, Quaternion.identity);
        }

        else if (validDrop3_Location == "DraggableSuburban")
        {
            Instantiate(Areas[6], zone3_pos, Quaternion.identity);
        }

        // Zone 4's spawning types and locations 


        if (validDrop4_Location == "DraggableUrban")
        {
            Instantiate(Areas[10], zone4_pos, Quaternion.identity);
        }

        else if (validDrop4_Location == "DraggableRural")
        {
            Instantiate(Areas[9], zone4_pos, Quaternion.identity);
        }

        else if (validDrop4_Location == "DraggableSuburban")
        {
            Instantiate(Areas[11], zone4_pos, Quaternion.identity);
        }

        // Zone 5's spawning types and locations 


        if (validDrop5_Location == "DraggableUrban")
        {
            Instantiate(Areas[14], zone5_pos, Quaternion.identity);
        }

        else if (validDrop5_Location == "DraggableRural")
        {
            Instantiate(Areas[12], zone5_pos, Quaternion.identity);
        }

        else if (validDrop5_Location == "DraggableSuburban")
        {
            Instantiate(Areas[13], zone5_pos, Quaternion.identity);
        }

        // Zone 6's spawning types and locations 

        if (validDrop6_Location == "DraggableUrban")
        {
            Instantiate(Areas[16], zone6_pos, Quaternion.identity);
        }

        else if (validDrop6_Location == "DraggableRural")
        {
            Instantiate(Areas[17], zone6_pos, Quaternion.identity);
        }

        else if (validDrop6_Location == "DraggableSuburban")
        {
            Instantiate(Areas[15], zone6_pos, Quaternion.identity);
        }


    }


    public void PrepareBuild()
    {
        /*
        * Simply just loads the next scene, which is the result of Selection 
        * Screen's choices then another script runs the generate enviroment function 
        */
        SceneManager.LoadScene("Persona Prototype");
    }



}
