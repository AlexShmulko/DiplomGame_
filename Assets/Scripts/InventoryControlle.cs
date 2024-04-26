using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControlle : MonoBehaviour
{

    public Sprite hpPotion;
    public Sprite mpPotion;

    public TextMeshProUGUI itemCount;

    private InterfaceController interfaceController;
    private SaveManager saveManager;

    private int itemNumber = 0;

    private Image itemImage;

    void Start()
    {
        itemImage = gameObject.GetComponent<Image>();
        interfaceController = GameObject.Find("Interface").GetComponent<InterfaceController>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            itemNumber--;
            if (itemNumber < 0)
            {
                itemNumber = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            itemNumber++;
            if (itemNumber > 1)
            {
                itemNumber = 0;
            }
        }
        interfaceController.inventoryItemNumber = itemNumber;
        Inventory();
        ItemCountView();
    }

    private void Inventory ()
    {
        if (itemNumber == 0)
        {
            itemImage.sprite = hpPotion;
        }
        else if (itemNumber == 1)
        {
            itemImage.sprite = mpPotion;
        }
    }

    private void ItemCountView()
    {
        if (itemNumber == 0)
        {
            itemCount.text = saveManager.healPotions.ToString();
        }
        else if (itemNumber == 1)
        {
            itemCount.text = saveManager.manaPotions.ToString();
        }
    }
}
