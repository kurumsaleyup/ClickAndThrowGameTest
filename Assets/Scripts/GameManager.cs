using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Camera deathCam,maincam;
    public GameObject resetUI;
    public void resetScene()
    {

        ball.SetActive(false);
        deathCam.transform.position = maincam.transform.position;
        deathCam.enabled = true;
        resetUI.SetActive(true);
        Invoke("reset", 0.8f);
    }

    public void reset()
    {
        SceneManager.LoadScene("Game");
    }

}
