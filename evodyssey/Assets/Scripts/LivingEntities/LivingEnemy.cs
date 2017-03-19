using UnityEngine;
using System.Collections;

public class LivingEnemy : LivingEntity
{
    #region Variables

    SteeringModule mSteeringModule;

    Vector2 mPositon;
    Vector2 mVelocity;
    Vector2 mHeading;
    Vector2 mDestination;

    #endregion

    #region Functions

    #region Getters

    SteeringModule GetSteeringModule() { return mSteeringModule; }
    Vector2 GetPosition() { return mPositon; }
    Vector2 GetVelocity() { return mVelocity; }
    Vector2 GetHeading() { return mHeading; }
    Vector2 GetDestination() { return mDestination; }

    #endregion

    #region Setters

    void SetPosition(Vector2 pos)
    {
        mPositon = pos;
        transform.position = pos;
    }
    void SetVelocity(Vector2 pos) { mVelocity = pos; }
    void SetHeading(Vector2 pos) { mHeading = pos; }
    void SetDestination(Vector2 pos) { mDestination = pos; }

    #endregion

    #region Calculating Functions

    Vector2 Truncate(Vector2 original, float max)
    {
        float length = Mathf.Sqrt((original.x * original.x) + (original.y * original.y));
        if (length > max && length != 0)
        {
            original.x = original.x / length;
            original.y = original.y / length;

            original *= max;
        }

        return original;
    }

    float GetLength(Vector2 original)
    {
        return Mathf.Sqrt((original.x * original.x) + (original.y * original.y));
    }

    #endregion

    #region Other functions

    void Start()
    {
        mSteeringModule.SetAgent(this);
        mPositon = transform.position;
    }

    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        Vector2 force = mSteeringModule.Calculate();
        Vector2 vel = GetVelocity();
        vel += force * Time.deltaTime;
        vel = Truncate(vel, GetSpeed());
        SetVelocity(vel);

        Vector2 pos = GetPosition();
        pos += vel * Time.deltaTime;
        SetPosition(pos);

        if(GetLength(vel) > 0.00000001)
        {
            SetHeading(vel.normalized);
        }

    }

    #endregion

    #endregion

}
