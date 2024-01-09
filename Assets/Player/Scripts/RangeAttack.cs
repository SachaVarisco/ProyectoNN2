using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RangeAttack : MonoBehaviour
{

    [Header("Bullets")]
    [SerializeField] private Transform bulletController;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float reloadTime;
    [SerializeField] private float countdown;


    [Header("Recoil")]
    private Looking Looking;
    private Rigidbody2D rigidBody;
    private PlayerUtils utils;

    private void Start() 
    {
        utils = GetComponent<PlayerUtils>();
        rigidBody = GetComponent<Rigidbody2D>();
        Looking = GetComponent<Looking>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && countdown <= 0)
        {
           Shoot();    
        }
    }

     private void FixedUpdate() 
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {   
        AimShoot();
        countdown = reloadTime;
        GameObject bullet = Instantiate(bulletPrefab, bulletController.position, bulletController.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(NullMove());
        
       switch (Looking.direction)
        {
            case "Up":
                rigidBody.AddForce(Vector2.down * (utils.impulse/3), ForceMode2D.Impulse);
                break;
            case "Down":
                rigidBody.AddForce(Vector2.up * (utils.impulse/3), ForceMode2D.Impulse);
                break;
            case "Left":
                rigidBody.AddForce(Vector2.right * utils.impulse, ForceMode2D.Impulse);
                break;
            case "Right":
                rigidBody.AddForce(Vector2.left * utils.impulse, ForceMode2D.Impulse);
                break;
            default:
                break;
        }

    }

    IEnumerator NullMove()
    {
        utils.moveIsTrue = false;
        rigidBody.gravityScale = 0;

        yield return new WaitForSeconds(0.2f);

        utils.moveIsTrue = true;
        rigidBody.gravityScale = 2;
    }

    private void AimShoot()
    {
        switch (Looking.direction)
        {
            case "Up":
                bulletController.position = transform.position + new Vector3(0f, 2f, 0f);
                bulletController.eulerAngles = new Vector3(0, 0, 90f);
                break;
            case "Down":
                bulletController.position = transform.position + new Vector3(0f, -2f, 0f);
                bulletController.eulerAngles = new Vector3(0, 0, 270f);
                break;
            case "Left":
                bulletController.position = transform.position + new Vector3(-2f, 0f, 0f);
                bulletController.eulerAngles = new Vector3(0, 0, 0f);
                break;
            case "Right":
                bulletController.position = transform.position + new Vector3(2f, 0f, 0f);
                bulletController.eulerAngles = new Vector3(0, 0, 180f);
                break;
            default:
                break;
        }
    }

}