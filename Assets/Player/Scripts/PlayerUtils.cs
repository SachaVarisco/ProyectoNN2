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

    [Header("Bounce")]
    private CharacterController characterController;
    [SerializeField] private float timeControlLost;

    private void Start()
    {

        characterController = GetComponent<CharacterController>();

        speed = 10;
        impulse = 20;
        LifeMax = 100;

        Life = LifeMax;
        LifeBar.StartLifeBar(Life);
    }

    public void TakeDamage(float damage)
    {
        if (!ParryActive)
        {
            if (shieldBlock)
            {
                Life -= damage / 2;
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

    public void TakeDamage(float damage, Vector2 position)
    {

        if (!ParryActive)
        {
            if (shieldBlock)
            {
                Life -= damage / 2;
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

        StartCoroutine(ControlLost());
        characterController.Bounce(position);
    }

    private IEnumerator ControlLost()
    {

        moveIsTrue = false;
        yield return new WaitForSeconds(timeControlLost);
        moveIsTrue = true;

    }
}
