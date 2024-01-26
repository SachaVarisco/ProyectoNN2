using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour
{

    [Header("Life Bar")]
    [SerializeField] private float Life;
    [SerializeField] private float LifeMax;
    [SerializeField] private LifeBar LifeBar;

    [Header("Bounce")]
    private CharacterController characterController;
    private PlayerUtils playerUtils;
    [SerializeField] private float timeControlLost;

    private void Start()
    {
        Life = LifeMax;
        LifeBar.StartLifeBar(Life);

        characterController = GetComponent<CharacterController>();
        playerUtils = GetComponent<PlayerUtils>();
    }

    public void TakeDamage(float damage){
        Life -= damage;
        LifeBar.ChangeHPActual(Life);

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }

      public void TakeDamage(float damage, Vector2 position){
        Life -= damage;
        LifeBar.ChangeHPActual(Life);

        if (Life <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(ControlLost());
        characterController.Bounce(position);
    }

    private IEnumerator ControlLost(){

        playerUtils.moveIsTrue = false;
        yield return new WaitForSeconds(timeControlLost);
        playerUtils.moveIsTrue = true;

    }
}
