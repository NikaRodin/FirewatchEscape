using UnityEngine;

public class LaptopScreenController : MonoBehaviour
{
    public GameObject batteryLowScreen;
    public GameObject workingScreen;
    public GameObject laptopCharger;
    public ElectricalBoxController electricalBox;

    void Start()
    {
        batteryLowScreen.SetActive(true);
        workingScreen.SetActive(false);
    }
    void Update()
    {
        if (laptopCharger.activeInHierarchy && electricalBox.getIsPowerOn())
        {
            batteryLowScreen.SetActive(false);
            workingScreen.SetActive(true);
        }
        else 
        {
            batteryLowScreen.SetActive(true);
            workingScreen.SetActive(false);
        }
    }
}
