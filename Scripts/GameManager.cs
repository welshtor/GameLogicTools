using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    //public bool victimCollidedThisRound = false;

    // Audio
    AudioManager am;
    public VictimDaddy vd;

    public static GameManager Instance
    {
        get
        {
            // Create logic to create the instance 

            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    public float Speed_victim = 0f;
    public int RoundScore = 0;
    internal int UpdateScore;
    public int Rounds;
    public TextMesh ScoreText;
    public float Time_Per_Round;
    public GameObject Wall_Prefab;
    public Transform Wall_Spawn;
    public GameObject[] Victims;
    public Transform Victim_Spawn;
    public float Delay_Between_Spawns = 4f;
    public float Wall_Slide_Speed = -10f;
    public GameObject Goal_Line;
    public float Delay_for_GoalLine = 7f;
    GameObject BC;
    int startingBlocks;

    GameObject[] wallPieces;

    public bool stopAddingScore = false;

    private GameObject[] bodyPartArray;

    void Awake()
    {
        _instance = this;
        am = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
        vd = GameObject.FindGameObjectWithTag("Victim").GetComponent<VictimDaddy>();
        BC = GameObject.Find("BetterCubor");
    }

    void Start()
    {
       
        Speed_victim = GameObject.FindGameObjectWithTag("Victim").GetComponent<Mover>().Speed_z;
        Speed_victim = GameObject.FindGameObjectWithTag("BodyParts").GetComponent<Mover>().Speed_z;


    }
    private void Update()
    {
        ScoreText.text = UpdateScore.ToString();

        bodyPartArray = GameObject.FindGameObjectsWithTag("BodyParts");
        if ((bodyPartArray.Length == 0) && Goal_Line.activeSelf)
        {
            
            Goal_Line.SetActive(false);
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        Invoke("Spawner", Delay_Between_Spawns);

        Invoke("ActivateGoalLine", Delay_for_GoalLine);
    }

    public void Spawner()
    {
        //Spawn Both the Wall and the Victim to their respective Positions
        Destroy(GameObject.Find("BetterCubor"));
        Destroy(GameObject.Find("BetterCubor(Clone)"));

        wallPieces = GameObject.FindGameObjectsWithTag("Wall");
        for (var i = 0; i < wallPieces.Length; i++)
        {
            Destroy(wallPieces[i]);
        }

        if (GameObject.Find("Head") && GameObject.Find("Torso"))
        {
            am.PlayCheer();
        }
        else
        {
            am.PlayBoo();
        }
        Destroy(GameObject.FindGameObjectWithTag("Victim"));
        Destroy(GameObject.FindGameObjectWithTag("BodyParts"));
        stopAddingScore = false;
        Instantiate(Wall_Prefab/*, Wall_Spawn.position, Wall_Spawn.rotation*/);

        Instantiate(Victims[Random.Range(0,Victims.Length)]/*, Victim_Spawn.position, Victim_Spawn.rotation*/);
    }

    public void ActivateGoalLine()
    {
        Goal_Line.SetActive(true);
    }

}

