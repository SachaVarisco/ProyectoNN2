using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [Header("Shield")]
    public GameObject shield;
    [SerializeField] private float shieldTime;
    [SerializeField] private float parryLimit;
    [SerializeField] private bool shieldActive;
    private PlayerUtils utils;
    void Start()
    {
        utils = GetComponent<PlayerUtils>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("C"))
        {
            shield.SetActive(true);
            shieldActive = true;

            if (shieldTime < parryLimit)
            {
                shield.GetComponent<SpriteRenderer>().color = Color.yellow;
                utils.ParryActive = true;
            }
            else
            {
                shield.GetComponent<SpriteRenderer>().color = Color.blue;
                utils.ParryActive = false;
                utils.shieldBlock = true;
            }
        }

        if (Input.GetButtonUp("C"))
        {
            shield.SetActive(false);
            shieldActive = false;
            shieldTime = 0f;
            utils.shieldBlock = false;
        }
    }

     private void FixedUpdate() 
    {   
        if (shieldActive)
        {
            shieldTime += Time.deltaTime;
        }
    }
}
