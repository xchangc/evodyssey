using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class LivingEntity : MonoBehaviour
{

    #region Variables
    [Header("Base Class Variables")]
    [Space(10)]
    public string FishName;
    [Space(10)]
    [Header("Health is the current health")]
    public float mHealth;
    [Header("Max Health is also the size")]
    public float mMaxHealth;
    [Space(20)]
    public float mAttack;
    public float mDefense;
    [Space(20)]
    public float mSpeed;
    public float mMovementRotationSpeed;
    public float mStamina;
    [Space(20)]
    public float mHunger;
    public float mHungerWarningLevel;
    public float mHungerMax;
    public float mHungerIncreaseRate;
    [Space(20)]
    public bool mCanDash;
    public bool mCanAttack;
    [Space(20)]
    public string mPredator;
    public string mPrey;
    public string mDesiredFood;
    [Space(20)]
    public Ability mAbility;

    private Vector3 mVelocity;
    [Space(20)]
    [Header("empty gameobject that is a child of this entity")]
    public Transform mLocalTransform;

    private Rigidbody mRigidBody;

    private Transform mTarget;

    private LivingEntity mFocusedEntity;

    private EnvFood mFocusedFood;

    List<LivingEntity> mLocalEnemies = new List<LivingEntity>();
    List<LivingEntity> mLocalKind = new List<LivingEntity>();



    #endregion

    #region Functions

    public float GetHealth() { return mHealth; }
    public float GetSize() { return mMaxHealth; }
    public float GetAttack() { return mAttack; }
    public float GetDefense() { return mDefense; }
    public float GetSpeed() { return mSpeed; }
    public float GetStamina() { return mStamina; }
    public string GetPredator() { return mPredator; }
    public string GetPrey() { return mPrey; }
    public Ability GetAbility() { return mAbility; }
    public Vector3 GetVelocity() { return mVelocity; }
    public Transform GetLocalTransform() { return mLocalTransform; }
    public Rigidbody GetRigidBody() { return mRigidBody; }
    public float GetMovementRotation() { return mMovementRotationSpeed; }
    public Transform GetTarget() { return mTarget; }
    public LivingEntity GetFocusedEntity() { return mFocusedEntity; }
    public string GetFishName() { return FishName; }
    public List<LivingEntity> GetLocalKind() { return mLocalKind; }
    public List<LivingEntity> GetLocalEnemies() { return mLocalEnemies; }
    public float GetHunger() { return mHunger;}
    public float GetMaxHunger() { return mHungerMax; }
    public EnvFood GetFocusedFood() { return mFocusedFood; }

    public bool IsHungry()
    {
        if (mHunger >= mHungerWarningLevel)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool IsAbleToDash() { return mCanDash; }
    public bool IsAbleToAttack() { return mCanAttack; }

    public void SetHealth(float health) { mHealth = health; }
    public void SetSize(float size) { mMaxHealth = size; }
    public void SetAttack(float attack) { mAttack = attack; }
    public void SetDefense(float def) { mDefense = def; }
    public void SetSpeed(float speed) { mSpeed = speed; }
    public void SetStamina(float stam) { mStamina = stam; }
    public void SetDash(bool can) { mCanDash = can; }
    public void SetAbleToAttack(bool can) { mCanAttack = can; }
    public void SetPredator(string predator) { mPredator = predator; } // TODO:: fix these to work with all the predators, or put a type in and get true/false...
    public void SetPrey(string prey) { mPrey = prey; }
    public void SetAbility(Ability newAbility) { mAbility = newAbility; }
    public void SetVelocity(Vector3 newVelocity) { mVelocity = newVelocity; }
    public void SetTarget(Transform newTarget) { mTarget = newTarget; }
    public void SetFocusedEntity(LivingEntity entity) { mFocusedEntity = entity; }
    public void SetFishName(string newName) { FishName = newName; }
    public void SetHunger(float newHunger) { mHunger = newHunger; }
    public void SetMaxHunger(float newMaxHunger) { mHungerMax = newMaxHunger; }
    public void SetFocusedFood(EnvFood mFood) { mFocusedFood = mFood; }

    public void AddLocalKind(LivingEntity fish)
    {
        if(!mLocalKind.Contains(fish) && fish.GetFishName() == GetFishName())
        {
            mLocalKind.Add(fish);
        }
    }

    public void AddLocalEnemy(LivingEntity fish)
    {
        if (!mLocalEnemies.Contains(fish))
        {
            Debug.Log("added enemy");
            mLocalEnemies.Add(fish);
        }
    }

    public void RemoveLocalKind(LivingEntity fish)
    {
        if (mLocalKind.Contains(fish))
        {
            mLocalKind.Remove(fish);
        }
    }

    public void RemoveLocalEnemy(LivingEntity fish)
    {
        if (mLocalEnemies.Contains(fish))
        {
            Debug.Log("remove enemy");
            mLocalEnemies.Remove(fish);
        }
    }



    public void InitEntity()
    {
        mRigidBody = GetComponent<Rigidbody>();
        mSpeed *= 100;
    }



    public virtual void Movement() { }
    public virtual void UseAbility() { }

    #endregion

}
