using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private GameObject allSprites;

    void Start()
    {
        allSprites = GameObject.FindGameObjectWithTag("Sprites");
        //allSprites.SetActive(false);
    }
    public void Pause()
    {
        allSprites.SetActive(false);
    }

    public void Resume()
    {
        allSprites.SetActive(true);
    }
}
