using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] GameObject hero;
    [SerializeField] HeroStats heroStats;
    //HeroStats stats;
    int HeroHP;
    RectTransform transform;
    void Start()
    {
        transform = GetComponent<RectTransform>();
        heroStats = hero.GetComponent<HeroStats>();
        HeroHP = heroStats.heroHP;
    }

    void Update()
    {
        HeroHP = heroStats.heroHP;
        transform.offsetMax = new Vector2(-(1852 - HeroHP * 5.3f), transform.offsetMax.y);
    }
}
