using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LivingPlayer : LivingEntity
{

    #region Variables

    int mAttackLevel;
    int mDefenseLevel;
    int mSizeLevel;
    int mSpeedLevel;

    float mAttackAttribute;
    float mDefenseAttribute;
    float mSizeAttribute;
    float mSpeedAttribute;

    List<Mutation> mMutations;

    #endregion

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
    public int GetAttackLevel() { return mAttackLevel; }
    public int GetDefenseLevel() { return mDefenseLevel; }
    public int GetSizeLevel() { return mSizeLevel; }
    public int GetSpeedLevel() { return mSpeedLevel; }
    public float GetAttackAttribute() { return mAttackAttribute; }
    public float GetDefenseAttribute() { return mDefenseAttribute; }
    public float GetSizeAttribute() { return mSizeAttribute; }
    public float GetSpeedAttribute() { return mSpeedAttribute; }

    public void SetDefenseLevel(int level) { mDefenseLevel = level; }
    public void SetSizeLevel(int level) { mSizeLevel = level; }
    public void SetSpeedLevel(int level) { mSpeedLevel = level; }
    public void SetAttackLevel(int level) { mAttackLevel = level; }
    public void SetAttackAttribute(float attr) { mAttackAttribute = attr; }
    public void SetDefenseAttribute(float attr) { mDefenseAttribute = attr; }
    public void SetSizeAttribute(float attr) { mSizeAttribute = attr; }
    public void SetSpeedAttribute(float attr) { mSpeedAttribute = attr; }


    void Start() { }
    void Update() { }



    public override void Movement() { }

    public override void UseAbility() { }


}
