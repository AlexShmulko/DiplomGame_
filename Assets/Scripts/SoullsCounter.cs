using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoullsOunter : MonoBehaviour
{
    private TextMeshProUGUI _soulCount;
    private SaveManager _saveManager;
    public int mod; 
    // Start is called before the first frame update
    void Start()
    {
        _soulCount = GetComponent<TextMeshProUGUI>();
        _saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mod == 0)
            _soulCount.text = _saveManager.souls.ToString();
        if (mod == 1)
            _soulCount.text = _saveManager.levelUpCost.ToString();
        if (mod == 2)
            _soulCount.text = _saveManager.coins.ToString();
    }
}
