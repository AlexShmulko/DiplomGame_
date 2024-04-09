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
        HeroHP = heroStats.HeroHP;
    }

    void Update()
    {
        HeroHP = heroStats.HeroHP;
        transform.offsetMax = new Vector2(-(1852 - HeroHP * 5.3f), transform.offsetMax.y);
    }
}
