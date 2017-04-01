using UnityEngine;
using System.Collections;

public class PersuitBehavior : SteeringBehavior
{
    #region Variables


    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Persuit");
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {

        Vector3 distance = extra.transform.position - entity.transform.position;

        float updatesAhead = distance.sqrMagnitude / entity.GetSpeed();

        Vector3 futurePosition = extra.transform.position + extra.GetVelocity() * updatesAhead;

        Vector3 DesiredVelocity = Vector3.Normalize(futurePosition - entity.transform.position) * entity.GetSpeed();

        return ((DesiredVelocity - entity.GetVelocity()) * 2);

    }

    #endregion
}
