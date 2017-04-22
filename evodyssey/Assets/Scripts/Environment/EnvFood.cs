using UnityEngine;
using System.Collections;

public class EnvFood : MonoBehaviour
{

    public string FoodName;
    public int mHealthIncrease;
    public int mHungerIncrease;
    public int mFoodHealth;

    void Update()
    {
        if(mFoodHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
