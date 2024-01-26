using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public PauseGame pauseGame;
    public GameObject imagePanel;
    //private Color colorImage;

    void Start()
    {
        //colorImage = imagePanel.GetComponent<Image>().color;
    }

    public void PressPlay()
    {
        pauseGame.Resume();
        StartCoroutine("Play");
        
    
    }

    IEnumerator Play()
    {
        imagePanel.SetActive(false);
        //imagePanel = new Color(imagePanel.Color.r, imagePanel.color.g, imagePanel.color.b, imagePanel.color.a - 1 * Time.deltaTime);
        yield return new WaitForSeconds(.5f);
        pauseGame.Resume();
    }
}
