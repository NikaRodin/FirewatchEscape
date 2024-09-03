using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class SliderFollowFinger : MonoBehaviour
{
    public XRSlider slider;  // Reference to the XRSlider component
    public Transform sliderTransform;  // Reference to the slider's transform (used to calculate positions)

    private void OnEnable()
    {
        // Subscribe to the hover enter and hover exit events of the slider
        slider.hoverEntered.AddListener(OnHoverEntered);
        slider.hoverExited.AddListener(OnHoverExited);
    }

    private void OnDisable()
    {
        // Unsubscribe from the hover enter and hover exit events of the slider
        slider.hoverEntered.RemoveListener(OnHoverEntered);
        slider.hoverExited.RemoveListener(OnHoverExited);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Check if the hovering object has a poke interactor
        XRPokeInteractor pokeInteractor = args.interactorObject as XRPokeInteractor;

        if (pokeInteractor != null)
        {
            // Start following the finger
            StartCoroutine(FollowFinger(pokeInteractor));
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        // Stop following the finger when it stops hovering
        StopAllCoroutines();
    }

    private IEnumerator FollowFinger(XRPokeInteractor pokeInteractor)
    {
        while (true)
        {
            // Get the fingertip position in the slider's local space
            Vector3 localFingerPos = sliderTransform.InverseTransformPoint(pokeInteractor.transform.position);

            // Calculate the normalized slider value based on the local position
            float normalizedValue = Mathf.Clamp01((localFingerPos.x - sliderTransform.localPosition.x) / sliderTransform.localScale.x);

            // Set the slider's value
            slider.value = normalizedValue;

            yield return null;  // Wait for the next frame
        }
    }
}
