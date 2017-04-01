using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeparationBehavior : SteeringBehavior
{

    #region Variables



    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Separate");
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {
        List<LivingEntity> localType = entity.GetLocalKind();

        int numAgents = 0;

        Vector3 finalVector = new Vector3(0, 0, 0);

        foreach (LivingEntity LocalEntity in localType)
        {
            finalVector.x += LocalEntity.transform.position.x - entity.transform.position.x;
            finalVector.z += LocalEntity.transform.position.z - entity.transform.position.z;
            numAgents++;
        }

        if (numAgents == 0)
        {
            return (new Vector3(0, 0, 0));
        }

        finalVector.x /= numAgents;
        finalVector.z /= numAgents;

        finalVector = Vector3.Normalize(finalVector);
        finalVector = finalVector * (entity.GetSpeed() * 0.1f);

        return finalVector;

    }

    #endregion

}
