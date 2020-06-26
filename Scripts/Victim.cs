using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victim : MonoBehaviour
{
    public Transform GameObjectChild;
    public GameObject bloodFX;
    public bool detached = false;
    public int death_duration = 2;
    public GameManager gm;
    public VictimDaddy vd;
    public float Delay;

    public bool stopAddingScore = false;


    AudioManager am;
    bool playedBloodThisRound = false;
    bool playedScreamThisRound = false;
    private void Start()
    {
        am = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        vd = GameObject.FindGameObjectWithTag("Victim").GetComponent<VictimDaddy>();
        Delay = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().Delay_Between_Spawns;
    }
    private void Update()
    {
        if(this.gameObject.GetComponent<Mover>().Alive == false)
        {
            //detach the object and tell the mover script to stop moving
            detached = true;
            GameObjectChild.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            //Spawn blood effects
            //GameObject fx = Instantiate(bloodFX, GameObjectChild.transform.position, Quaternion.identity);
            //Destroy(fx, 2f);

            GameObjectChild.parent = null;
            if (detached)
            {
                Destroy(this.gameObject, death_duration);
            }
            if(this.gameObject == GameObject.Find("Head") || this.gameObject == GameObject.Find("Torso"))
            {
                Destroy(GameObjectChild.parent, death_duration);
            }

            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Detach Object From parent and stop body part");
        }
        vd = GameObject.FindGameObjectWithTag("Victim").GetComponent<VictimDaddy>();
        print(vd);
    }

    // Detect collisions between the GameObjects with Coliders Attached
    [System.Obsolete]
    void OnTriggerEnter(Collider Zone)
    {
        //Debug.Log("GOAL      ZONE     HIT");
        switch (Zone.tag)
        {
            case "Goal":
                //Add Points to the Score
                // if (this.gameObject.name != "LeftShin1")  //Points Glicth found from debug caused by LeftShin??? 
                //{                             
                print("AddedScore");
                //gm.UpdateScore += gm.RoundScore;

                if (!stopAddingScore)
                {
                    //gm.UpdateScore += GameObject.Find("BetterCubor").transform.GetChildCount() * 1;
                    gm.UpdateScore += 100;
                    stopAddingScore = true;
                }

                if (!gm.stopAddingScore)
                {
                    //gm.UpdateScore += GameObject.Find("BetterCubor").transform.GetChildCount() * 1;
                    print("AddScorePlease");
                    vd.AddScore();
                    gm.stopAddingScore = true;
                }
                //gm.UpdateScore += this.transform.GetChildCount() * 10;

                //Debug.Log(gm.UpdateScore);
                //}
                this.gameObject.GetComponent<Mover>().Goal_Zone = true;

                //this.gameObject.GetComponent<Mover>().Speed_x = 3f;
                //Set the Goal Zone Flag to true in order for the mover script to send wall and victim away
                break;
        }


   

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Wall")
        {
            

            //Play blood sfx
            Debug.Log(am.bloodAudio.isPlaying);
            if(!playedBloodThisRound) am.PlayBlood();
            playedBloodThisRound = true;

            //Play scream sfx
            if (!playedScreamThisRound) am.PlayScream();
            playedScreamThisRound = true;

            //Take Away points for losing body parts
            //GameObject.Find("Game Manager").GetComponent<GameManager>().RoundScore -= 30;

            //detach the object and tell the mover script to stop moving
            detached = true;
            this.gameObject.GetComponent<Mover>().Alive = false;
            GameObjectChild.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            //Spawn blood effects
            float bloodChance = Random.value;
            //Debug.Log(bloodChance);
            if (bloodChance > .7)
            {
                //VictimDaddy.SpawnBlood();
                GameObject fx = Instantiate(bloodFX, this.GetComponentInParent<Transform>().position, Quaternion.identity);
                Destroy(fx, 2f);
            }

            GameObjectChild.parent = null;
            if(detached)
            {
                Destroy(this.gameObject, death_duration);
            }

            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Detach Object From parent");

        }


    }

}
