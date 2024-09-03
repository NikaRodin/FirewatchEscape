using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ElectricalBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    public const int numberOfSliders = 15;
    public int[] correctSliderValues = {1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0};
    public XRSlider[] sliders = new XRSlider[numberOfSliders];
    public XRLever lever;
    public Light greenLight;
    public Light redLight;
    public GameObject voltageArrowOn;
    public GameObject voltageArrowOff;

    public Light[] roomLights;
    public Animator ceilingFanAnimator;

    private bool isMatch = true;
    private bool isPowerOn = false;

    void Start()
    {
        PowerOff();
    }

    // Update is called once per frame
    void Update()
    {
        isMatch = true;
        for (int i = 0; i < sliders.Length; i++) 
        {
            if (sliders[i].value != correctSliderValues[i])
            {
                isMatch = false;
                break;
            }
        }

        if(isMatch && !lever.value)
            PowerOn();
        else
            PowerOff();
    }

    void PowerOn()
    {
        greenLight.enabled = true;
        redLight.enabled = false;
        voltageArrowOn.SetActive(true);
        voltageArrowOff.SetActive(false);
        isPowerOn = true;
        turnOnRoomLights();
        turnOnCeilingFan();
    }

    void PowerOff()
    {
        greenLight.enabled = false;
        redLight.enabled = true;
        voltageArrowOn.SetActive(false);
        voltageArrowOff.SetActive(true);
        isPowerOn = false;
        turnOffRoomLights();
        turnOffCeilingFan();
    }

    public bool getIsPowerOn() { return isPowerOn; }

    void turnOnRoomLights()
    {
        foreach (var roomLight in roomLights)
        {
            roomLight.enabled = true;
        }
    }

    void turnOffRoomLights()
    {
        foreach (var roomLight in roomLights)
        {
            roomLight.enabled = false;
        }
    }

    void turnOnCeilingFan()
    {
        ceilingFanAnimator.enabled = true;
    }

    void turnOffCeilingFan()
    {
        ceilingFanAnimator.enabled = false;
    }
}