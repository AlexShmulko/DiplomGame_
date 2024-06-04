using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    public int fieldIndex;

    private TextMeshProUGUI _text;
    private SaveManager _saveManager;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (fieldIndex) {
            case 0:
                _text.text = _saveManager.greenStones.ToString();
            break;
            case 1:
                _text.text = _saveManager.healPotions.ToString();
            break;
            case 2:
                _text.text = _saveManager.manaPotions.ToString();
            break;
            case 3:
                _text.text = "/" + _saveManager.maxPotions.ToString();
            break;
            case 4:
                _text.text = _saveManager.maxPotions.ToString();
            break;
            case 5:
                _text.text = _saveManager.violotStones.ToString();
            break;
            case 6:
                _text.text = _saveManager.orangeStones.ToString();
            break;
        }
    }
}
