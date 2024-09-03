using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketGrabHandler : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public GameObject LCDdisplay;

    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(OnObjectGrabbed);
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(OnObjectGrabbed);
    }

    private void OnObjectGrabbed(SelectEnterEventArgs args)
    {
        XRBaseInteractable grabbedObject = (XRBaseInteractable) args.interactableObject;
        grabbedObject.interactionLayers = LayerMask.NameToLayer("GrabbedBattery");
        LCDdisplay.SetActive(true);
    }
}