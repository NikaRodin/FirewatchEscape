using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;  // ovu vrijednost settamo u Unityju u komponenti
    public UnityEvent<GameObject> onEnterEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            onEnterEvent.Invoke(other.gameObject); 
            //triggeramo onEnterEvent s tim objektom koji je collideao s našim objektom

        }

    }
}
