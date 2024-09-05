using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

public class AutoFindInteractable : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<XRInteractableAffordanceStateProvider>().interactableSource = GetComponentInParent<XRBaseInteractable>();
    }
}
