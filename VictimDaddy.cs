using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimDaddy : MonoBehaviour
{
    AudioManager am;
    GameManager gm;
    GameObject BC;
    GameObject BCC;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        am = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
        BC = GameObject.Find("BetterCubor");
        BCC = GameObject.Find("BetterCubor(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        BCC = GameObject.Find("BetterCubor(Clone)");
    }
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Wall")
        {
            am.PlayBoo();
        }

    }
  

    [System.Obsolete]
    public void AddScore()
    {
        //print("where");
        //this.gameObject.GetComponent<Mover>().Speed_z = 0f;
        //this.gameObject.GetComponent<Mover>().Speed_x = 0f;
        //GameObject.FindGameObjectWithTag("Wall").GetComponent<Mover>().Speed_x = GameObject.Find("Game Manager").GetComponent<GameManager>().Wall_Slide_Speed;
        Debug.Log("Daddy");
        if (BC)
        {
            gm.UpdateScore += BC.transform.GetChildCount() * 1;
        }
        if (BCC != null)
        {
            print("BCC");
            gm.UpdateScore += BCC.transform.GetChildCount() * 1;
        }
        //print(this.transform.GetChildCount());
        //gm.UpdateScore += this.transform.GetChildCount() * 100;
        Debug.Log(gm.UpdateScore);
        //am.PlayCheer();
        //gm.ResetLevel();
    }
}
