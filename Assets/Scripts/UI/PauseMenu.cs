using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject camera;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        camera.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0f;


    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        camera.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1f;
    }
}
