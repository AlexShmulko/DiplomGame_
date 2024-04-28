using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemiesController : MonoBehaviour
{
    public GameObject EnemyObject;
    public Enemy enemy;
    private GameObject newObject;

    public int robberHP = 100;
    public int souls = 3;

    void Start()
    {
    }

    void Update()
    {
        if (enemy != null)
        {
            robberHP = enemy.robberHP;
        }

        if(robberHP <= 0)
        {
            if (newObject != null)
            {
                OnDisable();
            }
        }
        else if(enemy.isDead)
        {
            OnDisable();
        }
    }

    public void Jojo()
    {
        if (newObject != null)
        {
            OnDisable();
        }
    } 

    private void OnDisable()
    {
        if (newObject != null)
        {   
            robberHP = enemy.robberHP;
            Destroy(newObject);
        }
    }

    private void OnEnable()
    {   
        SpawnBoys();
    }

    public void SpawnBoys()
    {
        Transform parent = gameObject.transform.parent;

        newObject = Instantiate(EnemyObject, gameObject.transform.position, gameObject.transform.rotation);

        newObject.transform.parent = parent;

        enemy = newObject.GetComponentInChildren<Enemy>();

        enemy.robberHP = robberHP;
        enemy.souls = souls;
    }
}
