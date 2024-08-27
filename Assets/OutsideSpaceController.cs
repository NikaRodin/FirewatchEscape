using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OutsideSpaceController : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;
    public XRSlider slider;

    public float forwardSpeed;
    public float horizontalSpeed;
    public float verticalSpeed;

    private bool previousLeverValue;

    // Update is called once per framed
    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        float horizontalVelocity = horizontalSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);
        float verticalVelocity = verticalSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, slider.value);

        Vector3 velocity = new Vector3(horizontalVelocity, verticalVelocity, forwardVelocity);

        transform.position += velocity * Time.deltaTime;

        if (lever.value != previousLeverValue)
        {
            if (lever.value)
            {
                AudioManager.instance.Play("Engine");
            }
            else
            {
                AudioManager.instance.Stop("Engine");
            }
        }

        previousLeverValue = lever.value;
    }
}