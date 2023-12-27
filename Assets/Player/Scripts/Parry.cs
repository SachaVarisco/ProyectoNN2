using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [Header("Shield")]
    private GameObject shield;
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
            if (shieldTime < 3f)
            {
                
            }
        }

        if (Input.GetButtonUp("C"))
        {
            shield.SetActive(true);
            shieldActive = true;
            shieldTime = 0f;
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
