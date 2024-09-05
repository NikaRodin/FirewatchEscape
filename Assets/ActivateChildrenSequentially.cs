using System.Collections;
using UnityEngine;

public class ActivateChildrenSequentially : MonoBehaviour
{
    public float delayBetweenActivations = 0.5f; // Time delay between activations

    void OnEnable()
    {
        // Start the coroutine to activate the children
        StartCoroutine(ActivateChildren());
    }

    IEnumerator ActivateChildren()
    {
        // Loop through each child of the parent object
        for (int i = 0; i < transform.childCount; i++)
        {
            // Get the child object
            Transform child = transform.GetChild(i);

            // Activate the child object
            child.gameObject.SetActive(true);

            // Wait for the specified delay time before activating the next child
            yield return new WaitForSeconds(delayBetweenActivations);
        }
    }
}
