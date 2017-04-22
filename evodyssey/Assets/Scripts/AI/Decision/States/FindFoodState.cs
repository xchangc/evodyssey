using UnityEngine;
using System.Collections;

public class FindFoodState : State
{

    public float mEatDistance = 10.0f;

    public float mTime;

    public override void Enter(LivingEnemy entity)
    {

        entity.SetTarget(entity.GetFocusedFood().transform);
        entity.SetFocusedEntity(null);
        ChangeBehaviorsToSeek(entity);
        mTime = Time.time + 5;
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
        if (entity.GetFocusedFood() != null)
        {

            if (Vector3.Distance(entity.transform.position, entity.GetFocusedFood().transform.position) <= mEatDistance)
            {
                if (Time.time >= mTime)
                {
                    mTime = Time.time + 5;
                    entity.GetFocusedFood().mFoodHealth -= 1;
                    entity.AddHunger(entity.GetFocusedFood().mHungerIncrease);
                    entity.AddHealth(entity.GetFocusedFood().mHealthIncrease);
                }
            }

        }
    }


    public override void Exit(LivingEnemy entity)
    {
        entity.SetFocusedFood(null);
    }


    void ChangeBehaviorsToSeek(LivingEnemy entity)
    {
        entity.GetSteeringModule().GetBehavior("Seek").SetActive(true);
        entity.GetSteeringModule().GetBehavior("Persuit").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Flee").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Evade").SetActive(false);

        entity.GetSteeringModule().GetBehavior("Avoid").SetActive(true);

        entity.GetSteeringModule().GetBehavior("Wander").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Allign").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Cohesion").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Separate").SetActive(false);
    }
}
