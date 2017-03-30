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

    List<LivingEntity> mLocalEnemies;
    List<LittleFish> mLocalKind;

    WanderBehavior mWander;
    SeekBehavior mSeek;
    PersuitBehavior mPersuit;

    #endregion

    #region Functions

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        SetPosition(transform.position);

        mWander = new WanderBehavior();
        mWander.Init(this);

        mSeek = new SeekBehavior();
        mSeek.Init(this);

        mPersuit = new PersuitBehavior();
        mPersuit.Init(this);



        SetDestination(player.transform);
        SetFocusedEntity(player.GetComponent<LivingEntity>());
        
        GetSteeringModule().AddBehavior(mWander);
        GetSteeringModule().AddBehavior(mSeek);
        GetSteeringModule().AddBehavior(mPersuit);

        GetSteeringModule().GetBehavior("Wander").SetActive(false);
        GetSteeringModule().GetBehavior("Seek").SetActive(false);
        GetSteeringModule().GetBehavior("Persuit").SetActive(true);

        //add states here
        //GetStateMachine().ChangeState((int)LittleFishStates.Wander);
    }

    void Update()
    {
        Movement();



    }

    void CalculateFish()
    {

    }



    #endregion

}
