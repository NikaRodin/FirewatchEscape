using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class RigidbodySliderSync : MonoBehaviour
{
    public XRSlider slider;  // Reference to the XRSlider component
    public Transform knob;   // Reference to the knob transform
    private float startPosition;  // The initial position of the knob
    private float sliderLength;  // The length of the slider along the movement axis

    void Start()
    {
        // Initialize the start position and slider length based on the slider setup
        startPosition = 0;
        sliderLength = 1;
    }
        void Update()
    {
        // Calculate the relative position of the knob on the slider's axis
        float distanceMoved = knob.localPosition.z - startPosition;  // Assuming X-axis movement

        // Calculate the normalized value (between 0 and 1)
        float normalizedValue = Mathf.Clamp01(distanceMoved / sliderLength);

        // Update the slider's value
        slider.value = normalizedValue;
    }
}
