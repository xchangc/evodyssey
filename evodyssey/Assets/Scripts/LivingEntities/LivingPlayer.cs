using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LivingPlayer : LivingEntity
{

    #region Variables

    #region Player Specific

    [Space(20)]
    [Header("Player Specific Variables")]
    [Range(0, 5)]
    public int mAttackLevel;
    [Range(0, 5)]
    public int mDefenseLevel;
    [Range(0, 5)]
    public int mSizeLevel;
    [Range(0, 5)]
    public int mSpeedLevel;

    [Space(20)]
    public float mAttackAttribute;
    public float mDefenseAttribute;
    public float mSizeAttribute;
    public float mSpeedAttribute;

    List<Mutation> mMutations;

    #endregion

    #region movement

    [Header("Movement")]
    [Space(10)]
    public float mMovementDistance;
    public float mMovementDeltaTimeSpeed;
    public float mMovementRotationSpeed;
    [Space(10)]
    public float mMaxStamina;
    public float mMinStamina;
    [Space(10)]
    public Transform mAttackArea;
    [Space(10)]
    public bool mUseInitialCameraDistance = false;

    protected bool mIsDashing;
    protected bool mIsAttacking;

    private float mActualDistance;

    #endregion


    #endregion

    #region Functions

    #region MutationStuff

    public void CheckMutations()
    {
        //do stuff based on mutations
    }
    public bool HasMutation(string name)
    {
        foreach (Mutation mut in mMutations)
        {
            if (mut.GetName() == name)
            {
                return true;
            }
        }
        return false;
    }
    public void AddMutation(Mutation newMutation)
    {
        if (HasMutation(newMutation.GetName()))
        {
            //upgrade?
        }
        else
        {
            mMutations.Add(newMutation);
        }
    }
    public Mutation GetMutation(string name)
    {
        foreach (Mutation mut in mMutations)
        {
            if (mut.GetName() == name)
            {
                return mut;
            }
        }
        return null;
    }

    #endregion

    #region Getters

    public int GetAttackLevel() { return mAttackLevel; }
    public int GetDefenseLevel() { return mDefenseLevel; }
    public int GetSizeLevel() { return mSizeLevel; }
    public int GetSpeedLevel() { return mSpeedLevel; }
    public float GetAttackAttribute() { return mAttackAttribute; }
    public float GetDefenseAttribute() { return mDefenseAttribute; }
    public float GetSizeAttribute() { return mSizeAttribute; }
    public float GetSpeedAttribute() { return mSpeedAttribute; }
    public float GetMovementDistance() { return mMovementDistance; }
    public float GetMovementTimeSpeed() { return mMovementDeltaTimeSpeed; }
    public float GetMovementRotation() { return mMovementRotationSpeed; }
    public float GetMaxStamina() { return mMaxStamina; }
    public float GetMinStamina() { return mMinStamina; }
    public float GetActualDistance() { return mActualDistance; }
    public Transform GetAttackArea() { return mAttackArea; }
    public bool IsUsingInitialCameraDistance() { return mUseInitialCameraDistance; }
    public bool IsAttacking() { return mIsAttacking; }
    public bool IsDashing() { return mIsDashing; }

    #endregion

    #region Setters

    public void SetDefenseLevel(int level) { mDefenseLevel = level; }
    public void SetSizeLevel(int level) { mSizeLevel = level; }
    public void SetSpeedLevel(int level) { mSpeedLevel = level; }
    public void SetAttackLevel(int level) { mAttackLevel = level; }
    public void SetAttackAttribute(float attr) { mAttackAttribute = attr; }
    public void SetDefenseAttribute(float attr) { mDefenseAttribute = attr; }
    public void SetSizeAttribute(float attr) { mSizeAttribute = attr; }
    public void SetSpeedAttribute(float attr) { mSpeedAttribute = attr; }
    public void SetIsAttacking(bool attacking) { mIsAttacking = attacking; }
    public void SetIsDashing(bool dashing) { mIsDashing = dashing; }

    #endregion

    #region Inits

    void Start()
    {
        MovementInit();
        AttributeInit();
    }

    void MovementInit()
    {
        SetStamina(GetMaxStamina());
        mIsDashing = false;
        mIsAttacking = false;

        if (IsUsingInitialCameraDistance())
        {
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
            mActualDistance = linearDistanceVector.magnitude;
        }
        else
        {
            mActualDistance = GetMovementDistance();
        }
    }

    void AttributeInit()
    {
        SetHealth(GetSize());

        SetAttackAttribute(0.0f);
        SetDefenseAttribute(0.0f);
        SetSizeAttribute(0.0f);
        SetSpeedAttribute(0.0f);

        SetAttackLevel(0);
        SetDefenseLevel(0);
        SetSizeLevel(0);
        SetSpeedLevel(0);
    }

    #endregion

    #region ImportantFunctions

    void Update()
    { 
        //checks for input
        InputChecks();

        //movement Function
        Movement();
    }

    void InputChecks()
    {
        //checks for attacking
        if (Input.GetMouseButton(0))
        {
            SetIsAttacking(true);
        }
        else
        {
            SetIsAttacking(false);
        }

        //checks for dashing
        if (Input.GetMouseButton(1))
        {
            if (GetStamina() > GetMinStamina())
            {
                SetStamina(GetStamina() - 1);
                mMovementDeltaTimeSpeed = 3.0f;
            }
            else if (GetStamina() <= GetMinStamina())
            {
                SetStamina(0);
                mMovementDeltaTimeSpeed = 1.0f;
                SetIsDashing(false);
            }
            SetIsDashing(true);
        }
        else
        {
            if (GetStamina() < GetMaxStamina())
            {
                SetStamina(GetStamina() + 1);
            }
            else if (GetStamina() >= GetMaxStamina())
            {
                SetStamina(GetMaxStamina());
            }
            mMovementDeltaTimeSpeed = 1.0f;
            SetIsDashing(false);
        }
    }

    public override void Movement()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = GetActualDistance();

        // Look towards the direction of the Mouse Position
        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, GetMovementRotation() * Time.deltaTime);

        // Look at the mouse position
        //transform.LookAt (Camera.main.ScreenToWorldPoint (mousePosition));

        // Move towards mouse position
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mousePosition), Time.deltaTime * GetMovementTimeSpeed());

        // Dashing
        if (Input.GetMouseButton(1))
        {
            if (GetStamina() > GetMinStamina())
            {
                SetStamina(GetStamina() - 1);
                mMovementDeltaTimeSpeed = 3.0f;
            }
            else if (GetStamina() <= GetMinStamina())
            {
                SetStamina(0);
                mMovementDeltaTimeSpeed = 1.0f;
                SetIsDashing(false);
            }
            SetIsDashing(true);
        }
        else
        {
            if (GetStamina() < GetMaxStamina())
            {
                SetStamina(GetStamina() + 1);
            }
            else if (GetStamina() >= GetMaxStamina())
            {
                SetStamina(GetMaxStamina());
            }
            mMovementDeltaTimeSpeed = 1.0f;
            SetIsDashing(false);
        }
    }

    public override void UseAbility() { }

    #endregion

    #region AttributeStuff

    public void increaseAttackAttribute(float f)
    {
        if (GetAttackLevel() == 0 && GetDefenseLevel() >= 0)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
        }
        else if (GetAttackLevel() == 1 && GetDefenseLevel() < 1)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
        }
        else if (GetAttackLevel() == 1 && GetDefenseLevel() == 1)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
            SetDefenseAttribute(GetDefenseAttribute() - (f / 2.0f));
        }
        else if (GetAttackLevel() == 1 && GetDefenseLevel() > 1)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
        }
        else if (GetAttackLevel() == 2 && GetDefenseLevel() < 2)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
        }
        else if (GetAttackLevel() == 2 && GetDefenseLevel() == 2)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
            SetDefenseAttribute(GetDefenseAttribute() - (f / 2.0f));
        }
        else if (GetAttackLevel() == 2 && GetDefenseLevel() > 2)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
        }
        else if (GetAttackLevel() == 3 && GetDefenseLevel() < 2)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
        }
        else if (GetAttackLevel() == 3 && GetDefenseLevel() >= 2 && GetDefenseLevel() <= 3)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
            SetDefenseAttribute(GetDefenseAttribute() - (f / 2.0f));
        }
        else if (GetAttackLevel() == 3 && GetDefenseLevel() > 3 && GetDefenseLevel() < 5)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
            SetDefenseAttribute(GetDefenseAttribute() - (f / 2.0f));
        }
        else if (GetAttackLevel() == 3 && GetDefenseLevel() >= 5)
        {
            // do nothing
        }
        else if (GetAttackLevel() == 4 && GetDefenseLevel() >= 3 && GetDefenseLevel() <= 4)
        {
            SetAttackAttribute(GetAttackAttribute() + f);
            SetDefenseAttribute(GetDefenseAttribute() - (f / 2.0f));
        }
        else if (GetAttackLevel() == 4 && GetDefenseLevel() >= 4)
        {
            // do nothing
        }
        else if (GetAttackLevel() >= 5)
        {
            // do nothing
        }

        checkAttributes();
    }

    // Increase Defense Attribute
    public void increaseDefenseAttribute(float f)
    {
        if (GetDefenseLevel() == 0 && GetAttackLevel() >= 0)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
        }
        else if (GetDefenseLevel() == 1 && GetAttackLevel() < 1)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
        }
        else if (GetDefenseLevel() == 1 && GetAttackLevel() == 1)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
            SetAttackAttribute(GetAttackAttribute() - (f / 2.0f));
        }
        else if (GetDefenseLevel() == 1 && GetAttackLevel() > 1)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
        }
        else if (GetDefenseLevel() == 2 && GetAttackLevel() < 2)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
        }
        else if (GetDefenseLevel() == 2 && GetAttackLevel() == 2)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
            SetAttackAttribute(GetAttackAttribute() - (f / 2.0f));
        }
        else if (GetDefenseLevel() == 2 && GetAttackLevel() > 2)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
        }
        else if (GetDefenseLevel() == 3 && GetAttackLevel() < 2)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
        }
        else if (GetDefenseLevel() == 3 && GetAttackLevel() >= 2 && GetAttackLevel() <= 3)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
            SetAttackAttribute(GetAttackAttribute() - (f / 2.0f));
        }
        else if (GetDefenseLevel() == 3 && GetAttackLevel() > 3 && GetAttackLevel() < 5)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
            SetAttackAttribute(GetAttackAttribute() - (f / 2.0f));
        }
        else if (GetDefenseLevel() == 3 && GetDefenseLevel() >= 5)
        {
            // do nothing
        }
        else if (GetDefenseLevel() == 4 && GetAttackLevel() >= 3 && GetAttackLevel() <= 4)
        {
            SetDefenseAttribute(GetDefenseAttribute() + f);
            SetAttackAttribute(GetAttackAttribute() - (f / 2.0f));
        }
        else if (GetDefenseLevel() == 4 && GetAttackLevel() >= 4)
        {
            // do nothing
        }
        else if (GetDefenseLevel() >= 5)
        {
            // do nothing
        }

        checkAttributes();
    }

    // Increase Size Attribute
    public void increaseSizeAttribute(float f)
    {
        if (GetSizeLevel() == 0 && GetSpeedLevel() >= 0)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
        }
        else if (GetSizeLevel() == 1 && GetSpeedLevel() < 1)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
        }
        else if (GetSizeLevel() == 1 && GetSpeedLevel() == 1)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
            SetSpeedAttribute(GetSpeedAttribute() - (f / 2.0f));
        }
        else if (GetSizeLevel() == 1 && GetSpeedLevel() > 1)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
        }
        else if (GetSizeLevel() == 2 && GetSpeedLevel() < 2)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
        }
        else if (GetSizeLevel() == 2 && GetSpeedLevel() == 2)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
            SetSpeedAttribute(GetSpeedAttribute() - (f / 2.0f));
        }
        else if (GetSizeLevel() == 2 && GetSpeedLevel() > 2)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
        }
        else if (GetSizeLevel() == 3 && GetSpeedLevel() < 2)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
        }
        else if (GetSizeLevel() == 3 && GetSpeedLevel() >= 2 && GetSpeedLevel() <= 3)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
            SetSpeedAttribute(GetSpeedAttribute() - (f / 2.0f));
        }
        else if (GetSizeLevel() == 3 && GetSpeedLevel() > 3 && GetSpeedLevel() < 5)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
            SetSpeedAttribute(GetSpeedAttribute() - (f / 2.0f));
        }
        else if (GetSizeLevel() == 3 && GetSpeedLevel() >= 5)
        {
            // do nothing
        }
        else if (GetSizeLevel() == 4 && GetSpeedLevel() >= 3 && GetSpeedLevel() <= 4)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
            SetSpeedAttribute(GetSpeedAttribute() - (f / 2.0f));
        }
        else if (GetSizeLevel() == 4 && GetSpeedLevel() >= 4)
        {
            // do nothing
        }
        else if (GetSizeLevel() >= 5)
        {
            // do nothing
        }

        checkAttributes();
    }

    // Increase Speed Attribute
    public void increaseSpeedAttribute(float f)
    {
        if (GetSpeedLevel() == 0 && GetSizeLevel() >= 0)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
        }
        else if (GetSpeedLevel() == 1 && GetSizeLevel() < 1)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
        }
        else if (GetSpeedLevel() == 1 && GetSizeLevel() == 1)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
            SetSizeAttribute(GetSizeAttribute() - (f / 2.0f));
        }
        else if (GetSpeedLevel() == 1 && GetSizeLevel() > 1)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
        }
        else if (GetSpeedLevel() == 2 && GetSizeLevel() < 2)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
        }
        else if (GetSpeedLevel() == 2 && GetSizeLevel() == 2)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
            SetSizeAttribute(GetSizeAttribute() - (f / 2.0f));
        }
        else if (GetSpeedLevel() == 2 && GetSizeLevel() > 2)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
        }
        else if (GetSpeedLevel() == 3 && GetSizeLevel() < 2)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
        }
        else if (GetSpeedLevel() == 3 && GetSizeLevel() >= 2 && GetSizeLevel() <= 3)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
            SetSizeAttribute(GetSizeAttribute() - (f / 2.0f));
        }
        else if (GetSpeedLevel() == 3 && GetSizeLevel() > 3 && GetSizeLevel() < 5)
        {
            SetSizeAttribute(GetSizeAttribute() + f);
            SetSpeedAttribute(GetSpeedAttribute() - (f / 2.0f));

        }
        else if (GetSpeedLevel() == 3 && GetSizeLevel() >= 5)
        {
            // do nothing
        }
        else if (GetSpeedLevel() == 4 && GetSizeLevel() >= 3 && GetSizeLevel() <= 4)
        {
            SetSpeedAttribute(GetSpeedAttribute() + f);
            SetSizeAttribute(GetSizeAttribute() - (f / 2.0f));
        }
        else if (GetSpeedLevel() == 4 && GetSizeLevel() >= 4)
        {
            // do nothing
        }
        else if (GetSpeedLevel() >= 5)
        {
            // do nothing
        }

        checkAttributes();
    }

    // Check The Attributes
    public void checkAttributes()
    {
        if (GetAttackAttribute() < 5.0f)
        {
            SetAttackLevel(0);
        }
        else if (GetAttackAttribute() >= 5.0f && GetAttackAttribute() < 10.0f)
        {
            SetAttackLevel(1);
        }
        else if (GetAttackAttribute() >= 10.0f && GetAttackAttribute() < 20.0f)
        {
            SetAttackLevel(2);
        }
        else if (GetAttackAttribute() >= 20.0f && GetAttackAttribute() < 40.0f)
        {
            SetAttackLevel(3);
        }
        else if (GetAttackAttribute() >= 40.0f && GetAttackAttribute() < 80.0f)
        {
            SetAttackLevel(4);
        }
        else if (GetAttackAttribute() >= 80.0f)
        {
            SetAttackLevel(5);
        }

        if (GetDefenseAttribute() < 5.0f)
        {
            SetDefenseLevel(0);
        }
        else if (GetAttackAttribute() >= 5.0f && GetDefenseAttribute() < 10.0f)
        {
            SetDefenseLevel(1);
        }
        else if (GetDefenseAttribute() >= 10.0f && GetDefenseAttribute() < 20.0f)
        {
            SetDefenseLevel(2);
        }
        else if (GetDefenseAttribute() >= 20.0f && GetDefenseAttribute() < 40.0f)
        {
            SetDefenseLevel(3);
        }
        else if (GetDefenseAttribute() >= 40.0f && GetDefenseAttribute() < 80.0f)
        {
            SetDefenseLevel(4);
        }
        else if (GetDefenseAttribute() >= 80.0f)
        {
            SetDefenseLevel(5);
        }

        if (GetSizeAttribute() < 5.0f)
        {
            SetSizeLevel(0);
        }
        else if (GetSizeAttribute() >= 5.0f && GetSizeAttribute() < 10.0f)
        {
            SetSizeLevel(1);
        }
        else if (GetSizeAttribute() >= 10.0f && GetSizeAttribute() < 20.0f)
        {
            SetSizeLevel(2);
        }
        else if (GetSizeAttribute() >= 20.0f && GetSizeAttribute() < 40.0f)
        {
            SetSizeLevel(3);
        }
        else if (GetSizeAttribute() >= 40.0f && GetSizeAttribute() < 80.0f)
        {
            SetSizeLevel(4);
        }
        else if (GetSizeAttribute() >= 80.0f)
        {
            SetSizeLevel(5);
        }

        if (GetSpeedAttribute() < 5.0f)
        {
            SetSpeedLevel(0);
        }
        else if (GetSpeedAttribute() >= 5.0f && GetSpeedAttribute() < 10.0f)
        {
            SetSpeedLevel(1);
        }
        else if (GetSpeedAttribute() >= 10.0f && GetSpeedAttribute() < 20.0f)
        {
            SetSpeedLevel(2);
        }
        else if (GetSpeedAttribute() >= 20.0f && GetSpeedAttribute() < 40.0f)
        {
            SetSpeedLevel(3);
        }
        else if (GetSpeedAttribute() >= 40.0f && GetSpeedAttribute() < 80.0f)
        {
            SetSpeedLevel(4);
        }
        else if (GetSpeedAttribute() >= 80.0f)
        {
            SetSpeedLevel(5);
        }

        if (GetAttackAttribute() < 0.0f)
        {
            SetAttackAttribute(0.0f);
        }
        if (GetDefenseAttribute() < 0.0f)
        {
            SetDefenseAttribute(0.0f);
        }
        if (GetSizeAttribute() < 0.0f)
        {
            SetSizeAttribute(0.0f);
        }
        if (GetSpeedAttribute() < 0.0f)
        {
            SetSpeedAttribute(0.0f);
        }
    }

    #endregion

    #endregion

}
