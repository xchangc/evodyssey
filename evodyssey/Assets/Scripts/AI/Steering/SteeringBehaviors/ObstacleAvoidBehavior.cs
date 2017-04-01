using UnityEngine;
using System.Collections;

public class ObstacleAvoidBehavior : SteeringBehavior
{
    #region Variables

    float sightDistance = 6;
    float angleFromCenter = 40;
    float ForceTweak = 8;
    float TurnQuickForce = 20;

    #endregion

    #region Functions

    public override void Init(LivingEntity entity)
    {
        SetName("Avoid");
    }

    public override Vector3 Calculate(LivingEntity entity, LivingEntity extra)
    {

        RaycastHit RightHit;
        RaycastHit LeftHit;
        RaycastHit MiddleHit;

        bool hitLeftLine = false;
        bool hitRightLine = false;
        bool hitMiddleLine = false;

        float angle = angleFromCenter * Mathf.Deg2Rad;

        Vector3 fwd = entity.GetVelocity().normalized;

        Vector3 right = fwd * Mathf.Cos(angle) + entity.transform.right * Mathf.Sin(angle);

        Vector3 left = fwd * Mathf.Cos(angle) + -entity.transform.right * Mathf.Sin(angle);



        right.Normalize();
        left.Normalize();

        //Vector3 right = fwd + new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * 45.0f), 0);


        if (Physics.Raycast(entity.transform.position, fwd, out MiddleHit, sightDistance))
        {
            //forward

            if (MiddleHit.collider.tag == "Wall")
            {
                Debug.DrawLine(entity.transform.position, MiddleHit.point);
                hitMiddleLine = true;
            }
        }

        if (Physics.Raycast(entity.transform.position, right, out RightHit, sightDistance))
        {
            //right

            if (RightHit.collider.tag == "Wall")
            {
                Debug.DrawLine(entity.transform.position, RightHit.point, Color.blue);
                hitRightLine = true;
                //Debug.Log("Found a wall on right");
            }
        }

        if (Physics.Raycast(entity.transform.position, left, out LeftHit, sightDistance))
        {
            //left

            if (LeftHit.collider.tag == "Wall")
            {
                Debug.DrawLine(entity.transform.position, LeftHit.point, Color.blue);
                hitLeftLine = true;
                //Debug.Log("Found a wall on left");
            }
        }

        Vector3 avoidance = new Vector3(0,0,0);
        float pointDist = 0.0f;
        float currentForce = 0.0f;

        //if(hitMiddleLine)
        //{
        //    float leftDistance = (Vector3.Distance(entity.transform.position, LeftHit.point));
        //    float rightDistance = (Vector3.Distance(entity.transform.position, LeftHit.point));

        //    if (leftDistance < rightDistance)
        //    {
        //        pointDist = leftDistance;
        //    }
        //    else
        //    {
        //        pointDist = rightDistance;
        //    }

        //    if (pointDist != 0)
        //    {
        //        currentForce = pointDist / sightDistance;
        //        currentForce *= maxAvoidForce;
        //    }
        //    else
        //    {
        //        currentForce = maxAvoidForce;
        //    }

        //    avoidance = new Vector3(currentForce, 0, -currentForce);
        //}

        //if(hitMiddleLine)
        //{
        //    pointDist = (Vector3.Distance(entity.transform.position, MiddleHit.point));

        //    if (pointDist != 0)
        //    {
        //        currentForce = pointDist / sightDistance;
        //        currentForce *= entity.GetSpeed();
        //    }
        //    else
        //    {
        //        currentForce = entity.GetSpeed();
        //    }
        //    //if (hitMiddleLine) { currentForce *= 5; }

        //    //avoidance = new Vector3(-entity.GetSpeed() * ForceChange, 0, 0);
        //    avoidance = left * TurnQuickForce * ForceTweak;
        //}
        //else 
        if (hitRightLine)
        {
            pointDist = (Vector3.Distance(entity.transform.position, RightHit.point));

            if (pointDist != 0)
            {
                currentForce = pointDist / sightDistance;
                currentForce *= entity.GetSpeed();
            }
            else
            {
                currentForce = entity.GetSpeed();
            }
            //if (hitMiddleLine) { currentForce *= 5; }

            //avoidance = new Vector3(-entity.GetSpeed() * ForceChange, 0, 0);
            avoidance = left * entity.GetSpeed() * ForceTweak;
                
        }
        else if(hitLeftLine)
        {
            //move right
            pointDist = (Vector3.Distance(entity.transform.position, LeftHit.point));

            if (pointDist != 0)
            {
                currentForce = pointDist / sightDistance;
                currentForce *= entity.GetSpeed();
            }
            else
            {
                currentForce = entity.GetSpeed();
            }
            //if (hitMiddleLine) { currentForce *= 5; }

            avoidance = right * entity.GetSpeed() * ForceTweak;
        }



        //Debug.Log("Force: " + avoidance.x + "," + avoidance.y + "," + avoidance.z);
        return avoidance;
    }

    #endregion
}
