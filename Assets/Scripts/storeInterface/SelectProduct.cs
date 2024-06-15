using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectProduct : MonoBehaviour
{
    public Sprite selectProdust;
    public Sprite notSelectProdust;
    public Image productImage;
    public bool isSelected = false;
    public int index;
    public Animator animator;
    public GameObject discription;

    private ProductsForSale productsForSale;

    private void Awake()
    {
        productsForSale = GameObject.Find("Table").GetComponent<ProductsForSale>();
    }

    private void OnDisable()
    {
        SelectOff();
    }

    public void Select()
    {
        if (isSelected)
        {
            SelectOff();
        }
        else
        {
            SelectOn();
        }
    }

    public void SelectOff()
    {
        isSelected = false;
        discription.SetActive(false);
        if (animator == null)
        {
            productImage.sprite = notSelectProdust;
        }
        else
        {
            if (index == 2) animator.Play("GreenStoneNotSelect");
            if (index == 3) animator.Play("OrangeStoneNotSelect");
            if (index == 4) animator.Play("VioletStoneNotSelect");
        }
    }

    private void SelectOn()
    {
        isSelected = true;
        discription.SetActive(true);
        if (animator == null)
        {
            productImage.sprite = selectProdust;
        }
        else
        {
            if (index == 2) animator.Play("GreenStoneSelect");
            if (index == 3) animator.Play("OrangeStoneSelect");
            if (index == 4) animator.Play("VioletStoneSelect");
        }
        productsForSale.DisableSelection(index);
    }
}
