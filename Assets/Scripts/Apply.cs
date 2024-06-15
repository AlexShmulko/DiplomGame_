using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply : MonoBehaviour
{
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void ApplyLevelUp()
    {
        saveManager.SaveData();
    }
}

public class CopyOfApply : MonoBehaviour
{
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void ApplyLevelUp()
    {
        saveManager.SaveData();
    }
}
