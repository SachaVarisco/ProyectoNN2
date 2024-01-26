using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [Header("Respawn")]
    Vector3 startPoint;
    [SerializeField] private Transform respawn;

    private PlayerUtils playerUtils;

    void Start()
    {
        playerUtils = GetComponent<PlayerUtils>();
        startPoint = respawn.position;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.gameObject.SetActive(false);
            transform.position = startPoint;
            Invoke("Delay", 1f);
        }
    }

    private void Delay()
    {
        playerUtils.Life = 100f;
        this.gameObject.SetActive(true);
    }
}
