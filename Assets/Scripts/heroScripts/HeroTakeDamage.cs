using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTakeDamage : MonoBehaviour
{

    private SaveManager saveManager;
    private HeroStates heroStates;

    public GameObject lolYouDied;

    DataManager dataManager;

    private void Update()
    {
        CheckDeath();
    }

    private void Start()
    {
        dataManager = DataManager.Instance;
        lolYouDied.SetActive(false);
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        heroStates = GetComponent<HeroStates>();
    }

    public void TakeDamage(int damage)
    {
        saveManager.currentHeroHP -= damage;
        saveManager.SaveData();
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (saveManager.currentHeroHP <= 0)
        {

            //Debug.Log(GameObject.Find("DontDestroyOnLoad") + "sjdhfksjdhfiusdkfhksdjnfs");
            //Destroy(GameObject.Find("DontDestroyOnLoad"));
            dataManager.ResetValues();
            heroStates.isDied = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            lolYouDied.SetActive(true);
        }
    }

}
