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
        camera.SetActive(false);
        Time.timeScale = 0f;


    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        camera.SetActive(true);
        Time.timeScale = 1f;
    }
}
