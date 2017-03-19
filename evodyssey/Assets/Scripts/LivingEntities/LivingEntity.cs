﻿using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour
{

    #region Variables
    [Header("Base Class Variables")]
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
    public float mStamina;
    [Space(20)]
    public bool mCanDash;
    public bool mCanAttack;
    [Space(20)]
    public LivingEntity mPredator;
    public LivingEntity mPrey;
    [Space(20)]
    public Ability mAbility;

    #endregion

    #region Functions

    public float GetHealth() { return mHealth; }
    public float GetSize() { return mMaxHealth; }
    public float GetAttack() { return mAttack; }
    public float GetDefense() { return mDefense; }
    public float GetSpeed() { return mSpeed; }
    public float GetStamina() { return mStamina; }
    public LivingEntity GetPredator() { return mPredator; }
    public LivingEntity GetPrey() { return mPrey; }
    public Ability GetAbility() { return mAbility; }

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
    public void SetPredator(LivingEntity predator) { mPredator = predator; }
    public void SetPrey(LivingEntity prey) { mPrey = prey; }
    public void SetAbility(Ability newAbility) { mAbility = newAbility; }

    public virtual void Movement() { }
    public virtual void UseAbility() { }

    #endregion

}