using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private int hubIndex = 0;
    private int trainingIndex = 1;
    private int menuIndex = 2;
    public SaveManager saveManager;

    private HeroStates heroStates;
    public GameObject lolYouDied;

    private void Start()
    {
        lolYouDied.SetActive(false);
        if (GameObject.Find("Hero") != null)
        {
            heroStates = GameObject.Find("Hero").GetComponent<HeroStates>();
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(hubIndex);
    }

    public void ContinueGame()
    {
        saveManager.currentHeroHP = saveManager.heroHP;
        saveManager.SaveData();
        heroStates.isDied = false;
        lolYouDied.SetActive(false);
        SceneManager.LoadScene(hubIndex);
    }

    public void NewGame()
    {
        saveManager.DeleteSaves();
        SceneManager.LoadScene(trainingIndex);
    }

    public void ToMenu()
    {
        saveManager.currentHeroHP = saveManager.heroHP;
        saveManager.SaveData();
        heroStates.isDied = false;
        lolYouDied.SetActive(false);
        SceneManager.LoadScene(menuIndex);
    }
}
