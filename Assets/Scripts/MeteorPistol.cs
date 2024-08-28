using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;   //starting point from the raycast
    public float distance = 10;     //max distance of raycast

    private bool rayActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());

    }

    public void StartShoot()
    {
        AudioManager.instance.Play("Pistol");
        particles.Play();
        rayActivated = true;
    }

    public void StopShoot()
    {

        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivated = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(rayActivated)
        {
            RaycastCheck();
        }
    }

    void RaycastCheck()
    {
        RaycastHit hit;

        bool hasHit = Physics.Raycast(
            shootSource.position, 
            shootSource.forward, 
            out hit, 
            distance, 
            layerMask
        );

        if (hasHit) 
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
