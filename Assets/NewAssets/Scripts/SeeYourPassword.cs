using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeYourPassword : MonoBehaviour
{
    public InputField inputField;
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
        inputField.contentType = isOn ? InputField.ContentType.Standard : InputField.ContentType.Password;
        inputField.Select();
    }
}
