using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (GetComponent<PlatformState>().canPush == true)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1500));
            }
        }
    }
}
