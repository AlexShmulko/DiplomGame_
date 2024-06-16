using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTakeDamage : MonoBehaviour
{

    private SaveManager saveManager;
    private HeroStates heroStates;

    public Transform fp;

    public GameObject lolYouDied;

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private int originalLayer;

    DataManager dataManager;

    private void Update()
    {
        CheckDeath();
    }

    private void Start()
    {
        originalLayer = gameObject.layer;
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
            saveManager.souls = 0;
            saveManager.SaveData(); 
            dataManager.ResetValues();
            heroStates.isDied = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            lolYouDied.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robber") == true)
        {
            rb.AddForce(-fp.transform.right.x * new Vector2(80f, -30f));
            gameObject.layer = LayerMask.NameToLayer("Hero");
            TakeDamage(5);
            StartCoroutine(Cor());
        }
    }

    IEnumerator Cor()
    {
        yield return new WaitForSeconds(2f);
        gameObject.layer = originalLayer;
    }

}
