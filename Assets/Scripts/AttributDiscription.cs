using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttributDiscription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject attributeDiscription;
    public GameObject deffaultDiscription;

    private void Start()
    {
        attributeDiscription?.SetActive(false);
        deffaultDiscription?.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        attributeDiscription.SetActive(true);
        deffaultDiscription.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        attributeDiscription.SetActive(false);
        deffaultDiscription.SetActive(true);
    }
}
