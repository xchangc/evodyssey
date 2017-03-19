using UnityEngine;
using System.Collections;

public class SteeringBehavior : MonoBehaviour
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

    public virtual Vector2 Calculate() { return new Vector2(-1,-1); }

    #endregion
}
