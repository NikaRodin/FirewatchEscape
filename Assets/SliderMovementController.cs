using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class SliderMovementController : MonoBehaviour
{
    public XRSlider slider;
    public XRPokeInteractor pokeInteractor;  

    private bool isFingerOverSlider = false;

    void Update()
    {
        if (isFingerOverSlider)
        {

            Vector3 fingerPosition = pokeInteractor.transform.position;
            Vector3 localFingerPosition = slider.transform.InverseTransformPoint(fingerPosition);

            float sliderMin = 0;
            float sliderMax = 1;
            float normalizedPosition = Mathf.Clamp01(localFingerPosition.x / slider.transform.localScale.x);

            slider.value = Mathf.Lerp(sliderMin, sliderMax, normalizedPosition);
        }
    }

    public void setIsFingerOverSlider(bool value) 
    { 
        isFingerOverSlider = value; 
    }
}