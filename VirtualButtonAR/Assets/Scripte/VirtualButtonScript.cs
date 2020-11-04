using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VirtualButtonScript : MonoBehaviour ,IVirtualButtonEventHandler
{
    public GameObject cargo, cyclego;
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour[] vrb = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vrb.Length; i++)
        {
            vrb[i].RegisterEventHandler(this);
        }
        cargo.SetActive(false);
        cyclego.SetActive(false);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "CarVB")
        {
            Debug.Log("Car Button Pressed");
            cargo.SetActive(true);
            cyclego.SetActive(false);
        }
        else if(vb.VirtualButtonName == "CycleVB")
        {
            Debug.Log("Cycle Button Pressed");
            cargo.SetActive(false);
            cyclego.SetActive(true);
        }
        else
        {
            throw new UnityException(vb.VirtualButtonName + "Virtual Button not Supported");
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual Button Pressed");
    }
}
