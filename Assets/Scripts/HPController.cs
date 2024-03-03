using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public GameObject hero;
    HeroStats stats;
    int HeroHP;
    RectTransform transform;
    float hpWidth;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
        stats = hero.GetComponent<HeroStats>();
        HeroHP = stats.HeroHP;
    }

    // Update is called once per frame
    void Update()
    {
        HeroHP = stats.HeroHP;
        //transform.sizeDelta = new Vector2(500f, transform.sizeDelta.y);
        transform.offsetMax = new Vector2(-(1852 - HeroHP * 5.3f), transform.offsetMax.y);
    }
}
