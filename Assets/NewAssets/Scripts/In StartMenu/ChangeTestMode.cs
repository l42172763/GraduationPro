using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTestMode : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(ToggleEvent);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isOn">toggle 的选中与否</param>
    private void ToggleEvent(bool isOn)
    {
        AllStatics.TestMode = isOn;
    }
}
