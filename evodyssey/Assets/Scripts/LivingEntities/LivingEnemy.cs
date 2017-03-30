using UnityEngine;
using System.Collections;

public class LivingEnemy : LivingEntity
{
    #region Variables


    SteeringModule mSteeringModule;
    StateMachine mStateMachine;

    Vector3 mPositon;
    Vector3 mHeading;


    #endregion

    #region Functions

    #region Getters

    public SteeringModule GetSteeringModule() { return mSteeringModule; }
    public StateMachine GetStateMachine() { return mStateMachine; }
    public Vector3 GetPosition() { return mPositon; }
    public Vector3 GetHeading() { return mHeading; }

    #endregion

    #region Setters

    public void SetPosition(Vector3 pos)
    {
        mPositon = pos;
        transform.position = pos;
    }
    public void SetHeading(Vector3 pos) { mHeading = pos; }

    #endregion

    #region Calculating Functions

    Vector3 Truncate(Vector3 original, float max)
    {
        float length = Mathf.Sqrt((original.x * original.x) + (original.y * original.y) + (original.z * original.z));
        if (length > max && length != 0)
        {
            original.x = original.x / length;
            original.y = original.y / length;
            original.z = original.z / length;

            original *= max;
        }

        return original;
    }

    float GetLength(Vector3 original)
    {
        return Mathf.Sqrt((original.x * original.x) + (original.z * original.z));
    }

    #endregion

    #region Other functions

    void Awake()
    {
        InitEntity();
        mSteeringModule = new SteeringModule();
        mStateMachine = new StateMachine();

        mSteeringModule.SetAgent(this);
        mStateMachine.SetEntity(this);
    }

    public override void Movement()
    {
        Vector3 force = mSteeringModule.Calculate();
        Vector3 vel = GetVelocity();
        vel += force * Time.deltaTime;
        vel = Truncate(vel, GetSpeed());
        //Debug.Log("vel: " + vel.x + "," + vel.y + "," + vel.z);
        SetVelocity(vel);

        //Debug.Log("Speed: " + GetSpeed());

        GetRigidBody().AddForce(new Vector3(vel.x, 0 , vel.z) * Time.deltaTime);//removed vel.x

        //Vector3 pos = GetPosition();
        //pos += vel * Time.deltaTime;
        //SetPosition(pos);

        if(GetLength(vel) > 0.00000001)
        {
            SetHeading(vel.normalized);
        }

        float angle = Mathf.Atan2(GetHeading().z, GetHeading().x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, GetMovementRotation() * Time.deltaTime);

    }

    #endregion

    #endregion

}
