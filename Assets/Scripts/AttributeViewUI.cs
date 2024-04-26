using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributeViewUI : MonoBehaviour
{
    public string attribute;
    private TextMeshProUGUI textMesh;
    private SaveManager saveManager;
    private int currentAttriibuteValue;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        UpdateAttributeView();
    }

    private void Update()
    {
        UpdateAttributeView();
    }

    public void UpdateAttributeView()
    {

        switch (attribute)
        {
            case "HeroAgility":
                currentAttriibuteValue = saveManager.heroAgility;
                break;
            case "HeroStrength":
                currentAttriibuteValue = saveManager.heroStrength;
                break;
            case "HeroIntelligence":
                currentAttriibuteValue = saveManager.heroIntelligence;
                break;
        }
        textMesh.text = currentAttriibuteValue.ToString();
    }
}
