using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StateMachine : MonoBehaviour
{

    #region variables

    LivingEnemy mEntity;
    State mCurrentState;
    List<State> mStates;

    #endregion

    #region Functions

    void Start()
    {
        mCurrentState = null;
    }

    void Update()
    {
        if(mCurrentState && mEntity)
        {
            mCurrentState.UpdateState(mEntity);
        }
    }

    public void AddState(State newState)
    {
        if(newState)
        {
            mStates.Add(newState);
        }
    }

    public void ChangeState(int index)
    {
        if(mCurrentState)
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
