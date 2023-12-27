using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private float SpikeDamage;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.gameObject.GetComponent<EnemyStats>().TakeDamage(SpikeDamage);
            Destroy(gameObject);
        }
    }
}
