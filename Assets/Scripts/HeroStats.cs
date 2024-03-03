using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    //public Image healPotion_1;
    //public Image healPotion_2;
    //public Image healPotion_3;

    public CanvasRenderer healPotion_1;
    public CanvasRenderer healPotion_2;
    public CanvasRenderer healPotion_3;

    public int HeroHP = 100;
    public int HealPotion = 3;

    private int healingSize = 25;
    public bool isHealing = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("I press healing!");
            GetHealing();
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && isHealing)
        {
            isHealing = false;
            animator.SetBool("isHealing", isHealing);
        }
    }

    public void GetDamage()
    {

    }

    public void GetHealing()
    {
        if(HealPotion != 0 && !isHealing && HeroHP != 100)
        {
            Input.ResetInputAxes();
            isHealing = true;
            animator.SetBool("isHealing", true);
            animator.Play("healing");
            if (HeroHP + healingSize > 100) HeroHP = 100;
            if (HeroHP + healingSize <= 100) HeroHP += healingSize;
            HealPotion--;
            if(HealPotion == 2) healPotion_3.gameObject.SetActive(false);
            if(HealPotion == 1) healPotion_2.gameObject.SetActive(false);
            if(HealPotion == 0) healPotion_1.gameObject.SetActive(false);
        }
    }
}
