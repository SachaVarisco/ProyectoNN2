using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause current;
    public GameObject pauseMenu;
    public bool isPaused;

    [SerializeField] private GameObject allSprites;

    private void Awake() {

        current = this;
        this.Resume();
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel")){

            if(this.isPaused){

                this.Resume();

            }
            else{

                this.PauseActive();
            }

        }
    }

    public void PauseActive(){
        
        this.isPaused = true;
        this.pauseMenu.SetActive(true);

        allSprites.SetActive(false);

        Time.timeScale = 0;
    }

    public void Resume(){

        this.isPaused = false;
        this.pauseMenu.SetActive(false);

        allSprites.SetActive(true);

        Time.timeScale = 1;
    }
}
