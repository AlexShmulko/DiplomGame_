using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{

    public Transform firePoint;
    public GameObject magicBallPrefab;

    private SaveManager saveManager;
    private Animator heroAnimator;
    private HeroMove heroMove;

    public bool isCasting = false;

    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        heroAnimator = GetComponent<Animator>();
        heroMove = GetComponent<HeroMove>();
    }

    public void StartCast ()
    {
        isCasting = true;
        heroAnimator.Play("cast");
        saveManager.currentHeroMP -= 20;
        saveManager.SaveData();
    }

    private void Cast()
    {
        Instantiate(magicBallPrefab, firePoint.position, firePoint.rotation);
    }

    private void StopCast()
    {
        StartCoroutine(WaitAfterCast());
        Input.ResetInputAxes();
    }

    IEnumerator WaitAfterCast()
    {
        yield return new WaitForSeconds(0.3f);
        isCasting = false;
    }
}
