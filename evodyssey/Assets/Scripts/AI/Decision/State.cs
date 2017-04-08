using UnityEngine;
using System.Collections;

public class State : ScriptableObject
{
    #region Functions

    public virtual void Enter(LivingEnemy entity) { }
    public virtual void UpdateState(LivingEnemy entity) { }
    public virtual void Exit(LivingEnemy entity) { }

    #endregion
}
