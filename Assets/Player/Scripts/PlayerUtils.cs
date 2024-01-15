using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : MonoBehaviour
{
    [Header("Stats")]

    public float speed;
    public float impulse;
    public float Life;
    public float LifeMax;
    public LifeBar LifeBar;
    public bool ParryActive;
    public bool shieldBlock;

    public bool moveIsTrue = true;
    public bool onTheFloor = true;
    
    private void Start()
    {
        speed = 10;
        impulse = 20;
        LifeMax = 100;

        Life = LifeMax;
        //LifeBar.StartLifeBar(Life);
    }

    public void TakeDamage(float damage)
    {
        if (!ParryActive)
        {
            if (shieldBlock)
            {
                Life -= damage/2;
                LifeBar.ChangeHPActual(Life);
            }
            else
            {
                Life -= damage;
                LifeBar.ChangeHPActual(Life);
            }
        }

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
