using UnityEngine;
using System.Collections;

public class FindFoodState : State
{



    public override void Enter(LivingEnemy entity)
    {

        Debug.Log("Entered foodState");
        entity.SetTarget(entity.GetFocusedFood().transform);
        ChangeBehaviorsToPersuit(entity);
    }

    public override void UpdateState(LivingEnemy entity)
    {

        if (entity.GetLocalEnemies().Count > 0)
        {
            //Enemy found
            entity.GetStateMachine().ChangeState((int)LittleFish.LittleFishStates.Flee);
        }

        if (entity.GetFocusedFood() == null 
            || !entity.IsHungry())
        {
            //no food, or not hungry
            entity.GetStateMachine().ChangeState((int)LittleFish.LittleFishStates.Wander);
        }

    }

    public override void Exit(LivingEnemy entity)
    {

    }


    void ChangeBehaviorsToPersuit(LivingEnemy entity)
    {
        entity.GetSteeringModule().GetBehavior("Seek").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Persuit").SetActive(true);
        entity.GetSteeringModule().GetBehavior("Flee").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Evade").SetActive(false);

        entity.GetSteeringModule().GetBehavior("Avoid").SetActive(true);

        entity.GetSteeringModule().GetBehavior("Wander").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Allign").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Cohesion").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Separate").SetActive(false);
    }
}
