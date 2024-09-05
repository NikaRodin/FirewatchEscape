using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    public string correctTargetTag;
    public string incorrectTargetTag;
    public Material correctHoverMaterial;
    public Material incorrectHoverMaterial;

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
}