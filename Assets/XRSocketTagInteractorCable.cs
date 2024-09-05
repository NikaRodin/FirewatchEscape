using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractorCable : XRSocketInteractor
{
    public string correctTargetTag;
    public string incorrectTargetTag;
    public Material correctHoverMaterial;
    public Material incorrectHoverMaterial;

    public GameObject previewObject;  // The object that will be shown as a preview
    public GameObject finalObject;    // The object that will replace the original

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (interactable.transform.CompareTag(correctTargetTag))
        {
            interactableHoverMeshMaterial = correctHoverMaterial;
            return base.CanHover(interactable);
        }

        if (interactable.transform.CompareTag(incorrectTargetTag))
        {
            interactableHoverMeshMaterial = incorrectHoverMaterial;
            return base.CanHover(interactable);
        }

        return false;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.CompareTag(correctTargetTag);
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        if (previewObject != null)
        {
            previewObject.SetActive(true);
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        if (previewObject != null)
        {
            previewObject.SetActive(false);
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (finalObject != null && previewObject != null)
        {
            finalObject.SetActive(true);
            previewObject.SetActive(false);
            args.interactableObject.transform.gameObject.SetActive(false);
        }
    }
}