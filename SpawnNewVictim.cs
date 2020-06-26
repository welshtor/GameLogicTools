using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewVictim : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BodyParts")
        {
            if (gm.Goal_Line.activeSelf)
            {
                gm.Goal_Line.SetActive(false);
                gm.ResetLevel();
            }
        }
    }
}
