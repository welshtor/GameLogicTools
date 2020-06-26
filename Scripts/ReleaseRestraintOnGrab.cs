using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{

    public class ReleaseRestraintOnGrab : MonoBehaviour

    {
        public Rigidbody GetRigid;
        public GameObject Hate;
        public Hand Grab;
        public bool reset = true;
        AudioManager am;

        void Start()
        {
            //Find rigidbody on awake
            GetRigid = gameObject.GetComponent<Rigidbody>();
            Hate = gameObject;
            am = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
        }

        void Update()
        {
            Grab = Hate.GetComponent<Interactable>().attachedToHand;
            //When grabbed, become un-rigid
            if (Grab == true && reset == true)
            {
                GetRigid.constraints = RigidbodyConstraints.None;
                am.PlayBlock();
                reset = false;
            }
            if (Grab == false && reset == false) {
                reset = true;
            }
        }
    }
}