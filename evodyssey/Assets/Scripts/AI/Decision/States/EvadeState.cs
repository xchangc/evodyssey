using UnityEngine;
using System.Collections;

public class EvadeState : State
{


    public override void Enter(LivingEnemy entity)
    {

        Debug.Log("Entered evadeState");

        LivingEntity tempEnt = GetClosestEnemy(entity);

        entity.SetFocusedEntity(tempEnt);

        entity.SetTarget(tempEnt.GetLocalTransform());

        ChangeBehaviorsToEvade(entity);
    }

    public override void UpdateState(LivingEnemy entity)
    {
        if (entity.GetLocalEnemies().Count == 0)
        {
            //no enemies around
            entity.GetStateMachine().ChangeState((int)LittleFish.LittleFishStates.Wander);
        }
        else
        {
            entity.SetTarget(GetClosestEnemy(entity).transform);
        }



    }

    public override void Exit(LivingEnemy entity)
    {
        
    }

    public LivingEntity GetClosestEnemy(LivingEnemy entity)
    {
        bool set = false;

        LivingEntity closest = null;

        float currentDistance = 0;

        foreach (LivingEntity ent in entity.GetLocalEnemies())
        {


            if (!set)
            {
                closest = ent;
                currentDistance = Vector3.Distance(entity.transform.position, ent.transform.position);
                set = true;
            }
            else
            {

                if (Vector3.Distance(entity.transform.position, ent.transform.position) < currentDistance)
                {

                    closest = ent;
                    currentDistance = Vector3.Distance(entity.transform.position, ent.transform.position);
                }

            }


        }

        if (closest == null)
        {
            Debug.Log("Returning null enemy");

        }

        Debug.Log("Closest: " + closest);

        return closest;


    }


    void ChangeBehaviorsToEvade(LivingEnemy entity)
    {
        entity.GetSteeringModule().GetBehavior("Seek").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Persuit").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Flee").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Evade").SetActive(true);

        entity.GetSteeringModule().GetBehavior("Avoid").SetActive(true);

        entity.GetSteeringModule().GetBehavior("Wander").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Allign").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Cohesion").SetActive(false);
        entity.GetSteeringModule().GetBehavior("Separate").SetActive(false);
    }

}
