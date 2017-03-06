using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour
{

    #region Variables

    string mName;
    public EvoEnums.AbilityType mType;
    float mValue;

    #endregion

    #region Functions

    public virtual void Init() { }
    public virtual void Run() { }
    public virtual void Exit() { }

    public float GetValue() { return mValue; }
    public string GetName() { return mName; }

    #endregion
}
