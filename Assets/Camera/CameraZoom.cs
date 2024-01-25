using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] private GameObject ColliderZoom;
    private CinemachineController cine;
    void Awake()
    {
        cine = GetComponent<CinemachineController>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            cine.ZoomAntBoss();

            ColliderZoom.SetActive(true);

        }

    }


}
