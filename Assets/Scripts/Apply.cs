using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply : MonoBehaviour
{

    private InterfaceController interfaceController;

    private void Start()
    {
        interfaceController = GameObject.Find("Interface").GetComponent<InterfaceController>();
    }

    public void ApplyLevelUp()
    {
        interfaceController.UpdateCurretAttributes();
        interfaceController.isLevelUpApply = true;
    }
}
