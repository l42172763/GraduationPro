using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavButtonControl : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(ToggleEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ToggleEvent(bool isOn)
    {
        gameObject.SetActive(isOn);
        GameObject.FindGameObjectWithTag("Local Player").GetComponent<NavMeshAgent>().isStopped = true;
    }
}
