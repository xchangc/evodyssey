using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StateMachine : MonoBehaviour
{

    #region variables

    LivingEnemy mEntity;
    State mCurrentState;
    List<State> mStates = new List<State>();

    #endregion

    #region Functions

    void Start()
    {
        mCurrentState = null;
    }

    public void UpdateMachine()
    {
        if(mCurrentState != null && mEntity != null)
        {
            mCurrentState.UpdateState(mEntity);
        }
    }

    public void AddState(State newState)
    {
        //Debug.Log("added State: " + newState);
        if(newState != null)
        {
            mStates.Add(newState);
        }
    }

    public void ChangeState(int index)
    {
        if(mCurrentState != null)
        {
            mCurrentState.Exit(mEntity);
        }


        mCurrentState = mStates[index];
        mCurrentState.Enter(mEntity);

    }

    public void SetEntity(LivingEnemy entity)
    {
        mEntity = entity;
    }


    #endregion

}
