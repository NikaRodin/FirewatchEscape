using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketGrabHandler : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;

    private void OnEnable()
    {
        // Subscribe to the select entered event
        socketInteractor.selectEntered.AddListener(OnObjectGrabbed);
    }

    private void OnDisable()
    {
        // Unsubscribe from the select entered event
        socketInteractor.selectEntered.RemoveListener(OnObjectGrabbed);
    }

    private void OnObjectGrabbed(SelectEnterEventArgs args)
    {
        // Get the interactable object that was grabbed by the socket interactor
        XRBaseInteractable grabbedObject = (XRBaseInteractable) args.interactableObject;

        // Disable the XRGrabInteractable component on the grabbed object
        Rigidbody grabInteractable = grabbedObject.GetComponent<Rigidbody>();
        if (grabInteractable != null)
        {
            grabInteractable.isKinematic = true;
        }
    }
}