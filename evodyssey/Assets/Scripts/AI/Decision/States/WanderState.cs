using UnityEngine;
using System.Collections;

public class WanderState : State
{
    public override void Enter(LivingEnemy entity)
    {
        ChangeBehaviorsToWander(entity);

    }

    public override void UpdateState(LivingEnemy entity)
    {


        if (entity.GetLocalEnemies().Count > 0)
        {
            //Enemy found
            entity.GetStateMachine().ChangeState((int)LittleFish.LittleFishStates.Flee);
        }

        if (entity.IsHungry())
        {
            //look for food
            //if food found, run to food
            if (entity.GetFocusedFood() != null)
            {
                entity.GetStateMachine().ChangeState((int)LittleFish.LittleFishStates.SeekFood);
            }

        }

        
    }

    public override void Exit(LivingEnemy entity)
    {
        
    }

    void ChangeBehaviorsToWander(LivingEnemy entity)
    {
        entity.GetSteeringModule().GetBehavior("Seek").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Persuit").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Flee").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Evade").SetActive(false);

        entity.GetSteeringModule().GetBehavior("Avoid").SetActive(true);

        entity.GetSteeringModule().GetBehavior("Wander").SetActive(true);
        entity.GetSteeringModule().GetBehavior("Allign").SetActive(true);
        entity.GetSteeringModule().GetBehavior("Cohesion").SetActive(true);
        entity.GetSteeringModule().GetBehavior("Separate").SetActive(true);
    }

    

}
