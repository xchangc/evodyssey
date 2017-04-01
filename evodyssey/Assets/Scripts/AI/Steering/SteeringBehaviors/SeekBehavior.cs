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
        Vector3 target = entity.GetTarget().position;

        Vector3 DesiredVelocity = Vector3.Normalize(target - entity.transform.position) * entity.GetSpeed();

        return ((DesiredVelocity - entity.GetVelocity()) * 2);

    }

    #endregion
}
