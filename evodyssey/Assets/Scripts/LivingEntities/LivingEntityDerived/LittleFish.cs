using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LittleFish : LivingEnemy
{
    public enum LittleFishStates
    {
        Wander,
        Flee,
        SeekFood
    }


    #region Variables

    WanderBehavior mWander;
    SeekBehavior mSeek;
    PersuitBehavior mPersuit;
    FleeBehavior mFlee;
    EvadeBehavior mEvade;
    ObstacleAvoidBehavior mAvoid;
    AllignmentBehavior mAllign;
    CohesionBehavior mCohesion;
    SeparationBehavior mSeparate;

    #endregion

    #region Functions

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        SetPosition(transform.position);

        SetTarget(player.transform);

        SetFocusedEntity(player.GetComponent<LivingEntity>());

        mWander = new WanderBehavior();
        mSeek = new SeekBehavior();
        mPersuit = new PersuitBehavior();
        mFlee = new FleeBehavior();
        mEvade = new EvadeBehavior();
        mAvoid = new ObstacleAvoidBehavior();
        mAllign = new AllignmentBehavior();
        mCohesion = new CohesionBehavior();
        mSeparate = new SeparationBehavior();


        GetSteeringModule().AddBehavior(mWander);
        GetSteeringModule().AddBehavior(mSeek);
        GetSteeringModule().AddBehavior(mPersuit);
        GetSteeringModule().AddBehavior(mFlee);
        GetSteeringModule().AddBehavior(mEvade);
        GetSteeringModule().AddBehavior(mAvoid);
        GetSteeringModule().AddBehavior(mAllign);
        GetSteeringModule().AddBehavior(mCohesion);
        GetSteeringModule().AddBehavior(mSeparate);


        GetSteeringModule().GetBehavior("Seek").SetActive(false);
        GetSteeringModule().GetBehavior("Persuit").SetActive(false);
        GetSteeringModule().GetBehavior("Flee").SetActive(false);
        GetSteeringModule().GetBehavior("Evade").SetActive(false);
        GetSteeringModule().GetBehavior("Wander").SetActive(true);
        GetSteeringModule().GetBehavior("Avoid").SetActive(true);
        GetSteeringModule().GetBehavior("Allign").SetActive(true);
        GetSteeringModule().GetBehavior("Cohesion").SetActive(true);
        GetSteeringModule().GetBehavior("Separate").SetActive(true);



        //add states here
        //GetStateMachine().ChangeState((int)LittleFishStates.Wander);
    }

    void Update()
    {
        Movement();
    }

    #endregion

}
