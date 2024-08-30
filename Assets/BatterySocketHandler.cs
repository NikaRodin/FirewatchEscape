using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BatterySocketHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    // This method will be called when the battery snaps into the socket
    public void OnBatterySnapped(SelectEnterEventArgs args)
    {
        GameObject enteredObject = args.interactableObject.transform.gameObject;
        if (enteredObject.tag == "Battery")
        {
            // The battery has been snapped into place
            Rigidbody batteryRigidbody = enteredObject.GetComponent<Rigidbody>();
            if (batteryRigidbody != null)
            {
                batteryRigidbody.isKinematic = true;  // Disable battery physics
            }
            MeshCollider batteryMeshCollider = enteredObject.GetComponent<MeshCollider>();
            if (batteryMeshCollider != null)
            {
                batteryMeshCollider.enabled = false;  // Disable battery physics
            }

            //Debug.Log("Battery snapped into the socket!");
        }
    }


}
