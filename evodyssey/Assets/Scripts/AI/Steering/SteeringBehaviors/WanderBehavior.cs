using UnityEngine;
using System.Collections;



public class WanderBehavior : SteeringBehavior
{

    #region Variables

    float mWanderRadius = 4.0f;
    float mWanderDistance = 5.0f;


    Transform mWanderTarget;


    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Wander");
        mWanderTarget = entity.GetLocalTransform();
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {



        float newX = Random.Range(-10.0f, 10.0f);
        float newZ = Random.Range(-10.0f, 10.0f);



        mWanderTarget.localPosition += new Vector3(newX, 0, newZ);
        mWanderTarget.localPosition = Vector3.Normalize(mWanderTarget.localPosition);
        mWanderTarget.localPosition *= mWanderRadius;

        Vector3 localTarget = mWanderTarget.localPosition + new Vector3(0, 0, mWanderDistance);
        mWanderTarget.localPosition = localTarget;

        Debug.DrawLine(entity.transform.position, mWanderTarget.transform.position);

        //Debug.Log("wander distance: " + mWanderDistance);

        //Debug.Log("local: " + localTarget.x + "," + localTarget.y + "," + localTarget.z);

        Vector3 worldTarget = mWanderTarget.position;

        //Debug.DrawLine(entity.GetLocalTransform().localPosition, entity.GetLocalTransform().localPosition + new Vector3(0, 0, mWanderDistance));

        Vector3 ToTarget = worldTarget - entity.transform.position;
        ToTarget = Vector3.Normalize(ToTarget);


        ToTarget = ToTarget * entity.GetSpeed();


        ToTarget = ToTarget - entity.GetVelocity();
        ToTarget = new Vector3(ToTarget.x, 1, ToTarget.z);

        return (ToTarget);

    }

    #endregion

}
