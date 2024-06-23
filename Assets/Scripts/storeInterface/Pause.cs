using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPauseActive = false;

    public GameObject pauseMenu;

    void Start()
    {
        isPauseActive = false;
        pauseMenu.SetActive(isPauseActive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = isPauseActive ? 1 : 0;
            isPauseActive = !isPauseActive;
            pauseMenu.SetActive(isPauseActive);
        }
    }
}
