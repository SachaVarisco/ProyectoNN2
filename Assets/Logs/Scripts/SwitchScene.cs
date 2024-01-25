using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void ShowLogs(){

        SceneManager.LoadScene(1);

    }

    public void BackMenu(){

        SceneManager.LoadScene(0);

    }

}
