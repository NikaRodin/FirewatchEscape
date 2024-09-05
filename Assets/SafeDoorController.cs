using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SafeDoorController : MonoBehaviour
{
    public XRGrabInteractable safeGrabInteractable;
    public Rigidbody safeRigidbody;

    public void UnlockDoor()
    {
        safeGrabInteractable.enabled = true;
        safeRigidbody.isKinematic = false;
    }

    public void LockDoor()
    {
        safeGrabInteractable.enabled = false;
        safeRigidbody.isKinematic = true;
    }
}