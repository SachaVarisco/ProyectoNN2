using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject Phase1;
    [SerializeField] private GameObject Phase2;
    [SerializeField] private GameObject Phase3;

    private float BossLife;

    private void Start() {
        
    }

    private void Update() {
        BossLife = GetComponent<EnemyStats>().Life;
        if (BossLife == 100)
        {
            Phase1.SetActive(true); 
        }else if (BossLife == 70)
        {
            Phase1.SetActive(false);
            Phase2.SetActive(true);
        }else if (BossLife == 40)
        {
            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(true);
        }
    }
}
