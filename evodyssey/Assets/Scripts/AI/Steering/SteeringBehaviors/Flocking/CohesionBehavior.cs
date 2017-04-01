using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CohesionBehavior : SteeringBehavior
{

    #region Variables



    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Cohesion");
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {
        List<LivingEntity> localType = entity.GetLocalKind();

        int numAgents = 0;

        Vector3 finalVector = new Vector3(0, 0, 0);

        foreach (LivingEntity LocalEntity in localType)
        {
            finalVector.x += LocalEntity.transform.position.x;
            finalVector.z += LocalEntity.transform.position.z;
            numAgents++;
        }

        if (numAgents == 0)
        {
            return (new Vector3(0, 0, 0));
        }

        finalVector.x /= numAgents;
        finalVector.z /= numAgents;

        finalVector = new Vector3(finalVector.x - entity.transform.position.x, 0, finalVector.z - entity.transform.position.z);

        finalVector = Vector3.Normalize(finalVector);
        
        return finalVector;

    }

    #endregion
}
