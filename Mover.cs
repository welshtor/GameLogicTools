using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed_x = 0f;
    public float Speed_y = 0f;
    public float Speed_z = 0f;
    public bool Alive = true;
    public bool Goal_Zone = false;

    // Audio
    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            transform.Translate(Speed_x * Time.deltaTime, Speed_y * Time.deltaTime, Speed_z * Time.deltaTime);
        }
        else if (Goal_Zone)
        {
            transform.Translate(Speed_x * Time.deltaTime, Speed_y * Time.deltaTime, Speed_z * Time.deltaTime);
        }
    }
}
