using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public int menuIndex = 2;
    DataManager dataManager;
    private SaveManager saveManager;

    private void Start()
    {
        dataManager = DataManager.Instance;
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void ExitToMenu()
    {
        dataManager.ResetValues();
        saveManager.currentHeroHP = saveManager.heroHP;
        saveManager.souls = 0;
        saveManager.SaveData();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(menuIndex);
    }
}
