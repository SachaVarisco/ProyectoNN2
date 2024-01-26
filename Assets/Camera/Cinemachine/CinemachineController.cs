using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    
    [SerializeField]
    private CinemachineVirtualCamera vcam1;


    [Header("ZoomAntBoss")]

    [SerializeField] private float zoom;

    private bool zoomActived = false;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    void Update() {

        if(zoomActived){

            Debug.Log(zoom);
            vcam1.m_Lens.OrthographicSize = Mathf.SmoothDamp(vcam1.m_Lens.OrthographicSize, zoom, ref velocity, smoothTime);
        }
        
    }

    public void ZoomAntBoss()
    {
        zoomActived = true;

        //Debug.Log(zoomActived);
    }


}
