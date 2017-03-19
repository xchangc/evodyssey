using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringModule : MonoBehaviour
{

    #region Variables

    LivingEntity mAgent;
    List<SteeringBehavior> mBehaviors;

    #endregion

    #region Functions

    public void SetAgent(LivingEntity newAgent) { mAgent = newAgent; }
    public void AddBehavior(SteeringBehavior behavior) { mBehaviors.Add(behavior); }
    public SteeringBehavior GetBehavior(string name)
    {
        foreach (SteeringBehavior item in mBehaviors)
        {
            if(item.GetName() == name)
            {
                return item;
            }
        }

        return null;
    }

    public Vector2 Calculate()
    {
        Vector2 finalVector = new Vector2(0,0);

        foreach (SteeringBehavior item in mBehaviors)
        {
            if(item.IsActive())
            {
                finalVector += item.Calculate();
            }
        }

        return finalVector;
    }

    #endregion

}
