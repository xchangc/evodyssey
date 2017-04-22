using UnityEngine;
using System.Collections;

public class LivingEnemy : LivingEntity
{
    #region Variables


    SteeringModule mSteeringModule;
    StateMachine mStateMachine;

    Vector3 mPositon;
    Vector3 mHeading;

    float mTimeBetween = 0;
    float mTimeIncrease = 10.0f;

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

        mTimeBetween = Time.deltaTime + mTimeIncrease;
    }

    public override void Movement()
    {
        HungerUpdate();

        if (!IsDead())
        {

            Vector3 force = mSteeringModule.Calculate();
            Vector3 vel = GetVelocity();
            vel += force * Time.deltaTime;
            vel = Truncate(vel, GetSpeed());
            //Debug.Log("vel: " + vel.x + "," + vel.y + "," + vel.z);
            SetVelocity(vel);

            //Debug.Log("Speed: " + GetSpeed());

            GetRigidBody().AddForce(new Vector3(vel.x, 0, vel.z) * Time.deltaTime);//removed vel.x

            //Vector3 pos = GetPosition();
            //pos += vel * Time.deltaTime;
            //SetPosition(pos);

            if (GetLength(vel) > 0.00000001)
            {
                SetHeading(vel.normalized);
            }

            float angle = Mathf.Atan2(GetHeading().z, GetHeading().x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, GetMovementRotation() * Time.deltaTime);
        }

        if (IsDead())
        {
            DropFish();
        }

    }

    void DropFish()
    {
        float mDropSpeed = 3.0f;
        GetRigidBody().constraints = RigidbodyConstraints.None;
        GetRigidBody().AddForce(new Vector3(0, -mDropSpeed, 0));
    }

    IEnumerator RemoveAfterTime()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

    void HungerUpdate()
    {
        //Debug.Log("Got here, Time: " + mTimeBetween + "/" + Time.time);

        if (Time.time >= mTimeBetween)
        {
            mTimeBetween = Time.time + mTimeIncrease;

            mHunger += mHungerIncreaseRate;
            if (mHunger >= GetMaxHunger())
            {
                mHunger = GetMaxHunger();
                mHealth -= mHealthDecreaseRate;

                if (mHealth <= 0)
                {
                    mHealth = 0;
                    SetDead(true);
                }
            }

            //Debug.Log("Hunger: " + mHunger + ", Health: " + mHealth);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Entity")
        {
            LivingEntity temp = col.GetComponent<LivingEntity>();
            if (temp.GetFishName() == GetFishName())
            {
                AddLocalKind(temp);
            }
            foreach (string item in GetPredators())
            {
                if (item == temp.GetFishName())
                {
                    AddLocalEnemy(temp);
                }
            }

        }
        else if (col.tag == "Player")
        {
            LivingEntity temp = col.GetComponent<LivingEntity>();
            if (temp.GetFishName() == GetFishName())
            {
                AddLocalKind(temp);
            }
            foreach (string item in GetPredators())
            {
                if (item == temp.GetFishName())
                {
                    AddLocalEnemy(temp);
                }
            }

        }
        else
        {
            EnvFood temp = col.GetComponent<EnvFood>();
            if (temp != null)
            {

                foreach (string item in GetDesiredFood())
                {
                    if (item == temp.FoodName)
                    {
                        SetFocusedFood(temp);
                    }
                }
            }

        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Entity")
        {
            LivingEntity temp = col.GetComponent<LivingEntity>();
            if (GetLocalKind().Contains(temp))
            {
                RemoveLocalKind(temp);
            }
            if (GetLocalEnemies().Contains(temp))
            {
                RemoveLocalEnemy(temp);
            }
        }
        else if (col.tag == "Player")
        {
            LivingEntity temp = col.GetComponent<LivingEntity>();
            if (GetLocalKind().Contains(temp))
            {
                RemoveLocalKind(temp);
            }
            if (GetLocalEnemies().Contains(temp))
            {
                RemoveLocalEnemy(temp);
            }
        }
        else
        {
            //EnvFood temp = col.GetComponent<EnvFood>();
            //if (temp != null)
            //{
            //    if (GetFocusedFood() == temp)
            //    {
            //        SetFocusedFood(null);
            //    }
            //}

        }

    }

    #endregion

    #endregion

}
