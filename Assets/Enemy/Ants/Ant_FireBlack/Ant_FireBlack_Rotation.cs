using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_FireBlack_Rotation : MonoBehaviour
{
    [Header("Player")]
    private Transform Player;
    private RotationSprite rotation;
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        rotation = GetComponent<RotationSprite>();
    }

    
    void Update()
    {
        if(Player.position.x > transform.position.x && rotation.LookLeft == true)
        {
            rotation.RotateX();

        }else if(Player.position.x < transform.position.x && rotation.LookLeft != true)
        {
            rotation.RotateX();
        }
    }
}
