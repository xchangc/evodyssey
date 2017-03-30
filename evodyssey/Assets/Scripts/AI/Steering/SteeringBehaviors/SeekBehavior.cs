using UnityEngine;
using System.Collections;

public class SeekBehavior : SteeringBehavior
{

    #region Variables



    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Seek");
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {
        Vector3 destination = entity.GetDestination().position;

        Vector3 DesiredVelocity = Vector3.Normalize(destination - entity.transform.position) * entity.GetSpeed();

        return ((DesiredVelocity - entity.GetVelocity()) * 2);

    }

    #endregion
}
