using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKeyController : MonoBehaviour
{
    public GameObject doorLock;
    private Vector3 rotationAngle = new Vector3(0, -90, 0);

    public void rotateDoorLock()
    {
        doorLock.transform.Rotate(rotationAngle);
    }
}
