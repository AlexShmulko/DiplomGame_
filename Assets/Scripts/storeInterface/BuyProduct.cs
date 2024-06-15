using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyProduct : MonoBehaviour
{
    public int productIndex;
    public int productPrice;
    private SaveManager _saveManager;

    private void Start()
    {
        _saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void Buy()
    {
        switch (productIndex)
        {
            case 0:
                if (_saveManager.healPotions + 1 <= _saveManager.maxPotions && _saveManager.coins - productPrice >= 0)
                {
                    _saveManager.healPotions++;
                    _saveManager.coins -= productPrice;
                    _saveManager.SaveData();
                }
            break;

            case 1:
                if (_saveManager.manaPotions + 1 <= _saveManager.maxPotions && _saveManager.coins - productPrice >= 0)
                {
                    _saveManager.manaPotions++;
                    _saveManager.coins -= productPrice;
                    _saveManager.SaveData();
                }
            break;

            case 2:
                if (_saveManager.greenStones + 1 <= _saveManager.MAX_STONES && _saveManager.coins - productPrice >= 0)
                {
                    _saveManager.greenStones++;
                    _saveManager.coins -= productPrice;
                    _saveManager.SaveData();
                }
            break;

            case 3:
                if (_saveManager.orangeStones + 1 <= _saveManager.MAX_STONES && _saveManager.coins - productPrice >= 0)
                {
                    _saveManager.orangeStones++;
                    _saveManager.coins -= productPrice;
                    _saveManager.SaveData();
                }
            break;

            case 4:
                if (_saveManager.violotStones + 1 <= _saveManager.MAX_STONES && _saveManager.coins - productPrice >= 0)
                {
                    _saveManager.violotStones++;
                    _saveManager.coins -= productPrice;
                    _saveManager.SaveData();
                }
            break;
        }
    }
}
