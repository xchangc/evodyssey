using UnityEngine;
using System.Collections;

[System.Serializable]
public class SteeringBehavior : ScriptableObject
{
    #region variables

    string mName;
    bool mActive;

    #endregion

    #region Functions

    public void SetName(string name)
    {
        mName = name;
    }

    public string GetName() { return mName; }
    public void SetActive(bool active) { mActive = active; }
    public bool IsActive() { return mActive; }

    public virtual Vector3 Calculate(LivingEntity entity, LivingEntity extra) { return new Vector2(-1,-1); }
    public virtual void Init(LivingEntity entity) { }

    #endregion
}
