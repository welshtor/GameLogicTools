using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // For Look at Method
    public float Speed_x = 3f;
    public float Speed_y = 0f;
    public float Speed_z = 3f;

    // For Vector Method
    public float Speed = 3.0f;

    public Transform Work;
    public Transform Home;
    public Transform Hospital;
    public Transform Pharmarcy;
    public Transform InsuranceOffice;

    private Transform mTarget;
    private Vector3 mLookDirection; 

    const float StopDistance = 0.1f;

    public double WorkStart = 0;
    public double WorkEnd = 8;
    public double HospitalStart = 15;
    public double HospitalEnd = 17;
    public double PharmacyStart = 8;
    public double PharmacyEnd = 9;
    public double PayerStart = 14;
    public double PayerEnd = 15; 

    private int Hour;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        /*
         * Travel AI Section 
         * moves the persona to different locations set by the mTarget
         */
         Hour = GameObject.Find("Time Simulator").GetComponent<GameManager>().hour ;

        // Simulation Speed Scalar
        int Speed_Scale = GameObject.Find("Time Simulator").GetComponent<GameManager>().TimeMultiplier;


        // WorkStart and WorkEnd Must be 0 - 24 
        if ((WorkStart <= Hour) &&( Hour <= WorkEnd))
        {
            if (mTarget != Work)
                this.mTargetUpdater(Work);


            //transform.LookAt(Work.position);
            //if((transform.position - Work.position).magnitude > StopDistance)
            //    // Using Look Method 
            //    transform.Translate(Speed_x* Time.deltaTime, Speed_y* Time.deltaTime, Speed_z* Time.deltaTime);


            mLookDirection = (mTarget.position - transform.position).normalized;
            if ((transform.position - mTarget.position).magnitude > StopDistance)
                // Using Vector Method - Avoids Making this object rotate
                transform.Translate(Speed * Speed_Scale * Time.deltaTime * mLookDirection);


        }

        else if ((PharmacyStart <= Hour) && (Hour <= PharmacyEnd))
        {

            if (mTarget != Pharmarcy)
                this.mTargetUpdater(Pharmarcy);


            mLookDirection = (mTarget.position - transform.position).normalized;
            if ((transform.position - mTarget.position).magnitude > StopDistance)
                transform.Translate(Speed * Speed_Scale * Time.deltaTime * mLookDirection);
        }

        else if ((PayerStart <= Hour) && (Hour <= PayerEnd))
        {

            if (mTarget != InsuranceOffice)
                this.mTargetUpdater(InsuranceOffice);


            mLookDirection = (mTarget.position - transform.position).normalized;
            if ((transform.position - mTarget.position).magnitude > StopDistance)
                transform.Translate(Speed * Speed_Scale * Time.deltaTime * mLookDirection);
        }


        else if ((HospitalStart <= Hour) && (Hour <= HospitalEnd))
        {

            if (mTarget != Hospital)
                this.mTargetUpdater(Hospital);


            mLookDirection = (mTarget.position - transform.position).normalized;
            if ((transform.position - mTarget.position).magnitude > StopDistance)
                transform.Translate(Speed * Speed_Scale * Time.deltaTime * mLookDirection);
        }


        // WorkStart and WorkEnd Must be 0 - 24 
        else
        {
            if (mTarget != Home)
                this.mTargetUpdater(Home);


            //transform.LookAt(Home.position);
            mLookDirection = (mTarget.position - transform.position).normalized;
            if ((transform.position - mTarget.position).magnitude > StopDistance)
                transform.Translate(Speed * Speed_Scale * Time.deltaTime*mLookDirection);

        }

    }

    void mTargetUpdater(Transform newTarget)
    {
        mTarget = newTarget;
    }



}
