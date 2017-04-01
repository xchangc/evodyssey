using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllignmentBehavior : SteeringBehavior
{

    #region Variables



    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Allign");
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {
        List<LivingEntity> localType = entity.GetLocalKind();

        int numAgents = 0;

        Vector3 finalVector = new Vector3(0,0,0);

        foreach (LivingEntity LocalEntity in localType)
        {
            finalVector.x += LocalEntity.GetVelocity().x;
            finalVector.z += LocalEntity.GetVelocity().z;
            numAgents++;
        }

        if(numAgents == 0)
        {
            return (new Vector3(0, 0, 0));
        }

        finalVector.x /= numAgents;
        finalVector.z /= numAgents;

        finalVector = Vector3.Normalize(finalVector);
        finalVector = finalVector * (entity.GetSpeed() * 0.5f);

        return finalVector;

    }

    #endregion
}
