using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributeViewUI : MonoBehaviour
{
    public string attribute;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        UpdateAttributeView();
    }

    private void Update()
    {
        UpdateAttributeView();
    }

    public void UpdateAttributeView()
    {
        textMesh.text = PlayerPrefs.GetInt(attribute).ToString();
    }
}
