using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePhysicsAfterSnapping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnSnappedToSocket();
    }

    void OnSnappedToSocket()
    {
        // Assuming the battery is now snapped into the walkie-talkie
        Rigidbody batteryRigidbody = this.GetComponent<Rigidbody>();
        if (batteryRigidbody != null)
        {
            batteryRigidbody.isKinematic = true;  // Disable physics on the battery
        }
    }

}
