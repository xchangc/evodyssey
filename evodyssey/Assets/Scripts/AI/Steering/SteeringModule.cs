using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringModule : MonoBehaviour
{

    #region Variables

    LivingEntity mAgent;
    List<SteeringBehavior> mBehaviors = new List<SteeringBehavior>();

    #endregion

    #region Functions

    public void SetAgent(LivingEntity newAgent) { mAgent = newAgent; }
    public void AddBehavior(SteeringBehavior behavior)
    {
        if(behavior != null)
        {
            Debug.Log("Accepted behavior: " + behavior);
            mBehaviors.Add(behavior);
        }
        else
        {
            Debug.Log("Trying to pass a null behavior: " + behavior);
        }

    }
    public SteeringBehavior GetBehavior(string name)
    {
        foreach (SteeringBehavior item in mBehaviors)
        {
            if (item.GetName() == name)
            {
                return item;
            }
        }

        return null;
    }

    public Vector3 Calculate()
    {
        Vector3 finalVector = new Vector3(0, 0, 0);

        foreach (SteeringBehavior item in mBehaviors)
        {
            if (item.IsActive())
            {
                finalVector += item.Calculate(mAgent,mAgent.GetFocusedEntity());
            }
        }

        return finalVector;
    }

    #endregion

}
